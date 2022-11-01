using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace IFramework.Net.Tcp
{
    internal class TcpServerProvider : TcpSocket, IDisposable, ITcpServerProvider
    {
        #region variable
        private bool isStoped = true;
        private bool _isDisposed = false;
        private int numberOfConnections = 0;
        private int maxNumberOfConnections = 32;
        private int offsetNumber = 2;
        private Encoding encoding = Encoding.UTF8;
 
        private LockParam lParam = new LockParam();
        private Semaphore maxNumberAcceptedClients = null;
        private SocketTokenManager<SocketAsyncEventArgs> sendTokenManager = null;
        private SocketTokenManager<SocketAsyncEventArgs> acceptTokenManager = null;
        private SocketBufferManager recvBufferManager = null;
        private SocketBufferManager sendBufferManager = null;

        #endregion

        #region properties
        /// <summary>
        /// 接受连接回调处理
        /// </summary>
        public OnAcceptedHandler AcceptedCallback { get; set; }

        /// <summary>
        /// 接收数据回调处理
        /// </summary>
        public OnReceivedHandler ReceivedCallback { get; set; }

        /// <summary>
        ///接收数据缓冲区，返回缓冲区的实际偏移和数量
        /// </summary>
        public OnReceivedSegmentHandler ReceivedOffsetCallback { get; set; }

        /// <summary>
        /// 发送回调处理
        /// </summary>
        public OnSentHandler SentCallback { get; set; }

        /// <summary>
        /// 断开连接回调处理
        /// </summary>
        public OnDisconnectedHandler DisconnectedCallback { get; set; }

        /// <summary>
        /// 连接数
        /// </summary>
        public int NumberOfConnections
        {
            get { return numberOfConnections; }
        }

        #endregion

        #region constructor
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (_isDisposed) return;

            if (isDisposing)
            {
                DisposeSocketPool();
                SafeClose();
                recvBufferManager.Clear();
                sendBufferManager.Clear();
                _isDisposed = true;
                maxNumberAcceptedClients.Dispose();
            }
        }

        private void DisposeSocketPool()
        {
            sendTokenManager.ClearToCloseArgs();
            acceptTokenManager.ClearToCloseArgs();
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="maxConnections">最大连接数</param>
        /// <param name="chunkBufferSize">接收块缓冲区</param>
        public TcpServerProvider(int maxConnections = 32, int chunkBufferSize = 4096)
            :base(chunkBufferSize)
        {
            if (maxConnections < 2) maxConnections = 2;
            this.maxNumberOfConnections = maxConnections;

            maxNumberAcceptedClients = new Semaphore(maxConnections+offsetNumber, maxConnections+offsetNumber);

            recvBufferManager = new SocketBufferManager(maxConnections+offsetNumber, chunkBufferSize);
            acceptTokenManager = new SocketTokenManager<SocketAsyncEventArgs>(maxConnections+ offsetNumber);

            sendTokenManager = new SocketTokenManager<SocketAsyncEventArgs>(maxConnections+ offsetNumber);
            sendBufferManager = new SocketBufferManager(maxConnections+ offsetNumber, chunkBufferSize);
        }

        #endregion

        #region public method

        public bool Start(int port, string ip = "0.0.0.0")
        {
            int errorCount = 0;
            Stop();
            InitializeAcceptPool();
            InitializeSendPool();

            reStart:
            try
            {
                SafeClose();

                using (LockWait lwait = new LockWait(ref lParam))
                {
                    CreateTcpSocket(port,ip);
 
                    socket.Bind(ipEndPoint);

                    socket.Listen(128);

                    isStoped = false;
                }

                StartAccept(null);
                return true;
            }
            catch (Exception ex)
            {
                SafeClose();
                ++errorCount;

                if (errorCount >= 3)
                {
                    throw ex;
                }
                else
                {
                    Thread.Sleep(1000);
                    goto reStart;
                }
            }
        }

        public void Stop()
        {
            try
            {
                using (LockWait lwait = new LockWait(ref lParam))
                {
                    DisposePoolToken();

                    if (numberOfConnections > 0)
                    {
                        if (maxNumberAcceptedClients != null)
                            maxNumberAcceptedClients.Release(numberOfConnections);

                        numberOfConnections = 0;
                    }
                    SafeClose();
                    isStoped = true;
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public void Close(SocketToken sToken)
        {
            ProcessAsyncDisconnect(sToken);
        }

        public bool Send(SegmentToken segToken, bool waiting = true)
        {
            try
            {
                if (!segToken.sToken.TokenSocket.Connected) return false;
               
                bool isWillEvent = true;

                ArraySegment<byte>[] segItems = sendBufferManager.BufferToSegments(segToken.Data.buffer,
                    segToken.Data.offset,
                    segToken.Data.size);

                foreach (var seg in segItems)
                {
                    if (!segToken.sToken.TokenSocket.Connected) return false;

                    var tArgs = GetSocketAsyncFromSendPool(waiting, segToken.sToken.TokenSocket);
                    if (tArgs == null) return false;

                    tArgs.UserToken = segToken.sToken;

                    if (!sendBufferManager.WriteBuffer(tArgs, seg.Array, seg.Offset, seg.Count))
                    {
                        sendTokenManager.Set(tArgs);

                        throw new Exception(string.Format("发送缓冲区溢出...buffer block max size:{0}", sendBufferManager.BlockSize));
                    }

                    isWillEvent &=segToken.sToken.SendAsync(tArgs);
                    if (!isWillEvent)
                    {
                        ProcessSentCallback(tArgs);
                    }

                    if (sendTokenManager.Count < (sendTokenManager.Capacity >> 2))
                        Thread.Sleep(5);
                }
                return isWillEvent;
            }
            catch (Exception ex)
            {
                Close(segToken.sToken);

                throw ex;
            }
        }

        public int SendSync(SegmentToken segToken)
        {
            return segToken.sToken.Send(segToken.Data);
        }

        #endregion

        #region private method

        private void DisposePoolToken()
        {
            sendTokenManager.ClearToCloseArgs();
            acceptTokenManager.ClearToCloseArgs();
        }

        private void InitializeAcceptPool()
        {
            acceptTokenManager.Clear();
            int cnt = maxNumberOfConnections + offsetNumber;

            for (int i = 1; i <=cnt; ++i)
            {
                SocketAsyncEventArgs args = new SocketAsyncEventArgs() {
                    DisconnectReuseSocket=true,
                    SocketError=SocketError.SocketError
                };
                args.Completed += IO_Completed;
                args.UserToken = new SocketToken(i)
                {
                    TokenAgrs = args,
                };
                recvBufferManager.SetBuffer(args);
                acceptTokenManager.Set(args);
            }
        }

        private void InitializeSendPool()
        {
            sendTokenManager.Clear();
            int cnt = maxNumberOfConnections + offsetNumber;
            for (int i = 1; i <=cnt; ++i)
            {
                SocketAsyncEventArgs args = new SocketAsyncEventArgs() {
                    DisconnectReuseSocket=true,
                    SocketError=SocketError.NotInitialized
                };
                args.Completed += IO_Completed;
                args.UserToken = new SocketToken(i);
                sendBufferManager.SetBuffer(args);
                sendTokenManager.Set(args);
            }
        }

        private void StartAccept(SocketAsyncEventArgs e)
        {
            if (isStoped || socket == null)
            {
                isStoped = true;
                return;
            }
            if (e == null)
            {
                e = new SocketAsyncEventArgs()
                {
                    DisconnectReuseSocket = true,
                    UserToken = new SocketToken(),
                };
                e.Completed += Accept_Completed;
            }
            else
            {
                e.AcceptSocket = null;
            }

            maxNumberAcceptedClients.WaitOne();
            if (!socket.AcceptAsync(e))
            {
                ProcessAcceptCallback(e);
            }
        }

        private void ProcessAcceptCallback(SocketAsyncEventArgs e)
        {
            if (isStoped
                //|| maxNumberOfConnections <= numberOfConnections
                || e.SocketError != SocketError.Success)
            {
                DisposeSocketArgs(e);
                //ProcessDisconnectCallback(e);
                return;
            }

            //从对象池中取出一个对象
            SocketAsyncEventArgs tArgs = acceptTokenManager.GetEmptyWait((retry) =>
            {
                return true;
            }, false);

            if (tArgs == null)
            {
                 DisposeSocketArgs(e);
                return;
                //throw new Exception(string.Format("已经达到最大连接数max:{0};used:{1}",
                //    maxNumberOfConnections, numberOfConnections));
            }

            Interlocked.Increment(ref numberOfConnections);

            SocketToken sToken = ((SocketToken)tArgs.UserToken);
            sToken.TokenSocket = e.AcceptSocket;
            sToken.TokenSocket.ReceiveTimeout = receiveTimeout;
            sToken.TokenSocket.SendTimeout = sendTimeout;
            sToken.TokenIpEndPoint = (IPEndPoint)e.AcceptSocket.RemoteEndPoint;
            sToken.TokenAgrs = tArgs;
            tArgs.UserToken = sToken;

            //listening receive 
            if (e.AcceptSocket.Connected)
            {
                if (!e.AcceptSocket.ReceiveAsync(tArgs))
                {
                    ProcessReceiveCallback(tArgs);
                }

                if (maxNumberOfConnections < numberOfConnections)
                {
                    Close(sToken);
                    //ProcessDisconnectCallback(tArgs);
                }
                else
                {
                    //将信息传递到自定义的方法
                    AcceptedCallback?.Invoke(sToken);
                }
            }
            else
            {
                ProcessDisconnectCallback(tArgs);
            }

            if (isStoped) return;

            //继续准备下一个接收
            StartAccept(e);
        }

        private void ProcessReceiveCallback(SocketAsyncEventArgs e)
        {
            if (e.SocketError != SocketError.Success
                || e.BytesTransferred == 0)
            {
                ProcessDisconnectCallback(e);
                return;
            }

            SocketToken sToken = e.UserToken as SocketToken;

            if (ReceivedOffsetCallback != null)
            {
                ReceivedOffsetCallback(new SegmentToken(sToken, e.Buffer, e.Offset, e.BytesTransferred));
            }

            //处理接收到的数据
            if (ReceivedCallback != null)
            {
                ReceivedCallback(sToken, encoding.GetString(e.Buffer, e.Offset, e.BytesTransferred));
            }
            if (sToken.TokenSocket.Connected)
            {
                //继续投递下一个接受请求
                if (!sToken.TokenSocket.ReceiveAsync(e))
                {
                    this.ProcessReceiveCallback(e);
                }
            }
            else
            {
                ProcessDisconnectCallback(e);
            }
        }

        private void ProcessSentCallback(SocketAsyncEventArgs e)
        {
            try
            {
                if (e.SocketError == SocketError.Success)
                {
                    if (SentCallback != null)
                    {
                        SocketToken sToken = e.UserToken as SocketToken;
                        SentCallback(new SegmentToken( sToken, e.Buffer, e.Offset, e.BytesTransferred));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sendTokenManager.Set(e);
            }
        }

        private void ProcessDisconnectCallback(SocketAsyncEventArgs e)
        {
            SocketToken sToken = e.UserToken as SocketToken;
            if (sToken == null) {
                return;// throw new Exception("空异常");
            }

            try
            {
                sToken.Close();
                //递减信号量
                maxNumberAcceptedClients.Release();

                Interlocked.Decrement(ref numberOfConnections);
                if (sToken.TokenId != 0)
                {
                    //将断开的对象重新放回复用队列
                    acceptTokenManager.Set(e);
                }

                DisconnectedCallback?.Invoke(sToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DisposeSocketArgs(SocketAsyncEventArgs e)
        {
            SocketToken s = e.UserToken as SocketToken;
            if (s != null) s.Close();// if (e.UserToken is SocketToken s) --新语法
            e.Dispose();
        }

        private SocketAsyncEventArgs GetSocketAsyncFromSendPool(bool waiting, Socket socket)
        {
            var tArgs = sendTokenManager.GetEmptyWait((retry) =>
            {
                if (socket.Connected == false) return false;
                return true;
            }, waiting);

            if (socket.Connected == false)
                return null;

            if (tArgs == null)
                throw new Exception("发送缓冲池已用完,等待回收超时...");

            return tArgs;
        }

        //slow close client socket
        private void ProcessAsyncDisconnect(SocketToken sToken)
        {
            try
            {
                if (sToken == null
                    || sToken.TokenSocket == null
                    || sToken.TokenAgrs == null) return;

                //SocketAsyncEventArgs args = new SocketAsyncEventArgs()
                //{
                //    DisconnectReuseSocket = true,
                //    SocketError = SocketError.SocketError,
                //    UserToken = null
                //};
                //args.Completed += IO_Completed;
                //if (sToken.TokenSocket.DisconnectAsync(args) == false)
                //{
                //    ProcessDisconnectCallback(sToken.TokenAgrs);
                //}

                if (sToken.TokenSocket.Connected)
                    sToken.TokenSocket.Shutdown(SocketShutdown.Send);

                sToken.TokenSocket.Close();
            }
            catch (ObjectDisposedException oe)
            {
#if DEBUG
                Console.WriteLine(oe.TargetSite.Name + oe.Message);
#endif
                return;
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.TargetSite.Name + ex.Message);
#endif
            }
        }

        void IO_Completed(object sender, SocketAsyncEventArgs e)
        {
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Receive:
                    ProcessReceiveCallback(e);
                    break;
                case SocketAsyncOperation.Send:
                    ProcessSentCallback(e);
                    break;
                case SocketAsyncOperation.Disconnect:
                    ProcessDisconnectCallback(e);
                    break;
                case SocketAsyncOperation.Accept:
                    ProcessAcceptCallback(e);
                    break;
                default:
                    break;
            }
        }

        void Accept_Completed(object send, SocketAsyncEventArgs e)
        {
            ProcessAcceptCallback(e);
        }
        #endregion
    }
}