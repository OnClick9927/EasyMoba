/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.11f1
 *Date:           2019-09-08
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Reflection;

namespace IFramework.Serialization.DataTable
{
    /// <summary>
    /// string 解释器
    /// </summary>
    public class DataExplainer : IDataExplainer
    {
        private char dot;
        private char quotes;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="dot">替换逗号的字符</param>
        /// <param name="quotes">替换双引号的字符</param>
        public DataExplainer(char dot = '◞', char quotes = '◜')
        {
            this.dot = dot;
            this.quotes = quotes;
        }

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected object CreatInstance(Type type)
        {
            return Activator.CreateInstance(type);
        }
        /// <summary>
        /// 根据格子反序列化一个实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cols"></param>
        /// <param name="membersDic">需要反序列化的成员</param>
        /// <returns></returns>
        public T CreatInstance<T>(List<DataColumn> cols, Dictionary<MemberInfo, string> membersDic)
        {
            object t = CreatInstance(typeof(T));
            foreach (var pair in membersDic)
            {
                MemberInfo m = pair.Key;
                string csvName = pair.Value;
                DataColumn column;
                if (m.IsDefined(typeof(DataReadColumnIndexAttribute), false))
                {
                    DataReadColumnIndexAttribute attr = m.GetCustomAttributes(typeof(DataReadColumnIndexAttribute), false)[0] as DataReadColumnIndexAttribute;
                    if (attr.index >= cols.Count)
                        throw new Exception(string.Format("index {0} is too Large Then colums  {1}", attr.index, cols.Count));
                    column = cols[attr.index];
                }
                else
                {
                    column = cols.Find((c) => { return c.headNameForRead == csvName; });
                }
                string str = FitterCsv_CreatInstance(column.value);
                if (m is PropertyInfo)
                {
                    PropertyInfo info = m as PropertyInfo;
                    object obj = default(object);
                    if (StringConvert.TryConvert(str, info.PropertyType, ref obj))
                        info.SetValue(t, obj, null);
                    else
                        throw new Exception(string.Format("Convert Err Type {0} Name {1} Value {2}", typeof(T), csvName, column.value));
                }
                else
                {
                    FieldInfo info = m as FieldInfo;
                    object obj = default(object);
                    if (StringConvert.TryConvert(str, info.FieldType, ref obj))
                        info.SetValue(t, obj);
                    else
                        throw new Exception(string.Format("Convert Err Type {0} Name {1} Value {2}", typeof(T), csvName, column.value));
                }
            }
            return (T)t;
        }
        /// <summary>
        /// 根据 具体类型 获取单个数据格子数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="membersDic">需要序列化的成员</param>
        /// <returns></returns>
        public List<DataColumn> GetColumns<T>(T t, Dictionary<MemberInfo, string> membersDic)
        {
            List<DataColumn> columns = new List<DataColumn>();
            foreach (var member in membersDic)
            {
                string val = string.Empty;
                MemberInfo m = member.Key;
                if (m is PropertyInfo)
                {
                    PropertyInfo info = m as PropertyInfo;
                    val = StringConvert.ConvertToString(info.GetValue(t, null), info.PropertyType);
                }
                else
                {
                    FieldInfo info = m as FieldInfo;
                    val = StringConvert.ConvertToString(info.GetValue(t), info.FieldType);
                }
                columns.Add(new DataColumn()
                {
                    value = FitterCsv_GetColum(val)
                });
            }
            return columns;
        }


        private string FitterCsv_GetColum(string source)
        {
            return source.Replace(StringConvert.dot, dot).Replace('\"', quotes);
        }
        private string FitterCsv_CreatInstance(string source)
        {
            return source.Replace(dot, StringConvert.dot).Replace(quotes, '\"');
        }
    }
}
