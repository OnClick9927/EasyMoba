using System.Collections.Generic;
using System;

namespace IFramework.Serialization.DataTable
{
    /// <summary>
    /// 数据读取器
    /// </summary>
    public interface IDataReader : IDisposable
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        List<T> Get<T>();
        /// <summary>
        /// 标题栏
        /// </summary>
        List<string> headNames { get; }
        /// <summary>
        /// 行
        /// </summary>
        List<List<DataColumn>> rows { get; }
    }
}