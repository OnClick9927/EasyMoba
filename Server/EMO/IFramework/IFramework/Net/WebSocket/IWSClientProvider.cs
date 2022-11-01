using System;

namespace IFramework.Net.WebSocket
{
    public interface IWSClientProvider:IDisposable
    {
        bool IsConnected { get; }
        OnConnectedHandler OnConnected { get; set; }
        OnDisconnectedHandler OnDisconnected { get; set; }
        OnReceivedHandler OnReceived { get; set; }
        OnReceivedSegmentHandler OnReceivedBytes { get; set; }
        OnSentHandler OnSent { get; set; }

        bool Connect(string wsUrl);
        bool Connect(WSConnectionItem wsUrl);
        bool Send(SegmentOffset data, bool waiting = true);
        bool Send(string msg, bool waiting = true);
        void SendPing();
        void SendPong(SegmentOffset buf);
    }
}