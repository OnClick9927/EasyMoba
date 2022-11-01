using System.IO;
using IFramework.Net.Tcp;

namespace IFramework.Net.Http
{
    public delegate void HttpOnReceived(HttpPayload payload);

    internal class HttpServer : IHttpServerProvider
    {
        private ITcpServerProvider sProvider = null;

        public HttpOnReceived hOnReceived { get; set; }

        public int Port { get; private set; }

        public HttpServer(int maxPoolCount = 64, int blockSize = 4096)
        {
            sProvider = NetTool.CreateTcpSever(blockSize, maxPoolCount);
            sProvider.DisconnectedCallback = new OnDisconnectedHandler(OnDisconnected);
            sProvider.ReceivedOffsetCallback = new OnReceivedSegmentHandler(OnReceived);
            sProvider.AcceptedCallback = new OnAcceptedHandler(OnAccepted);
        }

        public bool Start(int port = 80)
        {
            this.Port = port;
            bool isOk = sProvider.Start(port);
            return isOk;
        }

        public bool Send(SocketToken sToken,byte[] data)
        {
          return  sProvider.Send(new SegmentToken(sToken, data));
        }

        public bool Send(SegmentToken segment)
        {
            return sProvider.Send(segment);
        }

        public void Disconnect(SocketToken sToken)
        {
            sProvider.Close(sToken);
        }

        private void OnReceived(SegmentToken sToken)
        {
            if (hOnReceived != null)
            {
                HttpHeader header = new HttpHeader(sToken.Data);
                switch (header.Option)
                {
                    case HttpOption.GET:
                        hOnReceived(new HttpGet(header).GetDo(sToken));
                        break;
                    case HttpOption.POST:
                        hOnReceived(new HttpPost(header).GetDo(sToken));
                        break;
                }
            }
        }

        private void OnAccepted(SocketToken sToken)
        {

        }

        private void OnDisconnected(SocketToken sToken)
        {

        }
    }

    public class HttpPayload
    {
        public SocketToken Token { get; set; }

        public HttpHeader Header { get; set; }

        public HttpUri HttpUri { get; set; }

        public Stream stream { get; set; }
    }
}