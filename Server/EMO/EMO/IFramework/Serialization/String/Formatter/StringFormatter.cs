using System.Text;

namespace IFramework.Serialization
{
    public abstract class StringFormatter
    {
        public abstract void ConvertToString(object t, StringBuilder builder);
        public abstract bool TryConvertObject(string str, out object result);
    }
    public abstract class StringFormatter<T> : StringFormatter
    {
        public abstract bool TryConvert(string self, out T result);

        public override bool TryConvertObject(string str, out object result)
        {
            T t;
            if (TryConvert(str, out t))
            {
                result = t;
                return true;
            }
            else
            {
                result = default(T);
                return false;
            }
        }
        public override void ConvertToString(object t, StringBuilder builder)
        {
            ConvertToString((T)t, builder);
        }
        public abstract void ConvertToString(T t, StringBuilder builder);
        protected T MakeDefault()
        {
            return default(T);
        }
    }
}
