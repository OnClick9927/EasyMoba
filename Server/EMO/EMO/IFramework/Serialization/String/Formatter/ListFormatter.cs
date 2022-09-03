using System;
using System.Collections.Generic;
using System.Text;

namespace IFramework.Serialization
{
    public class ListFormatter<T> : StringFormatter<List<T>>
    {
        private static StringFormatter<T> f = StringConvert.GetFormatter(typeof(T)) as StringFormatter<T>;
        public override void ConvertToString(List<T> t, StringBuilder builder)
        {
            if (t == null || t.Count == 0) return;
            builder.Append(StringConvert.midLeftBound);
            for (int i = 0; i < t.Count; i++)
            {
                f.ConvertToString(t[i], builder);
                if (i != t.Count - 1)
                {
                    builder.Append(StringConvert.dot); 
                }
            }
            builder.Append(StringConvert.midRightBound);
        }
        private static int ReadItem(string value, int start)
        {
            int depth = 0;

            for (int i = start; i < value.Length; i++)
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
            return -1;

        }

        public static bool ReadArray(string self, Action<string> call)
        {
            try
            {
                if (!self.StartsWith(StringConvert.midLeftBound.ToString())) goto ERR;
                if (!self.EndsWith(StringConvert.midRightBound.ToString())) goto ERR;
                self = self.Remove(0, 1);
                self = self.Remove(self.Length - 1, 1);
                int start = 0;
                while (start < self.Length)
                {
                    int end = ReadItem(self, start);
                    if (end == -1)
                    {
                        break;
                    }
                    string inner = self.Substring(start, end + 1 - start);
                    if (inner.EndsWith(StringConvert.dot.ToString()))
                    {
                        inner = inner.Remove(inner.Length - 1, 1);
                    }
                    call.Invoke(inner);
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
        private List<T> list = new List<T>();
        public override bool TryConvert(string self, out List<T> result)
        {
            list.Clear();

            bool bo = ReadArray(self, (inner) =>
            {
                T value;
                if (f.TryConvert(inner, out value))
                {
                    list.Add(value);
                }
            });
            if (bo)
                result = new List<T>(list);
            else
                result = MakeDefault();
            return bo;
        }
    }
}
