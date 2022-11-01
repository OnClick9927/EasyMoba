using System.Text;

namespace IFramework.Net.Http
{
    public class HttpGet
    {
        private HttpHeader header = null;

        public HttpGet(HttpHeader header)
        {
            this.header = header;
        }

        public HttpPayload GetDo(SegmentToken sToken)
        {
            return new HttpPayload()
            {
                Header = header,
                HttpUri = new HttpUri(header.RelativeUri),
                Token = sToken.sToken
            };
        }

        public string Response(string content, HttpStatusCode statusCode=HttpStatusCode.OK,
            string contentType="text/plain;charset=utf-8")
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

    public enum HttpStatusCode
    {
        OK = 200,
        Moved = 301,
        NotModified = 304,
        Proxy = 305,
        Bad = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        NotAllowed = 405,
        TooLarge = 413,
        InternalError = 500,
        BadGateway = 502,
        Unavailable = 503,
        NotSupported = 505
    }
}
