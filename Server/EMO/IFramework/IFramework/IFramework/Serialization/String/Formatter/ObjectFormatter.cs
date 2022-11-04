using System;
using System.Reflection;
using System.Text;

namespace IFramework.Serialization
{
    public class ObjectFormatter<T> : StringFormatter<T>
    {
        public override void ConvertToString(T t, StringBuilder builder)
        {
            if (t == null) return;
            var fields = typeof(T).GetFields();
            builder.Append(StringConvert.leftBound);
            for (int i = 0; i < fields.Length; i++)
            {
                var field = fields[i];
                if (field.IsNotSerialized) continue;
                if (field.IsStatic) continue;
                StringFormatter c = StringConvert.GetFormatter(field.FieldType);
                builder.Append(field.Name);
                builder.Append(StringConvert.colon);
                c.ConvertToString(field.GetValue(t), builder);
                builder.Append(StringConvert.dot);
            }

            var ps = typeof(T).GetProperties();
            for (int i = 0; i < ps.Length; i++)
            {
                var p = ps[i];
                if (!p.CanRead) continue;
                if (!p.CanWrite) continue;

                StringFormatter c = StringConvert.GetFormatter(p.PropertyType);
                builder.Append(p.Name);
                builder.Append(StringConvert.colon);
                c.ConvertToString(p.GetValue(t), builder);
                builder.Append(StringConvert.dot);
            }
            builder.Append(StringConvert.rightBound);
        }

        public override bool TryConvert(string self, out T result)
        {
            object _obj = Activator.CreateInstance<T>();
            bool bo = ReadObject(self, (fieldName, inner) =>
            {
                SetMember(fieldName, inner, _obj);
            });
            if (bo)
                result = (T)_obj;
            else
                result = MakeDefault();
            return bo;
        }
        private void SetMember(string fieldName, string inner, object _obj)
        {
            var membders = typeof(T).GetMember(fieldName);
            if (membders != null && membders.Length == 1)
            {
                var membder = membders[0];
                if (membder is FieldInfo)
                {
                    FieldInfo f = membder as FieldInfo;
                    StringFormatter c = StringConvert.GetFormatter(f.FieldType);
                    object value;
                    if (c.TryConvertObject(inner, out value))
                    {
                        f.SetValue(_obj, value);
                    }
                }
                else if (membder is PropertyInfo)
                {
                    PropertyInfo p = membder as PropertyInfo;
                    StringFormatter c = StringConvert.GetFormatter(p.PropertyType);
                    object value;
                    if (c.TryConvertObject(inner, out value))
                    {
                        p.SetValue(_obj, value);
                    }
                }
            }
        }

        private static int ReadField(string value, int start, out int colinIndex)
        {
            colinIndex = value.IndexOf(StringConvert.colon, start);
            if (colinIndex < 0) return -1;
            int depth = 0;
            for (int i = colinIndex + 1; i < value.Length; i++)
            {
                char data = value[i];
                if (data == StringConvert.leftBound || data == StringConvert.midLeftBound)
                {
                    depth++;
                }
                else if (data == StringConvert.rightBound || data == StringConvert.midRightBound)
                {
                    depth--;
                }
                else
                {
                    if (data == StringConvert.dot && depth == 0)
                    {
                        return i;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (depth == 0)
                {
                    for (int j = i; j < value.Length; j++)
                    {
                        if (value[j] == StringConvert.dot)
                        {
                            return j;
                        }
                    }
                    return value.Length - 1;
                }
            }
            return value.Length - 1;
        }

        public static bool ReadObject(string value, Action<string, string> call)
        {
            try
            {
                if (!value.StartsWith(StringConvert.leftBound.ToString())) goto ERR;
                if (!value.EndsWith(StringConvert.rightBound.ToString())) goto ERR;
                value = value.Remove(0, 1);
                value = value.Remove(value.Length - 1, 1);
                int start = 0;
                while (start < value.Length)
                {
                    int colinIndex = 0;
                    int end = ReadField(value, start, out colinIndex);
                    if (end == -1)
                    {
                        break;
                    }
                    string fieldName = value.Substring(start, colinIndex - start);
                    string inner = value.Substring(colinIndex + 1, end - colinIndex);
                    if (inner.EndsWith(StringConvert.dot.ToString()))
                    {
                        inner = inner.Remove(inner.Length - 1, 1);
                    }

                    call?.Invoke(fieldName, inner);

                    start = end + 1;
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        ERR:
            return false;
        }
    }
}
