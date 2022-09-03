using System;

namespace IFramework.Net.Udp
{
    public interface IUdpClientProvider:IDisposable
    {
        OnReceivedHandler ReceivedCallbackHandler { get; set; }
        OnReceivedSegmentHandler ReceivedOffsetHandler { get; set; }
        int SendBufferPoolNumber { get; }
        OnSentHandler SentCallbackHandler { get; set; }

        bool Connect(int port, string ip);
        void Disconnect();
        void ReceiveSync(SegmentOffset receiveSegment, Action<SegmentOffset> receiveAction);
        bool Send(SegmentOffset sendSegment, bool waiting = true);
        int SendSync(SegmentOffset sendSegment, SegmentOffset receiveSegment);
        void StartReceive();
    }
}