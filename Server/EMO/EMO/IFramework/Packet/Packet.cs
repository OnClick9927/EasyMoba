/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2017.2.3p3
 *Date:           2019-03-14
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

using System;

namespace IFramework.Packets
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
    public class Packet
    {
        private const int HelpBuffLen = 17;
        private static byte _packFlag = 0xfe;
        private static byte _subFlag = 0xfd;
        private PacketHeader _Head;

        public static byte packFlag
        {
            get { return _packFlag; }
        }

        public static byte subFlag
        {
            get { return _subFlag; }
        }

        public ushort pkgCount
        {
            get { return _Head.pkgCount; }
        }

        public byte pkgType
        {
            get { return _Head.pkgType; }
        }

        public UInt32 MainId
        {
            get { return _Head.MainId; }
        }
        public UInt32 SubId
        {
            get { return _Head.SubId; }
        }

        public byte[] message { get; private set; }

        public Packet()
        {
            _Head = new PacketHeader();
        }

        public Packet(ushort pkgCount, uint mainId, uint subId, byte pkgType, byte[] buffer) : this()
        {
            Config(pkgCount, mainId, subId, pkgType, buffer);
        }

        public void Config(ushort pkgCount, uint mainId, uint subId, byte pkgType, byte[] buffer)
        {
            _Head.pkgCount = pkgCount;
            _Head.MainId = mainId;
            _Head.SubId = subId;
            _Head.pkgType = pkgType;
            message = buffer;
        }

        public byte[] Pack()
        {
            int plen = message.Length;
            _Head.messageLen = (UInt32)plen;
            byte[] buffer = new byte[HelpBuffLen + plen];
            //int index = 0;
            buffer[0] = packFlag;
            buffer[1] = (byte)(_Head.MainId >> 24);//0
            buffer[2] = (byte)(_Head.MainId >> 16);
            buffer[3] = (byte)(_Head.MainId >> 8);
            buffer[4] = (byte)_Head.MainId;
            buffer[5] = (byte)(_Head.SubId >> 24);//4
            buffer[6] = (byte)(_Head.SubId >> 16);
            buffer[7] = (byte)(_Head.SubId >> 8);
            buffer[8] = (byte)_Head.SubId;
            buffer[9] = _Head.pkgType;            //8
            buffer[10] = (byte)(_Head.pkgCount >> 8);//9
            buffer[11] = (byte)_Head.pkgCount;
            buffer[12] = (byte)(_Head.messageLen >> 24);//11
            buffer[13] = (byte)(_Head.messageLen >> 16);
            buffer[14] = (byte)(_Head.messageLen >> 8);
            buffer[15] = (byte)(_Head.messageLen);
            Buffer.BlockCopy(message, 0, buffer, HelpBuffLen - 1, plen);
            buffer[buffer.Length - 1] = packFlag;
            return Escape(buffer);
        }

        private unsafe byte[] Escape(byte[] buffer)
        {
            int pktCnt = 0, subCnt = 0;
            /*var tCnt = */
            CheckEscapeFlagCount(buffer, out pktCnt, out subCnt);
            if ( /*(tCnt.Item1 + tCnt.Item2) == 0*/ pktCnt + subCnt == 0) return buffer;
            int plen = buffer.Length - 2;
            byte[] rBuffer = new byte[buffer.Length + pktCnt + subCnt /*tCnt.Item1 + tCnt.Item2*/];
            rBuffer[0] = buffer[0]; //起始标识位
            fixed (byte* dst = &(rBuffer[1]), src = &(buffer[1]))
            {
                byte* _dst = dst;
                byte* _src = src;
                //消息头和消息体
                while (plen > 0)
                {
                    if (*_src == packFlag)
                    {
                        *_dst = subFlag;
                        *(_dst + 1) = 0x01;
                        _dst += 2;
                    }
                    else if (*_src == subFlag)
                    {
                        *_dst = subFlag;
                        *(_dst + 1) = 0x02;
                        _dst += 2;
                    }
                    else
                    {
                        *_dst = *_src;
                        _dst += 1;
                    }

                    _src += 1;
                    plen -= 1;
                }

                //结束标志位
                *_dst = *_src;
                return rBuffer;
            }
        }

        private unsafe void CheckEscapeFlagCount(byte[] buffer, out int pktCnt, out int subCnt)
        {
            int len = buffer.Length - 2; //去头尾标识位
            /* int*/
            pktCnt = 0; /*,*/
            subCnt = 0;
            fixed (byte* src = &(buffer[1]))
            {
                byte* _src = src;
                do
                {
                    if (*_src == packFlag)
                    {
                        ++pktCnt;
                    }
                    else if (*_src == subFlag)
                    {
                        ++subCnt;
                    }

                    _src += 1;
                    --len;
                } while (len > 0);
            }
            // return Tuple.Create(pktCnt, subCnt);
        }

        public static Packet UnPackPacket(byte[] buffer, int offset, int size)
        {
            if (buffer.Length < HelpBuffLen || buffer.Length < (offset + size))
                return null; // throw new Exception("{61573C82-F128-4ADE-A6AA-88004EB0EBBE}:有效字节长度过短");
            //还原转义并且过滤标志位,9为去掉标识位的head长度
            byte[] dst = Restore(buffer, offset, size);
            if (dst.Length < HelpBuffLen - 2) return null;
            //throw new Exception("{4DE7D881-0C40-4C09-8337-CE06CC2761FF}:转义还原数组溢出"+dst.Length);
            //uint plen = dst.ToUInt32(7);
            uint plen = dst.ToUInt32(11);
            if (plen > dst.Length - HelpBuffLen + 2) return null;
            Packet p = new Packet();

            p._Head = new PacketHeader();
            p._Head.MainId = dst.ToUInt32(0);
            p._Head.SubId = dst.ToUInt32(4);
            p._Head.pkgType = dst[8];
            p._Head.pkgCount = dst.ToUInt16(9);
            p._Head.messageLen = plen;
            p.message = new byte[p._Head.messageLen];
            Buffer.BlockCopy(dst, HelpBuffLen - 2, p.message, 0, p.message.Length);
            return p;
        }
        private static unsafe byte[] Restore(byte[] buffer, int offset, int size)
        {
            int pkgCnt = 0, subCnt = 0;
            /*var tCnt =*/
            CheckRestoreFlagCount(buffer, offset, size, out pkgCnt, out subCnt);
            if ( /*(tCnt.Item1 + tCnt.Item2)*/pkgCnt + subCnt == 0)
            {
                byte[] buff = new byte[size - 2];
                if (buffer.Length < offset + 1 + buff.Length)
                    throw new Exception("{FE815CC3-EA7D-49BF-89ED-E1B63D812D4F}:偏移长度溢出");
                Buffer.BlockCopy(buffer, offset + 1, buff, 0, buff.Length);
                return buff;
            }

            int pLen = size - 2; //去掉标志位后的长度
            byte[] rBuffer = new byte[pLen - pkgCnt - subCnt /*tCnt.Item1 - tCnt.Item2*/];
            fixed (byte* dst = rBuffer, src = &(buffer[offset + 1]))
            {
                byte* _src = src;
                byte* _dst = dst;
                //开始标志位
                //*(dst+0) = *(src + offset);
                //消息头和消息体
                while (pLen >= 0)
                {
                    if (*(_src) == subFlag && *(_src + 1) == 0x01)
                    {
                        *(_dst) = packFlag;
                        _src += 2;
                        _dst += 1;
                        pLen -= 2;
                    }
                    else if (*(_src) == subFlag && *(_src + 1) == 0x02)
                    {
                        *(_dst) = subFlag;
                        _src += 2;
                        _dst += 1;
                        pLen -= 2;
                    }
                    else
                    {
                        *(_dst) = *(_src);
                        _src += 1;
                        _dst += 1;
                        pLen -= 1;
                    }
                }

                return rBuffer;
            }
        }

        private static unsafe void CheckRestoreFlagCount(byte[] buffer, int offset, int size, out int pkgCnt, out int subCnt)
        {
            int len = size - 2;
            //int i = offset + 1;
            //int pkgCnt = 0, subCnt = 0;
            pkgCnt = subCnt = 0;
            fixed (byte* src = &(buffer[offset + 1]))
            {
                byte* _src = src;
                do
                {
                    if (*_src == subFlag && *(_src + 1) == 0x01)
                    {
                        ++pkgCnt;
                        _src += 2;
                        len -= 2;
                    }
                    else if (*_src == subFlag && *(_src + 1) == 0x02)
                    {
                        ++subCnt;
                        _src += 2;
                        len -= 2;
                    }
                    else
                    {
                        _src += 1;
                        --len;
                    }
                } while (len > 0);
            }
            //return Tuple.Create(pkgCnt, subCnt);
        }
    }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
}