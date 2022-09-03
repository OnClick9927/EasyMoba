using System;
using System.Net;
using System.Net.Sockets;

namespace IFramework.Net.KCP
{
    public class KcpSocket : IKcpSocket
    {
        public event Action<byte[], int, int> onMessage;
        public IPEndPoint remotePoint;
        public IPEndPoint localPoint;
        private UdpClient _udp;

        public Socket socket { get { return _udp.Client; } }

        public void Close()
        {
            if (_udp != null)
            {
                _udp.Close();
                _udp = null;
            }
        }

        public void Connect(string host, int port)
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(host);
            if (hostEntry.AddressList.Length == 0)
            {
                Log.E("Unable to resolve host: " + host);
                return;
            }
            var endpoint = hostEntry.AddressList[0];
   
            _udp = new UdpClient(endpoint.AddressFamily);
            _udp.Connect(host, port);

            remotePoint = (IPEndPoint)_udp.Client.RemoteEndPoint;
            localPoint = (IPEndPoint)_udp.Client.LocalEndPoint;
            Recv();
        }

        private void Recv()
        {
            if (_udp == null) return;
            _udp.BeginReceive(EndRecv, _udp);
        }
        private void EndRecv(IAsyncResult ar)
        {
            try
            {
                var bytes=  _udp.EndReceive(ar, ref remotePoint);
                if (bytes.Length>0)
                {
                    if (onMessage!=null)
                    {
                        onMessage(bytes, 0, bytes.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
            }
            finally
            {
                Recv();
            }
        }

        public void Send(byte[] buffer, int length)
        {
            if (_udp != null)
            {
                try
                {
                    _udp.Send(buffer, length);
                }
                catch (Exception ex)
                {
                    Log.Exception(ex);
                }
               
            }
        }
    }
}
