using System;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Text;

namespace IFramework.Net.Udp
{
    internal class UdpClientProvider : UdpSocket, IDisposable, IUdpClientProvider
    {
        #region 定义变量
        private bool _isDisposed = false;
        private int bufferSizeByConnection = 4096;
        private int maxNumberOfConnections = 64;
        private Encoding encoding = Encoding.UTF8;

        private LockParam lParam = new LockParam();
        private ManualResetEvent mReset = new ManualResetEvent(false);
        private SocketTokenManager<SocketAsyncEventArgs> sendTokenManager = null;
        private SocketBufferManager sendBufferManager = null;

        #endregion

        #region 属性
        public int SendBufferPoolNumber { get { return sendTokenManager.Count; } }

        /// <summary>
        /// 接收回调处理
        /// </summary>
        public OnReceivedHandler ReceivedCallbackHandler { get; set; }

        /// <summary>
        /// 发送回调处理
        /// </summary>
        public OnSentHandler SentCallbackHandler { get; set; }
        /// <summary>
        /// 接收缓冲区回调
        /// </summary>
        public OnReceivedSegmentHandler ReceivedOffsetHandler { get; set; }
        #endregion

        #region public method
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
            sendTokenManager.ClearToCloseArgs();
            if (sendBufferManager != null)
            {
                sendBufferManager.Clear();
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public UdpClientProvider(int bufferSizeByConnection, int maxNumberOfConnections)
            :base(bufferSizeByConnection)
        {
            this.maxNumberOfConnections = maxNumberOfConnections;
            this.bufferSizeByConnection = bufferSizeByConnection;
        }

        public void Disconnect()
        {
            Close();
            isConnected = false;
        }

        /// <summary>
        /// 尝试连接
        /// </summary>
        /// <param name="port"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public bool Connect(int port, string ip)
        {
            Close();

            CreateUdpSocket(port,IPAddress.Parse(ip));

            Initialize();
            return true;
        }

 
        public bool Send(SegmentOffset sendSegment, bool waiting = true)
        {
            try
            {
                bool isWillEvent = true;
                ArraySegment<byte>[] segItems = sendBufferManager.BufferToSegments(sendSegment.buffer, sendSegment.offset, sendSegment.size);
                foreach (var seg in segItems)
                {
                    SocketAsyncEventArgs tArgs = sendTokenManager.GetEmptyWait((retry) =>
                    {
                        return true;
                    }, waiting);

                    if (tArgs == null)
                        throw new Exception("发送缓冲池已用完,等待回收...");

                    tArgs.RemoteEndPoint = ipEndPoint;

                    if (!sendBufferManager.WriteBuffer(tArgs, seg.Array, seg.Offset, seg.Count))
                    {
                        sendTokenManager.Set(tArgs);

                        throw new Exception(string.Format("发送缓冲区溢出...buffer block max size:{0}", sendBufferManager.BlockSize));
                    }

                    isWillEvent &= socket.SendToAsync(tArgs);
                    if (!isWillEvent)
                    {
                        ProcessSent(tArgs);
                    }
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
        /// 同步发送
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="recAct"></param>
        /// <param name="recBufferSize"></param>
        /// <returns></returns>
        public int SendSync(SegmentOffset sendSegment, SegmentOffset receiveSegment)
        {
            int sent = socket.SendTo(sendSegment.buffer, sendSegment.offset, sendSegment.size, 0, ipEndPoint);
            if (receiveSegment == null
                || receiveSegment.buffer == null
                || receiveSegment.size == 0) return sent;

            int cnt = socket.ReceiveFrom(receiveSegment.buffer,
                receiveSegment.size,
                SocketFlags.None,
                ref ipEndPoint);

            return sent;
        }

        /// <summary>
        /// 同步接收
        /// </summary>
        /// <param name="recAct"></param>
        /// <param name="recBufferSize"></param>
        public void ReceiveSync(SegmentOffset receiveSegment, Action<SegmentOffset> receiveAction)
        {
            int cnt = 0;
            do
            {
                cnt = socket.ReceiveFrom(receiveSegment.buffer,
                    receiveSegment.size,
                    SocketFlags.None,
                    ref ipEndPoint);

                if (cnt <= 0) break;

                receiveAction(receiveSegment);
            } while (true);
        }

        /// <summary>
        /// 开始接收数据
        /// </summary>
        /// <param name="remoteEP"></param>
        public void StartReceive()
        {
            using (LockWait lwait = new LockWait(ref lParam))
            {
                SocketAsyncEventArgs sArgs = new SocketAsyncEventArgs();
                sArgs.Completed += IO_Completed;
                sArgs.UserToken = socket;
                sArgs.RemoteEndPoint = ipEndPoint;
                sArgs.AcceptSocket = socket;
                sArgs.SetBuffer(receiveBuffer, 0, bufferSizeByConnection);
                bool isAsync = socket.ReceiveFromAsync(sArgs);

                if (!isAsync)
                {
                    ProcessReceive(sArgs);
                }
            }
        }

        #endregion

        #region private method
        /// <summary>
        /// 初始化对象
        /// </summary>
        /// <param name="recBufferSize"></param>
        /// <param name="port"></param>
        private void Initialize()
        {
            sendTokenManager = new SocketTokenManager<SocketAsyncEventArgs>(maxNumberOfConnections);
            sendBufferManager = new SocketBufferManager(maxNumberOfConnections, bufferSizeByConnection);

            //初始化发送接收对象池
            for (int i = 0; i < maxNumberOfConnections; ++i)
            {
                SocketAsyncEventArgs sendArgs = new SocketAsyncEventArgs();
                sendArgs.Completed += IO_Completed;
                sendArgs.UserToken = socket;

                sendBufferManager.SetBuffer(sendArgs);
                sendTokenManager.Set(sendArgs);
            }
        }

        private void Close()
        {
            if (socket != null)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                socket.Dispose();

                isConnected = false;
            }
        }

        private void ProcessReceive(SocketAsyncEventArgs e)
        {

            SocketToken sToken = new SocketToken()
            {
                TokenSocket = e.AcceptSocket as Socket,
                TokenIpEndPoint = (IPEndPoint)e.RemoteEndPoint
            };

            try
            {
                if (e.SocketError != SocketError.Success || e.BytesTransferred == 0)
                    return;

                //缓冲区偏移量返回
                if (ReceivedOffsetHandler != null)
                    ReceivedOffsetHandler(new SegmentToken(sToken, e.Buffer, e.Offset, e.BytesTransferred));

                //截取后返回
                if (ReceivedCallbackHandler != null)
                {
                    ReceivedCallbackHandler(sToken, encoding.GetString(e.Buffer, e.Offset, e.BytesTransferred));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (e.SocketError == SocketError.Success)
                {
                    //继续下一个接收
                    if (!socket.ReceiveFromAsync(e))
                    {
                        ProcessReceive(e);
                    }
                }
            }
        }

        private void ProcessSent(SocketAsyncEventArgs e)
        {
            try
            {
                bool isSuccess = e.SocketError == SocketError.Success;

                if (isConnected == false && isSuccess)
                {

                    StartReceive();

                    isConnected = true;
                }

                if (SentCallbackHandler != null)
                {
                    SocketToken sToken = new SocketToken()
                    {
                        TokenSocket = e.UserToken as Socket,
                        TokenIpEndPoint = (IPEndPoint)e.RemoteEndPoint
                    };
                    SentCallbackHandler(new SegmentToken( sToken, e.Buffer, e.Offset, e.BytesTransferred));
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

        void IO_Completed(object sender, SocketAsyncEventArgs e)
        {
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Receive:
                case SocketAsyncOperation.ReceiveFrom:
                case SocketAsyncOperation.ReceiveMessageFrom:
                    ProcessReceive(e);
                    break;
                case SocketAsyncOperation.SendTo:
                    ProcessSent(e);
                    break;
            }
        }
        #endregion
    }
} 