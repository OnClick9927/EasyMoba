using IFramework.Packets;
using System.Collections.Generic;

namespace IFramework.Net
{
    public interface INetPacketProvider
    {
        int Count { get; }
        bool SetBlocks(byte[] buffer, int offset, int size);

        List<Packet> GetBlocks();
        void Clear();
    }
}
