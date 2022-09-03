using System;

namespace IFramework.Net.Tcp
{
    public interface ITcpClientProvider:IDisposable
    {
        ChannelProviderType ChannelProviderState { get; }
        int SendBufferPoolNumber { get; }

        bool IsConnected { get; }
        OnConnectedHandler ConnectedCallback { get; set; }
        OnDisconnectedHandler DisconnectedCallback { get; set; }
        OnReceivedSegmentHandler ReceivedOffsetCallback { get; set; }
        OnReceivedHandler RecievedCallback { get; set; }
        OnSentHandler SentCallback { get; set; }

        void Connect(int port, string ip);
        bool ConnectSync(int port, string ip);
        bool ConnectTo(int port, string ip);
        void Disconnect();
        void ReceiveSync(SegmentOffset receiveSegment, Action<SegmentOffset> receivedAction);
        bool Send(SegmentOffset sendSegment, bool waiting = true);
        //void SendFile(string filename);
        int SendSync(SegmentOffset sendSegment, SegmentOffset receiveSegment);
    }
}