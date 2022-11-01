using System.Net;
using System;
using System.Net.Sockets;

namespace IFramework.Net.Udp
{
    internal class SocketReceive : UdpSocket, IDisposable
    {
        #region variable
        private SocketAsyncEventArgs recArgs = null;
        private bool isStoped = false;
        private bool _isDisposed = false;

        /// <summary>
        /// 接收事件
        /// </summary>
        public event EventHandler<SocketAsyncEventArgs> OnReceived;

        #endregion

        #region structure
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="port">本机接收数据端口</param>
        /// <param name="bufferSize">接收缓冲区大小</param>
        public SocketReceive(int port, int bufferSize = 4096,
            bool Broadcast = false)
            : base(bufferSize, Broadcast)
        {
            CreateUdpSocket(port, IPAddress.Any);
            socket.Bind(ipEndPoint);

            recArgs = new SocketAsyncEventArgs();

            recArgs.UserToken = socket;
            recArgs.RemoteEndPoint = socket.LocalEndPoint;
            recArgs.Completed += SocketArgs_Completed;
            recArgs.SetBuffer(receiveBuffer, 0, receiveChunkSize);
        }

        public SocketReceive(Socket socket, int bufferSize = 4096)
            : base(bufferSize)
        {
            this.socket = socket;
            recArgs = new SocketAsyncEventArgs();

            recArgs.UserToken = socket;
            recArgs.RemoteEndPoint = socket.LocalEndPoint;
            recArgs.Completed += SocketArgs_Completed;
            recArgs.SetBuffer(receiveBuffer, 0, receiveChunkSize);
        }

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
                isStoped = true;
                _isDisposed = true;
                socket.Dispose();
                recArgs.Dispose();
            }
        }
        #endregion

        #region public


        /// <summary>
        /// 开始接收数据
        /// </summary>
        public void StartReceive()
        {
            bool rt = socket.ReceiveFromAsync(recArgs);
            if (rt == false)
            {
                ProcessReceive(recArgs);
            }
        }

        /// <summary>
        /// 停止接收数据
        /// </summary>
        public void StopReceive()
        {
            isStoped = true;
            socket.Dispose();
            if (recArgs != null)
            {
                recArgs.Dispose();
            }
        }
        #endregion

        #region private

        /// <summary>
        /// 接收完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SocketArgs_Completed(object sender, SocketAsyncEventArgs e)
        {
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.ReceiveFrom:
                    this.ProcessReceive(e);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 处理接收信息
        /// </summary>
        /// <param name="arg"></param>
        private void ProcessReceive(SocketAsyncEventArgs arg)
        {
            // receivePool.Set(args);
            if (arg.BytesTransferred > 0
                && arg.SocketError == SocketError.Success)
            {
                if (OnReceived != null)
                {
                    OnReceived(arg.UserToken as Socket, arg);
                }
            }

            if (isStoped) return;

            StartReceive();
        }

        #endregion
    }
} 