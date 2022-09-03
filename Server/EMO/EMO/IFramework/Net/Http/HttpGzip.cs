using System.IO;
using System.IO.Compression;
using System.Text;

namespace IFramework.Net.Http
{
    public class HttpGzip
    {
        public static string UnzipToString(byte[] content, string encoding = "UTF-8")
        {
            using (GZipStream deStream = new GZipStream(new MemoryStream(content), CompressionMode.Decompress))
            using (StreamReader reader = new StreamReader(deStream, Encoding.GetEncoding(encoding)))
            {
                string result = reader.ReadToEnd();
                return result;
            }
        }

        public static byte[] UnzipToBytes(byte[] content)
        {
            using (GZipStream deStream = new GZipStream(new MemoryStream(content), CompressionMode.Decompress))
            using (MemoryStream ms = new MemoryStream())
            {
                deStream.CopyTo(ms);
                return ms.ToArray();
            }
        }

        public static byte[] ZipToBytes(byte[] content)
        {
            using(MemoryStream ms=new MemoryStream()) 
            using (GZipStream ComStream = new GZipStream(ms, CompressionMode.Compress))
            {
                ComStream.Write(content, 0, content.Length);
                return ms.ToArray();
            }
        }

        public static byte[] ZipToBytes(string content,string encoding="UTF-8")
        {
            using (MemoryStream ms = new MemoryStream())
            using (GZipStream ComStream = new GZipStream(ms, CompressionMode.Compress))
            {
                byte[] buf = Encoding.GetEncoding(encoding).GetBytes(content);
                ComStream.Write(buf, 0, buf.Length);
                return ms.ToArray();
            }
        }
    }
}
