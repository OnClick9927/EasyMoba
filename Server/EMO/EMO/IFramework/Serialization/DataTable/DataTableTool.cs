using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace IFramework.Serialization.DataTable
{
    /// <summary>
    /// DataTable
    /// </summary>
    public static class DataTableTool
    {
        /// <summary>
        /// 创建数据读取器
        /// </summary>
        /// <param name="streamReader"></param>
        /// <param name="rowReader"></param>
        /// <param name="explainer"></param>
        /// <returns></returns>
        public static IDataReader CreateReader(TextReader streamReader, IDataRow rowReader, IDataExplainer explainer)
        {
            return new DataReader(streamReader, rowReader, explainer);
        }
        /// <summary>
        /// 创建数据读取器
        /// </summary>
        /// <param name="text"></param>
        /// <param name="rowReader"></param>
        /// <param name="explainer"></param>
        /// <returns></returns>
        public static IDataReader CreateReader(string text, IDataRow rowReader, IDataExplainer explainer)
        {
            return new DataReader(text, rowReader, explainer);
        }
        /// <summary>
        /// 创建数据写入器
        /// </summary>
        /// <param name="streamWriter"></param>
        /// <param name="rowWriter"></param>
        /// <param name="explainer"></param>
        /// <returns></returns>
        public static IDataWriter CreateWriter(TextWriter streamWriter, IDataRow rowWriter, IDataExplainer explainer)
        {
            return new DataWriter( streamWriter,  rowWriter,  explainer);
        }


        internal static Dictionary<MemberInfo, string> GetMemberInfo(Type type)
        {
            Dictionary<MemberInfo, string> members = new Dictionary<MemberInfo, string>();
            type.GetFields(/*BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static*/)
                .ToList().FindAll((field) => { return !field.IsNotSerialized && !field.IsDefined(typeof(DataIgnoreAttribute), false); ; })
                 .ForEach((field) => {
                     if (field.IsDefined(typeof(DataColumnNameAttribute), false))
                         members.Add(field, (field.GetCustomAttributes(typeof(DataColumnNameAttribute),false)[0] 
                             as DataColumnNameAttribute).name);
                     else
                         members.Add(field, field.Name);
                 });
            type.GetProperties(/*BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static*/)
               .ToList().FindAll((property) => { return !property.IsDefined(typeof(DataIgnoreAttribute), false) && property.CanWrite && property.CanRead; })
               .ForEach((property) => {
                   if (property.IsDefined(typeof(DataColumnNameAttribute), false))
                       members.Add(property, (property.GetCustomAttributes(typeof(DataColumnNameAttribute), false)[0]
                                   as DataColumnNameAttribute).name);
                   else
                       members.Add(property, property.Name);
               });
            return members;
        }

    }
}
