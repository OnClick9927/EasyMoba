/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.11f1
 *Date:           2019-05-03
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;


namespace IFramework.Serialization
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释

    public static partial class StringConvert
    {

        private static Dictionary<Type, Type> _map = new Dictionary<Type, Type>()
        {
            { typeof(Byte),typeof(ByteStringConverter)},
            { typeof(Boolean),typeof(BoolStringConverter)},
            { typeof(Char),typeof(CharStringConverter)},
            { typeof(DateTime),typeof(DateTimeStringConverter)},
            { typeof(Decimal),typeof(DecimalStringConverter)},
            { typeof(Double),typeof(DoubleStringConverter)},
            { typeof(Single),typeof(FloatStringConverter)},
            { typeof(Int32),typeof(IntStringConverter)},
            { typeof(Int64),typeof(LongStringConverter)},
            { typeof(SByte),typeof(SByteStringConverter)},
            { typeof(Int16),typeof(ShortStringConverter)},
            { typeof(String),typeof(StringStringConverter)},
            { typeof(TimeSpan),typeof(TimeSpanStringConverter)},
            { typeof(UInt16),typeof(UInt16StringConverter)},
            { typeof(UInt32),typeof(UInt32StringConverter)},
            { typeof(UInt64),typeof(UInt64StringConverter)},
        };
        private static Dictionary<Type, StringConverter> _ins = new Dictionary<Type, StringConverter>();

        private static Dictionary<Type, Type> _fgenmap = new Dictionary<Type, Type>()
        {
            {(typeof(List<>)),typeof(ListFormatter<>) } ,
            {(typeof(Stack<>)),typeof(StackFormatter<>) } ,
            {(typeof(Queue<>)),typeof(QueueFormatter<>) } ,
            {(typeof(LinkedList<>)),typeof(LinkedListFormatter<>) } ,
            {(typeof(Dictionary<,>)),typeof(DictionaryFormatter<,>) } ,
        };
        private static Dictionary<Type, StringFormatter> _fins = new Dictionary<Type, StringFormatter>();

        public const char dot = ',';
        public const char leftBound = '{';
        public const char rightBound = '}';
        public const char midLeftBound = '[';
        public const char midRightBound = ']';
        public const char colon = ':';

        public static string ConvertToString<T>(T self)
        {
            return ConvertToString(self, typeof(T));
        }
        public static string ConvertToString(object self, Type type)
        {
            if (self == null) return string.Empty;
            StringBuilder builder = new StringBuilder();
            var s = GetFormatter(type);
            s.ConvertToString(self, builder);
            return builder.ToString();
        }
        public static bool TryConvert<T>(string self, out T t)
        {
            object t1 = null;
            if (TryConvert(self, typeof(T), ref t1))
            {
                t = (T)t1;
                return true;
            }
            t = default(T);
            return false;
        }
        public static bool TryConvert(string self, Type type, ref object obj)
        {
            if (string.IsNullOrEmpty(self)) return false;
            self = self.Replace(" ", "").Replace("\r\n", "\n").Replace("\n", "");
            return GetFormatter(type).TryConvertObject(self, out obj);
        }

        public static StringConverter GetConverter(Type type)
        {
            StringConverter c;
            if (!_ins.TryGetValue(type, out c))
            {
                Type t;
                if (!_map.TryGetValue(type, out t))
                {
                    if (type.IsEnum)
                        c = Activator.CreateInstance(typeof(EnumStringConverter<>).MakeGenericType(type)) as StringConverter;
                }
                else
                {
                    c = CreateConverter(t);
                }
                if (c != null)
                {
                    _ins.Add(type, c);
                }
                else
                {
                    throw new Exception($"None StringConverter with Type {type}");
                }
            }
            return c;
        }
        private static StringConverter CreateConverter(Type type)
        {
            return Activator.CreateInstance(type) as StringConverter;
        }

        private static StringFormatter CreateFormatter(Type type)
        {
            if (type.IsEnum || _map.ContainsKey(type))
                return Activator.CreateInstance(typeof(BaseTypeFormatter<>).MakeGenericType(type)) as StringFormatter;
            if (type.IsArray)
                return Activator.CreateInstance(typeof(ArrayFormatter<>).MakeGenericType(type.GetElementType())) as StringFormatter;
            if (type.IsGenericType)
            {
                foreach (var item in _fgenmap.Keys)
                {
                    if (type.IsSubclassOfGeneric(item))
                    {
                        return Activator.CreateInstance(_fgenmap[item].MakeGenericType(type.GetGenericArguments())) as StringFormatter;
                    }
                }
            }
            return Activator.CreateInstance(typeof(ObjectFormatter<>).MakeGenericType(type)) as StringFormatter;
        }
        public static StringFormatter GetFormatter(Type type)
        {
            StringFormatter c;
            if (!_fins.TryGetValue(type, out c))
            {
                c = CreateFormatter(type);
                if (c != null)
                {
                    _fins.Add(type, c);
                }
                else
                {
                    throw new Exception($"None StringFormatter with Type {type}");
                }
            }
            return c;
        }


        public static void SubscribeConverter<T>(StringConverter converter)
        {
            if (!_map.ContainsKey(typeof(T)))
            {
                _ins.Add(typeof(T), converter);
            }
            else
            {
                _ins[typeof(T)] = converter;
            }
        }
        public static void SubscribeFormatter<T>(StringFormatter converter)
        {
            if (!_map.ContainsKey(typeof(T)))
            {
                _fins.Add(typeof(T), converter);
            }
            else
            {
                _fins[typeof(T)] = converter;
            }
        }
        public static void SubscribeGenericFormatter<T>(Type converter)
        {
            if (!_map.ContainsKey(typeof(T)))
            {
                _fgenmap.Add(typeof(T), converter);
            }
            else
            {
                _fgenmap[typeof(T)] = converter;
            }
        }

    }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释

}
