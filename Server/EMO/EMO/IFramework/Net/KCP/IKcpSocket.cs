using System;
using System.Net.Sockets;
namespace IFramework.Net.KCP
{
    public interface IKcpSocket
    {
        Socket socket { get; }
        void Send(byte[] buffer, int length);
        void Connect(string host, int port);
        void Close();
        event Action<byte[], int, int> onMessage;
    }
}
