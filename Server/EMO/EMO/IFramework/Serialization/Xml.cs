/*********************************************************************************
 *Author:       OnClick
 *Version:      1.0
 *UnityVersion: 2017.2.3p3
 *Date:         2019-01-26
 *Description:   
 *History:  
**********************************************************************************/
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace IFramework.Serialization
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
    public interface IXmlHelper
    {
        string ToXml<T>(T t);
        T FromXml<T>(string xmlString);
    }

    public class Xml
    {
        public static IXmlHelper helper { get; set; }
        static Xml()
        {
            helper =new DefaultXmlHelper();
        }

        public static string ToXml<T>(T t)
        {
            return helper.ToXml(t);
        }
        public static T FromXml<T>(string xmlString)
        {
            return helper.FromXml<T>(xmlString);
        }
    }
    internal class DefaultXmlHelper : IXmlHelper
    {
        public T FromXml<T>(string xmlString)
        {
            using (TextReader reader = new StringReader(xmlString))
            {
                return (T)new XmlSerializer(typeof(T)).Deserialize(reader);
            }
        }

        public string ToXml<T>(T t)
        {
            StringBuilder sb = new StringBuilder();
            using (TextWriter writer = new StringWriter(sb))
            {
                new XmlSerializer(typeof(T)).Serialize(writer, t);
            }
            return sb.ToString();
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    new XmlSerializer(typeof(T)).Serialize(ms, t);
            //    return Encoding.UTF8.GetString(ms.ToArray());
            //}
        }
    }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释

}