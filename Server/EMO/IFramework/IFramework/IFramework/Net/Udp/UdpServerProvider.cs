using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace IFramework.Net.Udp
{
    internal class UdpServerProvider : UdpSocket, IDisposable, IUdpServerProvider
    {
        #region variable
        private SocketReceive socketRecieve = null;
        private SocketSend socketSend = null;
        private bool _isDisposed = false;
        private Encoding encoding = Encoding.UTF8;

        private int bufferSizeByConnection = 4096;
        private int maxNumberOfConnections = 8;

        #endregion

        #region property

        public OnReceivedSegmentHandler ReceivedOffsetHanlder { get; set; }

        /// <summary>
        /// 接收事件响应回调
        /// </summary>
        public OnReceivedHandler ReceivedCallbackHandler { get; set; }

        /// <summary>
        /// 发送事件响应回调
        /// </summary>
        public OnSentHandler SentCallbackHandler { get; set; }

        /// <summary>
        /// 断开连接事件回调
        /// </summary>
        public OnDisconnectedHandler DisconnectedCallbackHandler { get; set; }

        #endregion

        #region structure
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
                socketRecieve.Dispose();
                socketSend.Dispose();
                _isDisposed = true;
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public UdpServerProvider( int maxNumberOfConnections,int bufferSizeByConnection,bool Broadcast=false)
            :base(bufferSizeByConnection,Broadcast)
        {
            this.bufferSizeByConnection = bufferSizeByConnection;
            this.maxNumberOfConnections = maxNumberOfConnections;
        }

        #endregion

        #region public method
        /// <summary>
        /// 启动服务
        /// </summary>
        /// <param name="port">接收数据端口</param>
        /// <param name="recBufferSize">接收缓冲区</param>
        /// <param name="maxConnectionCount">最大客户端连接数</param>
        public void Start(int port)
        {
            socketRecieve = new SocketReceive(port,  bufferSizeByConnection,
                Broadcast);

            socketRecieve.OnReceived += receiveSocket_OnReceived;
            socketRecieve.StartReceive();

            socketSend = new SocketSend(socketRecieve.socket, maxNumberOfConnections, bufferSizeByConnection);
            socketSend.SentEventHandler += sendSocket_SentEventHandler;
        }

        /// <summary>
        /// 停止服务
        /// </summary>
        public void Stop()
        {
            if (socketSend != null)
            {
                socketSend.Dispose();
            }
            if (socketRecieve != null)
            {
                socketRecieve.StopReceive();
            }
        }
 
        public bool Send(SegmentOffset dataSegment,IPEndPoint remoteEP ,bool waiting = true)
        {
            return socketSend.Send(dataSegment, remoteEP, waiting);
        }
 
        public int SendSync(IPEndPoint remoteEP, SegmentOffset dataSegment)
        {
            return socketSend.SendSync(dataSegment , remoteEP);
        }
        #endregion

        #region private method
        private void sendSocket_SentEventHandler(object sender, SocketAsyncEventArgs e)
        {
            if (SentCallbackHandler != null)
            {
                SentCallbackHandler(new SegmentToken(new SocketToken()
                {
                    TokenIpEndPoint = (IPEndPoint)e.RemoteEndPoint
                }, e.Buffer, e.Offset, e.BytesTransferred));
            }
        }

        private void receiveSocket_OnReceived(object sender, SocketAsyncEventArgs e)
        {
            SocketToken sToken = new SocketToken()
            {
                TokenIpEndPoint = (IPEndPoint)e.RemoteEndPoint
            };

            if (ReceivedOffsetHanlder != null)
                ReceivedOffsetHanlder(new SegmentToken(sToken, e.Buffer, e.Offset, e.BytesTransferred));

            if (ReceivedCallbackHandler != null
                && e.BytesTransferred > 0)
            {
                ReceivedCallbackHandler(sToken, encoding.GetString(e.Buffer, e.Offset, e.BytesTransferred));
            }
        }

        #endregion
    }
} 