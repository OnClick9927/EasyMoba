
using System;
using System.Net.Sockets;
using System.Net;

namespace IFramework.Net.Tcp
{
    internal class TcpSocket
    {
        protected Socket socket = null;
        protected bool isConnected = false;
        protected EndPoint ipEndPoint = null;

        protected byte[] receiveBuffer = null;
        protected int receiveTimeout = 1000 * 60 * 30;
        protected int sendTimeout = 1000 * 60 * 30;
        protected int connectioTimeout = 1000 * 60 * 30;
        protected int receiveChunkSize = 4096;

        public TcpSocket(int size)
        {
            this.receiveChunkSize = size;
            receiveBuffer = new byte[size];
        }

        protected void CreateTcpSocket(int port,string ip)
        {
            ipEndPoint =  new IPEndPoint(IPAddress.Parse(ip), port);
            Socket socket = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
            {
                LingerState = new LingerOption(true, 0),
                NoDelay = true,
                ReceiveTimeout = receiveTimeout,
                SendTimeout = sendTimeout
            };
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            this.socket = socket;
        }

        protected void SafeClose()
        {
            if (socket == null) return;

            if (socket.Connected)
            {
                try
                {  
                    socket.Shutdown(SocketShutdown.Send);
                }
                catch (ObjectDisposedException)
                {
                    return;
                }
                catch (Exception ex)
                {
#if DEBUG
                    Console.WriteLine(ex.TargetSite.Name + ex.Message);
#endif
                }
            }

            try
            {
                socket.Close();
            }
            catch (Exception ex) {
#if DEBUG
                Console.WriteLine(ex.TargetSite.Name + ex.Message);
#endif
            }
        }

        protected void SafeClose(Socket s)
        {
            if (s == null) return;

            if (s.Connected)
            {
                try
                {
                    s.Shutdown(SocketShutdown.Send);
                }
                catch (ObjectDisposedException ex)
                {
#if DEBUG
                    Console.WriteLine(ex.TargetSite.Name + ex.Message);
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
            try
            {
                s.Close();
                //s.Dispose();
                s = null;
            }
            catch(Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex.TargetSite.Name + ex.Message);
#endif
            }
        }
    }
}
