using System;
using System.Text;
using System.IO;

namespace IFramework.Net.Http
{
    public class HttpHeader
    {
        public string Protocol { get; set; } = "HTTP/1.1";

        public HttpOption Option { get; set; }

        public string RelativeUri { get; set; } = "/";

        public string Host { get; set; }

        public string Connection { get; set; }

        public string UserAgent { get; set; }

        public string Accept { get; set; }

        public string CacheControl { get; set; }
        public string ContentType { get; set; }
        public string AcceptEncoding { get; set; }

        public string AcceptLanguage { get; set; }
      
        public string Referer { get; set; }

        public string Cookie { get; set; }

        public string SecFetchUser { get; set; }
        public string SecFetchMode { get; set; }
        public string SecFetchSite { get; set; }
        public string SecFetchDest { get; set; }
        /// <summary>
        /// extend reserve
        /// </summary>
        public string Extensions { get; set; }
        /// <summary>
        /// do not track
        /// </summary>
        public string DNT { get; set; }

        public long StreamPosition { get; private set; }

        public long ContentLength { get; set; }

        public HttpHeader(string httpContent)
        {
            string[] lines = httpContent.Split('\n');
            GetHeaderLine(lines[0]);

            for(int i = 1; i < lines.Length; ++i)
            {
                if (lines[i] == string.Empty) break;
                 GetHeader(lines[i]);
            }
        }

        public HttpHeader(SegmentOffset segment)
        {
            using (MemoryStream ms = new MemoryStream(segment.buffer, segment.offset, segment.size))
            using (StreamReader reader = new StreamReader(ms, Encoding.UTF8))
            {
                string line = reader.ReadLine();// first line
                GetHeaderLine(line);

                while ((line=reader.ReadLine()) != null)
                {
                    if (line == string.Empty)
                    {
                        ContentLength = ms.Length - ms.Position;
                        StreamPosition = ms.Position;
                        break;
                    }
                    GetHeader(line);
                }
            }
        }
#if NET_VERSION_4_5
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        protected void GetHeaderLine(string line)
        {
            var ops = line.Split(' ');
            Option = (HttpOption)Enum.Parse(typeof(HttpOption), ops[0]);
            RelativeUri = ops[1];
            Protocol = ops[2];
        }

        public string ToHeaderString(HttpStatusCode httpStatusCode)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("{0} {1} {2}", Protocol, ((int)httpStatusCode), httpStatusCode.ToString());

            builder.AppendLine();
            builder.AppendLine("Cache-Control:"+CacheControl);
            builder.AppendLine("Connection:"+Connection);
            //builder.AppendLine("Content-Encoding:"+ AcceptEncoding);
            builder.AppendLine("Content-Type:" + ContentType);
            builder.AppendLine("Date:" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));

            if (string.IsNullOrEmpty(Extensions) == false)
                builder.AppendLine(Extensions);

            builder.AppendLine();

            return builder.ToString();
        }

        private void GetHeader(string line)
        {
            string[] dics = line.Split(':');
            if (dics.Length <= 1) return;

            switch (dics[0])
            {
                case "Host":Host = dics[1];  break;
                case "Connection": Connection = dics[1];break;
                case "DNT": DNT = dics[1];  break;
                case "Accept": Accept = dics[1];  break;
                case "Referer": Referer = dics[1]; break;
                case "Cookie": Cookie = dics[1]; break;
                case "User-Agent": UserAgent = dics[1]; break;
                case "Cache-Control": CacheControl = dics[1];  break;
                case "Accept-Encoding": AcceptEncoding = dics[1];  break;
                case "Accept-Language": AcceptLanguage = dics[1];  break;
                case "Sec-Fetch-User": SecFetchUser = dics[1];  break;
                case "Sec-Fetch-Mode": SecFetchMode = dics[1];    break;
                case "Sec-Fetch-Site": SecFetchSite = dics[1];   break;
                case "Sec-Fetch-Dest": SecFetchDest = dics[1];   break;
                default: Extensions += dics[1];break;
            }
        }
    }

    public enum HttpOption
    {
        GET,
        POST,
        PUT,
        DELETE,
        HEAD,
        TRACE,
        PATCH,
        OPTIONS
    }
}
