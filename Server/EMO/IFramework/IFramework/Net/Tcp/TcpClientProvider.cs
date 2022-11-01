using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace IFramework.Net.Tcp
{
    internal class TcpClientProvider : TcpSocket, IDisposable, ITcpClientProvider
    {
        #region variable
        private bool _isDisposed = false;
        private int bufferNumber = 8;
        private Encoding encoding = Encoding.UTF8;
        private int offsetNumber = 2;
        private ChannelProviderType channelProviderState = ChannelProviderType.Async;
        private LockParam lParam = new LockParam();
        private SocketTokenManager<SocketAsyncEventArgs> sendTokenManager = null;
        private SocketBufferManager sBufferManager = null;
        private AutoResetEvent mReset = new AutoResetEvent(false);
        #endregion

        #region properties
        /// <summary>
        /// 发送回调处理
        /// </summary>
        public OnSentHandler SentCallback { get; set; }

        /// <summary>
        /// 接收数据回调处理
        /// </summary>
        public OnReceivedHandler RecievedCallback { get; set; }

        /// <summary>
        /// 接受数据回调，返回缓冲区和偏移量
        /// </summary>
        public OnReceivedSegmentHandler ReceivedOffsetCallback { get; set; }

        /// <summary>
        /// 断开连接回调处理
        /// </summary>
        public OnDisconnectedHandler DisconnectedCallback { get; set; }

        /// <summary>
        /// 连接回调处理
        /// </summary>
        public OnConnectedHandler ConnectedCallback { get; set; }

        /// <summary>
        /// 是否连接状态
        /// </summary>
        public bool IsConnected
        {
            get { return isConnected; }
        }

        public int SendBufferPoolNumber { get { return sendTokenManager.Count; } }

        public ChannelProviderType ChannelProviderState
        {
            get { return channelProviderState; }
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
                _isDisposed = true;
            }
        }

        private void DisposeSocketPool()
        {
            sendTokenManager.Clear();
            if (sBufferManager != null)
            {
                sBufferManager.Clear();
            }
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="chunkBufferSize">发送块缓冲区大小</param>
        /// <param name="bufferNumber">缓冲发送数</param>
        public TcpClientProvider(int chunkBufferSize = 4096, int bufferNumber = 8)
            :base(chunkBufferSize)
        {
            this.bufferNumber = bufferNumber;
        }

        #endregion

        #region public method
        /// <summary>
        /// 异步建立连接
        /// </summary>
        /// <param name="port"></param>
        /// <param name="ip"></param>
        public void Connect(int port, string ip)
        {
            try
            {
                if (!IsClose())
                {
                    Close();
                }

                isConnected = false;
                channelProviderState = ChannelProviderType.Async;

                using (LockWait lwait = new LockWait(ref lParam))
                {
                    CreatedConnectToBindArgs(port,ip);
                }
            }
            catch (Exception)
            {
                Close();
                throw;
            }
        }

        /// <summary>
        /// 异步等待连接返回结果
        /// </summary>
        /// <param name="port"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public bool ConnectTo(int port,string ip)
        {
            try
            {
                if (!IsClose())
                {
                    Close();
                }

                isConnected = false;
                channelProviderState = ChannelProviderType.AsyncWait;

                using (LockWait lwait = new LockWait(ref lParam))
                {
                   CreatedConnectToBindArgs(port,ip);
                }
                mReset.WaitOne(connectioTimeout);
                isConnected = socket.Connected;

                return isConnected;
            }
            catch (Exception ex)
            {
                Close();
                throw ex;
            }
        }

        /// <summary>
        /// 同步连接
        /// </summary>
        /// <param name="port"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public bool ConnectSync(int port, string ip)
        {

            if (!IsClose())
            {
                Close();
            }

            isConnected = false;
            channelProviderState = ChannelProviderType.Sync;
            int retry = 3;

            CreateTcpSocket(port, ip);

            //using (LockWait lwait = new LockWait(ref lParam))
            //{
            //    CreatedConnectToBindArgs(port,ip);
            //}
            while (retry > 0)
            {
                try
                {
                    --retry;
                    socket.Connect(ipEndPoint);
                    isConnected = true;
                    return true;
                }
                catch (Exception ex)
                {
                    Close();
                    if (retry <= 0) throw ex;
                    Thread.Sleep(1000);
                }
            }
            return false;
        }

        /// <summary>
        /// 根据偏移发送缓冲区数据
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        public bool Send(SegmentOffset sendSegment, bool waiting = true)
        {
            try
            {
                if (IsClose())
                {
                    Close();
                    return false;
                }

                ArraySegment<byte>[] segItems = sBufferManager.BufferToSegments(sendSegment.buffer, sendSegment.offset, sendSegment.size);
                bool isWillEvent = true;

                foreach (var seg in segItems)
                {
                    var tArgs = GetSocketAsyncFromSendPool(waiting);
                    if (tArgs == null)
                    {
                        return false;
                    }
                    if (!sBufferManager.WriteBuffer(tArgs, seg.Array, seg.Offset, seg.Count))
                    {
                        sendTokenManager.Set(tArgs);

                        throw new Exception(string.Format("发送缓冲区溢出...buffer block max size:{0}", sBufferManager.BlockSize));
                    }
                    if (tArgs.UserToken == null)
                        ((SocketToken)tArgs.UserToken).TokenSocket = socket;

                    if (IsClose())
                    {
                        Close();
                        return false;
                    }

                    isWillEvent &= socket.SendAsync(tArgs);
                    if (!isWillEvent)//can't trigger the io complated event to do
                    {
                        ProcessSentCallback(tArgs);
                    }

                    if (sendTokenManager.Count < (sendTokenManager.Capacity >> 2))
                        Thread.Sleep(2);
                }

                return isWillEvent;
            }
            catch (Exception ex)
            {
                Close();

                throw ex;
            }
        }

        /// <summary>
        /// 发送文件
        /// </summary>
        /// <param name="filename"></param>
        public void SendFile(string filename)
        {
            socket.SendFile(filename);
        }

        /// <summary>
        /// 同步发送并接收数据,不设置receiveSegment 默认为只发数据
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="receiveBlock"></param>
        /// <param name="recAct"></param>
        /// <returns></returns>
        public int SendSync(SegmentOffset sendSegment,SegmentOffset receiveSegment)
        {
            if (channelProviderState != ChannelProviderType.Sync)
            {
                throw new Exception("需要使用同步连接...ConnectSync");
            }

            int sent = socket.Send(sendSegment.buffer, sendSegment.offset, sendSegment.size, SocketFlags.None);
            if (receiveSegment == null
                || receiveSegment.buffer == null
                || receiveSegment.size == 0)  return sent;

            int cnt = socket.Receive(receiveSegment.buffer, receiveSegment.size, 0);

            return sent;
        }

        /// <summary>
        /// 同步接收数据
        /// </summary>
        /// <param name="receiveBlock"></param>
        /// <param name="receivedAction"></param>
        public void ReceiveSync(SegmentOffset receiveSegment, Action<SegmentOffset> receivedAction)
        {
            if (channelProviderState != ChannelProviderType.Sync)
            {
                throw new Exception("需要使用同步连接...ConnectSync");
            }
            int cnt = 0;
            do
            {
                if (socket.Connected == false) break;

                cnt = socket.Receive(receiveSegment.buffer, receiveSegment.size, 0);
                if (cnt <= 0) break;

                receivedAction(receiveSegment);

            } while (true);
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        public void Disconnect()
        {
            Close();
            isConnected = false;
        }

        #endregion

        #region private method

        private void  CreatedConnectToBindArgs(int port,string ip)
        {
            CreateTcpSocket(port,ip);

            //连接事件绑定
            var sArgs = new SocketAsyncEventArgs
            {
                RemoteEndPoint = ipEndPoint,
                UserToken = new SocketToken() { TokenSocket = socket }
            };
            sArgs.AcceptSocket = socket;
            sArgs.Completed += new EventHandler<SocketAsyncEventArgs>(IO_Completed);
            if (!socket.ConnectAsync(sArgs))
            {
                ProcessConnectCallback(sArgs);
            }
        }

        private void Close()
        {
            using (LockWait lwait = new LockWait(ref lParam))
            {
                DisposeSocketPool();
                SafeClose();
                isConnected = false;
            }
        }

        private bool IsClose()
        {
            return (IsConnected == false
                || socket == null
                || socket.Connected == false);
        }

        private SocketAsyncEventArgs GetSocketAsyncFromSendPool(bool waiting)
        {
            var tArgs = sendTokenManager.GetEmptyWait((retry) =>
            {
                return !IsClose();

            }, waiting);

            if (IsConnected == false) return null;

            if (tArgs == null)
                throw new Exception("发送缓冲池已用完,等待回收超时...");

            return tArgs;
        }

        private void InitializePool(int maxNumberOfConnections)
        {
            if(sendTokenManager!=null) sendTokenManager.Clear();
            if (sBufferManager != null) sBufferManager.Clear();
            int cnt = maxNumberOfConnections + offsetNumber;

            sendTokenManager = new SocketTokenManager<SocketAsyncEventArgs>(cnt);
            sBufferManager = new SocketBufferManager(cnt, receiveChunkSize);

            for (int i = 1; i <=cnt; ++i)
            {
                SocketAsyncEventArgs tArgs = new SocketAsyncEventArgs() {
                    DisconnectReuseSocket=true
                };
                tArgs.Completed +=  IO_Completed;
                tArgs.UserToken = new SocketToken(i)
                {
                    TokenSocket = socket,
                    TokenId = i
                };
                sBufferManager.SetBuffer(tArgs);
                sendTokenManager.Set(tArgs);
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
                        sToken.TokenIpEndPoint = (IPEndPoint)e.RemoteEndPoint;

                        SentCallback(new SegmentToken(sToken, e.Buffer, e.Offset, e.BytesTransferred));
                    }
                }
                else
                {
                    ProcessDisconnectAsync(e);
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

        private void ProcessReceiveCallback(SocketAsyncEventArgs e)
        {
            if (e.BytesTransferred == 0
                || e.SocketError != SocketError.Success
                || e.AcceptSocket.Connected == false)
            {
                ProcessDisconnectAsync(e);
                return;
            }
            SocketToken sToken = e.UserToken as SocketToken;
            sToken.TokenIpEndPoint = (IPEndPoint)e.RemoteEndPoint;

            if (ReceivedOffsetCallback != null)
                ReceivedOffsetCallback(new SegmentToken(sToken, e.Buffer, e.Offset, e.BytesTransferred));

            if (RecievedCallback != null)
            {
                RecievedCallback(sToken, encoding.GetString(e.Buffer, e.Offset, e.BytesTransferred));
            }
            if (socket.Connected)
            {
                if (!e.AcceptSocket.ReceiveAsync(e))
                {
                    ProcessReceiveCallback(e);
                }
            }
        }

        private void ProcessConnectCallback(SocketAsyncEventArgs e)
        {
            try
            {
                isConnected = (e.SocketError == SocketError.Success);
                if (isConnected)
                {
                    using (LockWait lwait = new LockWait(ref lParam))
                    {
                        InitializePool(bufferNumber);
                    }
                    e.SetBuffer(receiveBuffer, 0, receiveChunkSize);
                    if (ConnectedCallback != null)
                    {
                        SocketToken sToken = e.UserToken as SocketToken;
                        sToken.TokenIpEndPoint = (IPEndPoint)e.RemoteEndPoint;
                        ConnectedCallback(sToken, isConnected);
                    }

                    if (!e.AcceptSocket.ReceiveAsync(e))
                    {
                        ProcessReceiveCallback(e);
                    }
                }
                else
                {
                    ProcessDisconnectAsync(e);
                }
                if (channelProviderState == ChannelProviderType.AsyncWait)
                    mReset.Set();
            }
            catch(Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.TargetSite.Name + ex.Message);
#endif
            }
        }

        private void ProcessDisconnectCallback(SocketAsyncEventArgs e)
        {
            try
            {
                isConnected = (e.SocketError == SocketError.Success);
                if (isConnected)
                {
                    Close();
                }

                if (DisconnectedCallback != null)
                {
                    SocketToken sToken = e.UserToken as SocketToken;
                    sToken.TokenIpEndPoint = (IPEndPoint)e.RemoteEndPoint;
                    DisconnectedCallback(sToken);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ProcessDisconnectAsync(SocketAsyncEventArgs e)
        {
            try
            {
                if (e.AcceptSocket == null) return;

                bool willRaiseEvent = false;
                if (e.AcceptSocket != null && e.AcceptSocket.Connected)
                    willRaiseEvent = e.AcceptSocket.DisconnectAsync(e);

                if (!willRaiseEvent)
                {
                    ProcessDisconnectCallback(e);
                }
                else
                {
                    Close();
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.TargetSite.Name+ex.Message);
#endif
            }
        }

        void IO_Completed(object sender, SocketAsyncEventArgs e)
        {
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Send:
                    ProcessSentCallback(e);
                    break;
                case SocketAsyncOperation.Receive:
                    ProcessReceiveCallback(e);
                    break;
                case SocketAsyncOperation.Connect:
                    ProcessConnectCallback(e);
                    break;
                case SocketAsyncOperation.Disconnect:
                    ProcessDisconnectCallback(e);
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}