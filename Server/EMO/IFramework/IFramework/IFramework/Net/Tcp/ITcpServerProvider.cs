using System;

namespace IFramework.Net.Tcp
{
    public interface ITcpServerProvider : IDisposable
    {
        OnAcceptedHandler AcceptedCallback { get; set; }
        OnDisconnectedHandler DisconnectedCallback { get; set; }
        OnReceivedHandler ReceivedCallback { get; set; }
        OnReceivedSegmentHandler ReceivedOffsetCallback { get; set; }
        OnSentHandler SentCallback { get; set; }
        int NumberOfConnections { get; }

        void Close(SocketToken sToken);
        bool Start(int port, string ip = "0.0.0.0");
        void Stop();
        bool Send(SegmentToken segToken, bool waiting = true);
        int SendSync(SegmentToken segToken);
    }
}