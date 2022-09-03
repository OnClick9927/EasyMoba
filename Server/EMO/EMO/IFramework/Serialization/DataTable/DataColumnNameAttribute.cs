/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.11f1
 *Date:           2019-09-08
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System;

namespace IFramework.Serialization.DataTable
{
    /// <summary>
    /// 设置数据表标题
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class DataColumnNameAttribute : Attribute
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="name">名称</param>
        public DataColumnNameAttribute(string name) { this.name = name; }
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; private set; }
    }
}
