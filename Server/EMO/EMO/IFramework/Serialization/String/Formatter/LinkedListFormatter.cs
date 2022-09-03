using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IFramework.Serialization
{
    public class LinkedListFormatter<T> : StringFormatter<LinkedList<T>>
    {
        public override void ConvertToString(LinkedList<T> t, StringBuilder builder)
        {
            ListFormatter<T> c = StringConvert.GetFormatter(typeof(List<T>)) as ListFormatter<T>;
            c.ConvertToString(t.ToList(), builder);
        }

        public override bool TryConvert(string self, out LinkedList<T> result)
        {
            ListFormatter<T> c = StringConvert.GetFormatter(typeof(List<T>)) as ListFormatter<T>;
            List<T> list;
            if (!c.TryConvert(self, out list))
            {
                result = MakeDefault();
                return false;
            }
            else
            {
                result = new LinkedList<T>(list);
                return true;
            }
        }
    }
}
