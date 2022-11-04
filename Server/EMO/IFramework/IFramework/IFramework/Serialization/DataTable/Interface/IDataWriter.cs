using System.Collections.Generic;
using System;

namespace IFramework.Serialization.DataTable
{
    /// <summary>
    /// 数据写入器
    /// </summary>
    public interface IDataWriter:IDisposable
    {
        /// <summary>
        /// 写入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        void Write<T>(List<T> source);
        /// <summary>
        /// 写入文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        string WriteString<T>(List<T> source);
        /// <summary>
        /// 写入
        /// </summary>
        /// <param name="headNames"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        string WriteString(List<string> headNames, List<List<DataColumn>> rows);
        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="headNames"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        void Write(List<string> headNames, List<List<DataColumn>> rows);

    }
}