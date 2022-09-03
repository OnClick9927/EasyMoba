using System.Net;
using System;
using System.Net.Sockets;

namespace IFramework.Net
{
    public class SocketToken : IDisposable, IComparable<SocketToken>
    {
        /// <summary>
        /// 会话编号
        /// </summary>
        public int TokenId { get; set; }

        /// <summary>
        /// 会话socket对象
        /// </summary>
        public Socket TokenSocket { get; set; }
        /// <summary>
        /// 会话的终结点
        /// </summary>
        public IPEndPoint TokenIpEndPoint { get; set; }

        internal SocketAsyncEventArgs TokenAgrs { get; set; }

        private bool _isDisposed = false;

        //析构
        ~SocketToken()
        {
            Dispose(false);
        }

        /// <summary>
        /// 构造
        /// </summary>
        public SocketToken(int id)
        {
            this.TokenId = id;
        }

        public SocketToken() { }

        /// <summary>
        /// 关闭该连接对象，释放相关资源,非完全释放Socket对象
        /// </summary>
        public void Close()
        {
            if (TokenSocket != null)
            {
                try
                {
                    TokenSocket.Shutdown(SocketShutdown.Send);
                }
                catch (ObjectDisposedException)
                { return; }
                catch { }
                TokenSocket.Close();
            }
        }

        /// <summary>
        /// 关闭该连接对象并释放该对象资源
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool SendAsync(SocketAsyncEventArgs args)
        {
            return TokenSocket.SendAsync(args);
        }

        public bool DisconnectAsync(SocketAsyncEventArgs args)
        {
            if (TokenSocket.Connected == false) return false;

            return TokenSocket.DisconnectAsync(args);
        }

        /// <summary>
        /// 根据SocketId比较大小
        /// </summary>
        /// <param name="sToken"></param>
        /// <returns></returns>
        public int CompareTo(SocketToken sToken)
        {
            return this.TokenId.CompareTo(sToken.TokenId);
        }

        public int Send(SegmentOffset dataSegment)
        {
           return this.TokenSocket.Send(dataSegment.buffer,
               dataSegment.offset, 
               dataSegment.size, 0);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="isDisposing"></param>
        protected virtual void Dispose(bool isDisposing)
        {
            if (_isDisposed) return;

            if (isDisposing)
            {
                TokenAgrs.Dispose();
                TokenSocket = null;
                _isDisposed = true;
            }
        }
    }
}