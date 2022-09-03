using System;
using System.Text;

namespace IFramework.Net.WebSocket
{
    internal class WebsocketFrame : DataFrame
    {
        private Encoding encoding = Encoding.UTF8;
        private const string acceptMask = "258EAFA5-E914-47DA-95CA-C5AB0DC85B11";//固定字符串
        private readonly char[] splitChars =null;

        public WebsocketFrame()
        {
            splitChars = BaseInfo.SplitChars.ToCharArray();
        }

        public SegmentOffset RspAcceptedFrame(AccessInfo access)
        {
            var accept = new AcceptInfo()
            {
                Connection = access.Connection,
                Upgrade = access.Upgrade,
                SecWebSocketLocation = access.Host,
                SecWebSocketOrigin = access.Origin,
                SecWebSocketAccept = (access.SecWebSocketKey + acceptMask).ToSha1Base64(encoding)
            };

            return new SegmentOffset(encoding.GetBytes(accept.ToString()));
        }

        public AcceptInfo ParseAcceptedFrame(string msg)
        {
            string[] msgs = msg.Split(BaseInfo.NewLine.ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
            var acceptInfo = new AcceptInfo
            {
                HttpProto = msgs[0]
            };

            foreach (var item in msgs)
            {
                string[] kv = item.Split(splitChars,StringSplitOptions.RemoveEmptyEntries);
                switch (kv[0])
                {
                    case "Upgrade":
                        acceptInfo.Upgrade = kv[1];
                        break;
                    case "Connection":
                        acceptInfo.Connection = kv[1];
                        break;
                    case "Sec-WebSocket-Accept":
                        acceptInfo.SecWebSocketAccept = kv[1];
                        break;
                    case "Sec-WebSocket-Location":
                        acceptInfo.SecWebSocketLocation = kv[1];
                        break;
                    case "Sec-WebSocket-Origin":
                        acceptInfo.SecWebSocketOrigin = kv[1];
                        break;
                }
            }
            return acceptInfo;
        }

        public SegmentOffset ToSegmentFrame(string content)
        {
            var buf = encoding.GetBytes(content);
            Payload = new SegmentOffset()
            {
                buffer = buf
            };

            PayloadLength = Payload.buffer.LongLength;

            return new SegmentOffset(EncodingToBytes());
        }

        public SegmentOffset ToSegmentFrame(byte[] buf, OpCodeType code = OpCodeType.Text)
        {
            OpCode = (byte)code;

            Payload = new SegmentOffset()
            {
                buffer = buf
            };
            PayloadLength = Payload.buffer.LongLength;

            return new SegmentOffset(EncodingToBytes());
        }

        public SegmentOffset ToSegmentFrame(SegmentOffset data, OpCodeType code = OpCodeType.Text)
        {
            OpCode = (byte)code;

            Payload = data;
            PayloadLength = Payload.buffer.LongLength;

            return new SegmentOffset(EncodingToBytes());
        }

        public AccessInfo GetHandshakePackage(SegmentOffset segOffset)
        {
            string msg = encoding.GetString(segOffset.buffer, segOffset.offset, segOffset.size);

            string[] items = msg.Split(BaseInfo.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (items.Length < 6)
                throw new Exception("access format error..." + msg);

            AccessInfo access = new AccessInfo()
            {
                HttpProto = items[0]
            };

            foreach (var item in items)
            {
                string[] kv = item.Split(splitChars,StringSplitOptions.RemoveEmptyEntries);
                switch (kv[0])
                {
                    case "Connection":
                        access.Connection = kv[1];
                        break;
                    case "Host":
                        access.Host = kv[1];
                        break;
                    case "Origin":
                        access.Origin = kv[1];
                        break;
                    case "Upgrade":
                        access.Upgrade = kv[1];
                        break;
                    case "Sec-WebSocket-Key":
                        access.SecWebSocketKey = kv[1];
                        break;
                    case "Sec-WebSocket-Version":
                        access.SecWebSocketVersion = kv[1];
                        break;
                    case "Sec-WebSocket-Extensions":
                        access.SecWebSocketExtensions = kv[1];
                        break;
                }
            }
            return access;
        }
    }

    [Flags]
    internal enum OpCodeType : byte
    {
        Attach = 0x0,
        Text = 0x1,
        Bin = 0x2,
        Close = 0x8,
        Bing = 0x9,
        Bong = 0xA,
    }
}
