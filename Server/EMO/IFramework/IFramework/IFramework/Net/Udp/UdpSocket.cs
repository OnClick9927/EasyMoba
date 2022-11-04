
using System;
using System.Net;
using System.Net.Sockets;

namespace IFramework.Net.Udp
{
    internal class UdpSocket
    {
        internal Socket socket = null;
        internal bool Broadcast = false;
        protected bool isConnected = false;
        protected EndPoint ipEndPoint = null;

        protected byte[] receiveBuffer = null;
        protected int receiveChunkSize = 4096;
        protected int receiveTimeout = 1000 * 60 * 30;
        protected int sendTimeout = 1000 * 60 * 30;

        public UdpSocket(int size,bool Broadcast=false) 
        {
            this.receiveChunkSize = size;
            this.receiveBuffer = new byte[size];

            this.Broadcast = Broadcast;
        }


        protected void SafeClose()
        {
            if (socket == null) return;

            if (socket.Connected)
            {
                try
                {
                    socket.Disconnect(true);
                    socket.Shutdown(SocketShutdown.Send);
                }
                catch (ObjectDisposedException)
                {
                    return;
                }
                catch
                { }
            }
 
            try
            {
                socket.Close();
                socket.Dispose();
            }
            catch
            { }
        }

        public void CreateUdpSocket(int port, IPAddress ip)
        {
            if (Broadcast) ipEndPoint = new IPEndPoint(IPAddress.Broadcast, port);
            else ipEndPoint = new IPEndPoint(ip, port);

            socket = new Socket(ipEndPoint.AddressFamily, SocketType.Dgram, ProtocolType.Udp)
            {
                ReceiveTimeout = receiveTimeout,
                SendTimeout = sendTimeout
            };

#if UDP_SOCKET_OPTION
            //https://docs.microsoft.com/zh-cn/dotnet/api/system.net.sockets.socket.setsocketoption?redirectedfrom=MSDN&view=netframework-4.7.2
            if (Broadcast)
            {
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
            }
            else
                socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.IPOptions, true);
#endif
        }
    }
}
