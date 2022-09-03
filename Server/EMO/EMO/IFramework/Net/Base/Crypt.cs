using System;
using System.Text;
using System.Security.Cryptography;

namespace IFramework.Net
{
    public static class Crypt
    {
        public static string ToSha1Base64(this string value,Encoding encoding)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] bytes = sha1.ComputeHash(encoding.GetBytes(value));
            return Convert.ToBase64String(bytes);
        }

        public static string ToMd5(this string value,Encoding encoding)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = md5.ComputeHash(encoding.GetBytes(value));
            return Convert.ToBase64String(bytes);
        }
    }
}
