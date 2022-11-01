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
    class PacketQueue
    {
        private CycQueue<byte> _bucket = null;
        public PacketQueue(int maxCount)
        {
            _bucket = new CycQueue<byte>(maxCount);
        }
        public int count { get { return _bucket.Length; } }
        public bool Set(byte[] buffer, int offset, int size)
        {
            if (_bucket.Capacity - _bucket.Length < size)
                return false;
            for (int i = 0; i < size; ++i)
            {
                bool rt = _bucket.EnQueue(buffer[i + offset]);
                if (rt == false)
                    return false;
            }
            return true;
        }
        public List<Packet> Get()
        {
            int _head = -1, _pos = 0;
            List<Packet> pkgs = null;
        again:
            _head = _bucket.DeSearchIndex(Packet.packFlag, _pos);
            if (_head == -1) return pkgs;
            int peek = _bucket.PeekIndex(Packet.packFlag, 1);
            if (peek >= 0)
            {
                _pos = 1;
                goto again;
            }
            //数据包长度
            int pkgLength = CheckCompletePackageLength(_bucket.Array, _head);
            if (pkgLength == 0) return pkgs;
            //读取完整包并移出队列
            byte[] array = _bucket.DeQueue(pkgLength);
            if (array == null) return pkgs;
            Packet _pkg = Packet.UnPackPacket(array, 0, array.Length);
            //解析
            if (_pkg != null)
            {
                if (pkgs == null) pkgs = new List<Packet>(2);
                pkgs.Add(_pkg);
            }
            if (_bucket.Length > 0)
            {
                _pos = 0;
                goto again;
            }
            return pkgs;
        }
        private unsafe int CheckCompletePackageLength(byte[] buff, int offset)
        {
            fixed (byte* src = buff)
            {
                int head = offset;
                int cnt = 0;
                byte flag = 0;
                do
                {
                    if (*(src + head) == Packet.packFlag)
                    {
                        ++flag;
                        if (flag == 2) return cnt + 1;
                    }
                    head = (head + 1) % _bucket.Capacity;
                    ++cnt;
                }
                while (cnt <= _bucket.Length);
                cnt = 0;
                return cnt;
            }
        }
        public void Clear()
        {
            _bucket.Clear();
        }
    }

}
