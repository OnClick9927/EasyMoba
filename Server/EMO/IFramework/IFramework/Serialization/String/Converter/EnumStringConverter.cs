/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.11f1
 *Date:           2019-04-07
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System;

namespace IFramework.Serialization
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释

    public class EnumStringConverter<T> : StringConverter<T> where T : struct
    {
        public override string ConvertToString(T t)
        {
            if (typeof(T).IsEnum)
            {
                ulong ul;
                try
                {
                    ul = Convert.ToUInt64(t as Enum);
                }
                catch (OverflowException)
                {
                    unchecked
                    {
                        ul = (ulong)Convert.ToInt64(t as Enum);
                    }
                }
                return ul.ToString();
            }
            else
                throw new Exception("This Type is Not Enum "+ typeof(T));
        }
        public override bool TryConvert(string self, out T result)
        {
            return Enum.TryParse(self, out result);
        }
    }

#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释

}
