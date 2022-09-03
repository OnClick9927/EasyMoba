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
using System.Linq;
using System.Text;

namespace IFramework.Serialization.DataTable
{
    /// <summary>
    /// 数据行
    /// </summary>
    public class DataRow : IDataRow
    {
        /// <summary>
        /// 读取一行
        /// </summary>
        /// <param name="val">行String</param>
        /// <param name="headNames">标题行</param>
        /// <returns></returns>
        public List<DataColumn> ReadLine(string val, List<string> headNames)
        {
            List<string> strVals = SpilitRow(val);
            if (strVals.Count != headNames.Count) throw new Exception("Read Err Count Is different");

            List<DataColumn> cols = new List<DataColumn>();
            for (int i = 0; i < headNames.Count; i++)
            {
                cols.Add(new DataColumn()
                {
                    value = strVals[i],
                    headNameForRead = headNames[i]
                });
            }
            return cols;
        }
        /// <summary>
        /// 切割一行
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        protected virtual List<string> SpilitRow(string val)
        {
            var list = val.Split(',').ToList();
            if (string.IsNullOrEmpty(list.Last()))
            {
                list.RemoveAt(list.Count - 1);
            }
            return list;
        }
        /// <summary>
        /// 读取标题行
        /// </summary>
        /// <param name="val">行String</param>
        /// <returns></returns>
        public virtual List<string> ReadHeadLine(string val)
        {
            List<string> headNames = val.Split(',').ToList();
            if (string.IsNullOrEmpty(headNames.Last()))
            {
                headNames.RemoveAt(headNames.Count - 1);
            }
            return headNames;
        }
        /// <summary>
        /// 写入一行
        /// </summary>
        /// <param name="cols">写入的信息</param>
        /// <returns></returns>
        public virtual void WriteLine(List<DataColumn> cols, StringBuilder builder)
        {
            for (int i = 0; i < cols.Count; i++)
            {
                var index = i;
                var c = cols[index];
                string val = c.value;
                val = val.Replace("\"", "\"\"");
                if (val.Contains(StringConvert.dot) || val.Contains("\"") || val.Contains('\r') || val.Contains('\n'))
                    val = string.Format("\"{0}\"", val);
                builder.Append(val);
                builder.Append(StringConvert.dot.ToString());
            }
        }
        /// <summary>
        /// 写入标题行
        /// </summary>
        /// <param name="headNames">写入的标题</param>
        /// <returns></returns>
        public virtual void WriteHeadLine(List<string> headNames, StringBuilder builder)
        {
            for (int i = 0; i < headNames.Count; i++)
            {
                var index = i;
                var val = headNames[index];
                val = val.Replace("\"", "\"\"");
                if (val.Contains(StringConvert.dot) || val.Contains("\"") || val.Contains('\r') || val.Contains('\n'))
                    val = string.Format("\"{0}\"", val);

                builder.Append(val);
                builder.Append(StringConvert.dot.ToString());
            }
        }
    }
}
