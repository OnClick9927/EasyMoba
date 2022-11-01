/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.11f1
 *Date:           2019-09-08
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System.Collections.Generic;
using System.Text;

namespace IFramework.Serialization.DataTable
{
    /// <summary>
    /// 数据行
    /// </summary>
    public interface IDataRow
    {
        /// <summary>
        /// 读取一行
        /// </summary>
        /// <param name="val">行String</param>
        /// <param name="headNames">标题行</param>
        /// <returns></returns>
        List<DataColumn> ReadLine(string val, List<string> headNames);
        /// <summary>
        /// 读取标题行
        /// </summary>
        /// <param name="val">行String</param>
        /// <returns></returns>
        List<string> ReadHeadLine(string val);
        /// <summary>
        /// 写入一行
        /// </summary>
        /// <param name="cols">写入的信息</param>
        /// <param name="builder"></param>
        /// <returns></returns>
        void WriteLine(List<DataColumn> cols, StringBuilder builder);
        /// <summary>
        /// 写入标题行
        /// </summary>
        /// <param name="headNames">写入的标题</param>
        /// <param name="builder"></param>
        /// <returns></returns>
        void WriteHeadLine(List<string> headNames, StringBuilder builder);
    }
}
