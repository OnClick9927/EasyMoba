using System.Text;

namespace IFramework.Serialization
{
    public class BaseTypeFormatter<T> : StringFormatter<T>
    {
        StringConverter<T> sc = StringConvert.GetConverter(typeof(T)) as StringConverter<T>;
        public override void ConvertToString(T t, StringBuilder builder)
        {
            var result = sc.ConvertToString(t);
            builder.Append(result.ToString());
        }

        public override bool TryConvert(string self, out T result)
        {
            return sc.TryConvert(self,out result);
        }
    }
}
