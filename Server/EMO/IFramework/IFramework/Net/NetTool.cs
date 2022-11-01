using IFramework.Net.Tcp;
using IFramework.Net.Udp;
using IFramework.Net.Http;
using IFramework.Net.WebSocket;
using System.Net;
using System.Linq;
using System.Net.Sockets;

namespace IFramework.Net
{
    public static class NetTool
    {
        public static INetPacketProvider CreatePacketsProvider(int capacity=4096)
        {
            return NetPacketProvider.CreateProvider(capacity);
        }
        public static INetProtocolProvider CreateProtocolProvider()
        {
            return NetProtocolProvider.CreateProvider();
        }
        public static INetTokenPoolProvider CreateTokenPoolProvider(int taskExecutePeriod=60)
        {
            return NetTokenPoolProvider.CreateProvider(taskExecutePeriod);
        }


        public static ITcpClientProvider CreateTcpClient(int chunkBufferSize = 4096, int sendConcurrentSize = 8)
        {
            return new TcpClientProvider(chunkBufferSize, sendConcurrentSize);
        }
        public static ITcpServerProvider CreateTcpSever(int chunkBufferSize = 4096, int maxNumberOfConnections = 32)
        {
            return new TcpServerProvider(chunkBufferSize, maxNumberOfConnections);
        }
        public static IUdpClientProvider CreateUdpClient(int chunkBufferSize = 4096, int sendConcurrentSize = 8)
        {
            return new UdpClientProvider(chunkBufferSize, sendConcurrentSize);
        }
        public static IUdpServerProvider CreateUdpSever(int chunkBufferSize = 4096, int maxNumberOfConnections = 32,bool broadcast=false)
        {
            return new UdpServerProvider(chunkBufferSize, maxNumberOfConnections,broadcast);
        }
        public static IWSClientProvider CreateWSClient(int chunkBufferSize = 4096, int sendConcurrentSize = 8)
        {
            return new WSClientProvider(chunkBufferSize, sendConcurrentSize);
        }
        public static IWSServerProvider CreateWSSever(int chunkBufferSize = 4096, int maxNumberOfConnections = 32)
        {
            return new WSServerProvider(maxNumberOfConnections, chunkBufferSize);
        }
        public static IHttpServerProvider CreateHttpSever(int maxPoolCount = 64, int blockSize = 4096)
        {
            return new HttpServer( maxPoolCount ,blockSize);
        }





        public static IPAddress[] GetLoacalIpv4()
        {
            IPAddress[] addresses = Dns.GetHostAddresses("localhost");
            return (from x in addresses where x.AddressFamily == AddressFamily.InterNetwork select x).ToArray();
        }
        public static IPAddress[] GetLoacalIpv6()
        {
            IPAddress[] addresses = Dns.GetHostAddresses("localhost");
            return (from x in addresses where x.AddressFamily == AddressFamily.InterNetworkV6 select x).ToArray();
        }
        public static string GetOutSideIP()
        {
            using (WebClient wc = new WebClient())
            {
                return wc.DownloadString(@"http://icanhazip.com/").Replace("\n", "");
            }
        }
    }
}
