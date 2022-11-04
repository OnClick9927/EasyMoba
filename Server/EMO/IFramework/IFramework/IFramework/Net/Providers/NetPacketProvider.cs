using IFramework.Packets;
using System.Collections.Generic;

namespace IFramework.Net
{
    internal class NetPacketProvider:INetPacketProvider
    {
        private PacketReader packetQueue = null;
        LockParam lockParam = null;

        public NetPacketProvider(int capacity)
        {
            if (capacity < 128) capacity = 128;
            capacity += 1;
            packetQueue = new PacketReader(capacity);
            lockParam = new LockParam();
        }

        public static NetPacketProvider CreateProvider(int capacity)
        {
            return new NetPacketProvider(capacity);
        }

        public int Count
        {
            get
            {
                return packetQueue.count;
            }
        }

        public bool SetBlocks(byte[] bufffer,int offset,int size)
        {
            using (LockWait lwait = new LockWait(ref lockParam))
            {
                return packetQueue.Set(bufffer, offset, size);
            }
        }

        public List<Packet> GetBlocks()
        {
            using (LockWait lwait = new LockWait(ref lockParam))
            {
                return packetQueue.Get();
            }
        }


        public void Clear()
        {
            using (LockWait lwait = new LockWait(ref lockParam))
            {
                  packetQueue.Clear();
            }
        }
    }
}
