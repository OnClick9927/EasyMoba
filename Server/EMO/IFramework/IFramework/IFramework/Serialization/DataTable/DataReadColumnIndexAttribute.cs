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
    /// 数据列
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class DataReadColumnIndexAttribute:Attribute
    {
        /// <summary>
        /// 所在列
        /// </summary>
        public int index { get; }
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="index"></param>
        public DataReadColumnIndexAttribute(int index)
        {
            this.index = index;
        }
    }
}
