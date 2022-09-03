using System.Text;
using System.IO;

namespace IFramework.Net.Http
{
    public class HttpPost
    {
        private HttpHeader header = null;

        public HttpPost(HttpHeader header)
        {
            this.header = header;
        }

        public HttpPayload GetDo(SegmentToken sToken)
        {
            var paylaod = new HttpPayload()
            {
                Header = header,
                HttpUri = new HttpUri(header.RelativeUri),
                Token = sToken.sToken
            };
            if (header.ContentLength > 0)
            {
                SegmentOffset seg = sToken.Data;
                paylaod.stream = new MemoryStream(seg.buffer,
                    seg.offset + (int)header.StreamPosition,
                    (int)header.ContentLength);
            }
            return paylaod;
        }

        public string Response(string content, HttpStatusCode statusCode=HttpStatusCode.OK,
            string contentType = "text/plain;charset=utf-8")
        {
            header.ContentType = contentType;
            string rspHeader = header.ToHeaderString(statusCode);
            StringBuilder builder = new StringBuilder(rspHeader);//header
            builder.Append(content);//body

            return builder.ToString();
        }

        public string Request()
        {
            return string.Empty;
        }
    }
}
