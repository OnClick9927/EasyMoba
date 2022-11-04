using System.Net;
using System;
namespace IFramework.Net.Udp
{
    public interface IUdpServerProvider:IDisposable
    {
        OnDisconnectedHandler DisconnectedCallbackHandler { get; set; }
        OnReceivedHandler ReceivedCallbackHandler { get; set; }
        OnReceivedSegmentHandler ReceivedOffsetHanlder { get; set; }
        OnSentHandler SentCallbackHandler { get; set; }

        bool Send(SegmentOffset dataSegment, IPEndPoint remoteEP, bool waiting = true);
        int SendSync(IPEndPoint remoteEP, SegmentOffset dataSegment);
        void Start(int port);
        void Stop();
    }
}