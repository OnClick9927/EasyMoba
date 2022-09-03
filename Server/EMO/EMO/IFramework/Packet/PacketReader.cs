/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2017.2.3p3
 *Date:           2019-03-14
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System.Collections.Generic;

namespace IFramework.Packets
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
    public class PacketReader
    {
        private PacketQueue packetQueue;
        private object _lock = new object();
        public int count { get { return packetQueue.count; } }
        public PacketReader(int capacity = 128)
        {
            if (capacity < 128) capacity = 128;
            capacity += 1;
            packetQueue = new PacketQueue(capacity);
        }
        public bool Set(byte[] buff, int offset, int size)
        {
            lock (_lock)
            {
                return packetQueue.Set(buff, offset, size);
            }

        }
        public List<Packet> Get()
        {
            lock (_lock)
            {
                return packetQueue.Get();
            }
        }
        public void Clear()
        {
            lock (_lock)
            {
                packetQueue.Clear();
            }
        }
    }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
}
