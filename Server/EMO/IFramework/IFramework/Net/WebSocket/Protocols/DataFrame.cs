using IFramework.Packets;
using System;

namespace IFramework.Net.WebSocket
{
    internal class DataFrame
    {
        /// <summary>
        /// 如果为true则该消息为消息尾部,如果false为零则还有后续数据包;
        /// </summary>
        public bool IsEof { get; set; } = true;
        /// <summary>
        /// RSV1,RSV2,RSV3,各1位，用于扩展定义的,如果没有扩展约定的情况则必须为0
        /// </summary>
        public bool Rsv1 { get; set; }

        public bool Rsv2 { get; set; }

        public bool Rsv3 { get; set; }
        /// <summary>
        ///0x0表示附加数据帧
        ///0x1表示文本数据帧
        ///0x2表示二进制数据帧
        ///0x3-7暂时无定义，为以后的非控制帧保留
        ///0x8表示连接关闭
        ///0x9表示ping
        ///0xA表示pong
        ///0xB-F暂时无定义，为以后的控制帧保留
        /// </summary>
        public byte OpCode { get; set; } = 0x01;
        /// <summary>
        /// true使用掩码解析消息
        /// </summary>
        public bool Mask { get; set; } = false;

        public long PayloadLength { get; set; }

        //public int Continued { get; set; }

        public byte[] MaskKey { get; set; }

        //public UInt16 MaskKeyContinued { get; set; }

        public SegmentOffset Payload { get; set; }

        public byte[] EncodingToBytes()
        {
            if (Payload == null
                || Payload.buffer.LongLength != PayloadLength)
                throw new Exception("payload buffer error");


            if (Payload.size > 0)
            {
                PayloadLength = Payload.size;
            }

            long headLen = (Mask ? 6 : 2);
            if (PayloadLength < 126)
            { }
            else if (PayloadLength >= 126 && PayloadLength < 127)
            {
                headLen += 2;
            }
            else if (PayloadLength >= 127)
            {
                headLen += 8;
            }

            byte[] buffer = new byte[headLen + PayloadLength];
            int pos = 0;

            buffer[pos] = (byte)(IsEof ? 128 : 0);
            buffer[pos] += OpCode;

            buffer[++pos] = (byte)(Mask ? 128 : 0);
            if (PayloadLength < 0x7e)//126
            {
                buffer[pos] += (byte)PayloadLength;
            }
            else if (PayloadLength < 0xffff)//65535
            {
                buffer[++pos] = 126;
                buffer[++pos] = (byte)(buffer.Length >> 8);
                buffer[++pos] = (byte)(buffer.Length);
            }
            else
            {
                var payLengthBytes = ((ulong)PayloadLength).ToBytes();
                buffer[++pos] = 127;

                buffer[++pos] = payLengthBytes[0];
                buffer[++pos] = payLengthBytes[1];
                buffer[++pos] = payLengthBytes[2];
                buffer[++pos] = payLengthBytes[3];
                buffer[++pos] = payLengthBytes[4];
                buffer[++pos] = payLengthBytes[5];
                buffer[++pos] = payLengthBytes[6];
                buffer[++pos] = payLengthBytes[7];
            }

            if (Mask)
            {
                buffer[++pos] = MaskKey[0];
                buffer[++pos] = MaskKey[1];
                buffer[++pos] = MaskKey[2];
                buffer[++pos] = MaskKey[3];

                for (long i = 0; i < PayloadLength; ++i)
                {
                    buffer[headLen + i] = (byte)(Payload.buffer[i+Payload.offset] ^ MaskKey[i % 4]);
                }
            }
            else
            {
                for (long i = 0; i < PayloadLength; ++i)
                {
                    buffer[headLen + i] = Payload.buffer[i+Payload.offset];
                }
            }
            return buffer;
        }

       public bool DecodingFromBytes(SegmentOffset data, bool isMaskResolve = true)
        {
            if (data.size < 4) return false;

            int pos = data.offset;

            IsEof = (data.buffer[pos] >> 7) == 1;
            OpCode = (byte)(data.buffer[pos] & 0xf);

            Mask = (data.buffer[++pos] >> 7) == 1;
            PayloadLength = (data.buffer[pos] & 0x7f);

            //校验截取长度
            if (PayloadLength >= data.size) return false;

            ++pos;
            //数据包长度超过126，需要解析附加数据
            if (PayloadLength < 126)
            {
              //直接等于消息长度
            }
            if (PayloadLength == 126)
            {
                PayloadLength = data.buffer.ToUInt16(pos);// BitConverter.ToUInt16(segOffset.buffer, pos);
                pos += 2;
            }
            else if(PayloadLength==127)
            {
                PayloadLength = (long)data.buffer.ToUInt64(pos);
                pos += 8;
            }

            Payload = new SegmentOffset()
            {
                offset = pos,
                buffer = data.buffer,
                size = (int)PayloadLength
            };

            //数据体
            if (Mask)
            {
                //获取掩码密钥
                MaskKey = new byte[4];
                MaskKey[0] = data.buffer[pos];
                MaskKey[1] = data.buffer[pos + 1];
                MaskKey[2] = data.buffer[pos + 2];
                MaskKey[3] = data.buffer[pos + 3];
                pos += 4;

                Payload.buffer = data.buffer;
                Payload.offset = pos;
                if (isMaskResolve)
                {
                    long p = 0;

                    for (long i = 0; i < PayloadLength; ++i)
                    {
                        p = (long)pos + i;

                        Payload.buffer[p] = (byte)(Payload.buffer[p] ^ MaskKey[i % 4]);
                    }
                }
            }
            else
            {
                Payload.buffer = data.buffer;
                Payload.offset = pos;
            }

            return true;
        }
    }
}
