
namespace IFramework.Net
{
    public class SegmentOffset
    {
        public byte[] buffer { get; set; }

        public int offset { get; set; }

        public int size { get; set; }

        public SegmentOffset()
        {

        }

        public SegmentOffset(byte[] buffer)
        {
            this.buffer = buffer;
            this.size = buffer.Length;
        }

        public SegmentOffset(byte[] buffer, int offset, int size)
        {
            this.buffer = buffer;
            this.offset = offset;
            this.size = size;
        }
    }

    public class SegmentToken
    {
        public SocketToken sToken { get; set; }

        public SegmentOffset Data { get; set; }

        public SegmentToken()
        {

        }

        public SegmentToken(SocketToken sToken)
        {
            this.sToken = sToken;
        }

        public SegmentToken(SocketToken sToken,SegmentOffset data)
        {
            this.sToken = sToken;
            this.Data = data;
        }

        public SegmentToken (SocketToken sToken,byte[] buffer)
        {
            this.sToken = sToken;
            this.Data = new SegmentOffset(buffer);
        }

        public SegmentToken(SocketToken sToken,byte[] buffer,int offset,int size)
        {
            this.sToken = sToken;
            this.Data = new SegmentOffset(buffer, offset, size);
        }
    }
}
