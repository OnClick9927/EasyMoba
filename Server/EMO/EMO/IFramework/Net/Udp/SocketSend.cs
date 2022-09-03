using System.Net;
using System;
using System.Net.Sockets;
using System.Threading;

namespace IFramework.Net.Udp
{
    internal class SocketSend : UdpSocket,IDisposable
    {
        #region variable
        private int maxCount = 0;
 
        private SocketTokenManager<SocketAsyncEventArgs> sendTokenManager = null;
        private SocketBufferManager sendBufferManager = null;
        private bool _isDisposed = false;

        #endregion

        #region structure
        /// <summary>
        /// 发送事件回调
        /// </summary>
        public event EventHandler<SocketAsyncEventArgs> SentEventHandler;

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
                socket.Dispose();
                sendBufferManager.Clear();
                _isDisposed = true;
            }
        }
        #endregion

        #region public method 
        /// <summary>
        /// 初始化发送对象
        /// </summary>
        /// <param name="maxCountClient">客户端最大数</param>
        public SocketSend(int maxCountClient, int blockSize = 4096)
            : base(blockSize)
        {
            this.maxCount = maxCountClient;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.ReceiveTimeout = receiveTimeout;
            socket.SendTimeout = sendTimeout;

            sendTokenManager = new SocketTokenManager<SocketAsyncEventArgs>(maxCountClient);
            sendBufferManager = new SocketBufferManager(maxCountClient, blockSize);

            for (int i = 0; i < maxCount; ++i)
            {
                SocketAsyncEventArgs socketArgs = new SocketAsyncEventArgs
                {
                   UserToken = socket
                };
                socketArgs.Completed += ClientSocket_Completed;
                sendBufferManager.SetBuffer(socketArgs);
                sendTokenManager.Set(socketArgs);
            }
        }

        public SocketSend(Socket socket, int maxCountClient, int blockSize = 4096)
          : base(blockSize)
        {
            this.maxCount = maxCountClient;
            base.socket = socket;

            sendTokenManager = new SocketTokenManager<SocketAsyncEventArgs>(maxCountClient);
            sendBufferManager = new SocketBufferManager(maxCountClient, blockSize);

            for (int i = 0; i < maxCount; ++i)
            {
                SocketAsyncEventArgs socketArgs = new SocketAsyncEventArgs
                {
                    UserToken = base.socket
                };
                socketArgs.Completed += ClientSocket_Completed;
                sendBufferManager.SetBuffer(socketArgs);
                sendTokenManager.Set(socketArgs);
            }
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <param name="waiting"></param>
        /// <param name="remoteEP"></param>
        public bool Send(SegmentOffset dataSegment, IPEndPoint remoteEP, bool waiting)
        {
            try
            {
                bool isWillEvent = true;

                ArraySegment<byte>[] segItems = sendBufferManager.BufferToSegments(dataSegment.buffer, dataSegment.offset, dataSegment.size);
                foreach (var seg in segItems)
                {
                    var tArgs = sendTokenManager.GetEmptyWait((retry) =>
                    {
                        return true;
                    }, waiting);

                    if (tArgs == null)
                        throw new Exception("发送缓冲池已用完,等待回收超时...");

                    tArgs.RemoteEndPoint = remoteEP;

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
                    Thread.Sleep(5);
                }
                return isWillEvent;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 同步发送数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <param name="remoteEP"></param>
        /// <returns></returns>
        public int SendSync(SegmentOffset dataSegment, IPEndPoint remoteEP)
        {
            return socket.SendTo(dataSegment.buffer, dataSegment.offset, dataSegment.size,
                SocketFlags.None, remoteEP);
        }

        #endregion

        #region private method
        /// <summary>
        /// 释放缓冲池
        /// </summary>
        private void DisposeSocketPool()
        {
            sendTokenManager.ClearToCloseArgs();
        }

        /// <summary>
        /// 处理发送的数据
        /// </summary>
        /// <param name="e"></param>
        private void ProcessSent(SocketAsyncEventArgs e)
        {
            sendTokenManager.Set(e);

            if (e.BytesTransferred > 0 && e.SocketError == SocketError.Success)
            {
                if (SentEventHandler != null)
                {
                    SentEventHandler(e.UserToken as Socket, e);
                }
            }
        }

        /// <summary>
        /// 完成发送事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ClientSocket_Completed(object sender, SocketAsyncEventArgs e)
        {
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.SendTo:
                case SocketAsyncOperation.SendPackets:
                case SocketAsyncOperation.Send:
                    ProcessSent(e);
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
} 