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
using System.IO;
using System.Linq;
using System.Text;

namespace IFramework.Serialization.DataTable
{
    /// <summary>
    /// 数据写入者
    /// </summary>
    internal class DataWriter : Unit, IDataWriter
    {
        private IDataExplainer _explainer;
        private TextWriter _streamWriter;
        private IDataRow _rowWriter;
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="streamWriter">流写者</param>
        /// <param name="rowWriter">行写者</param>
        /// <param name="explainer">数据解释器</param>
        public DataWriter(TextWriter streamWriter, IDataRow rowWriter, IDataExplainer explainer)
        {
            this._streamWriter = streamWriter;
            this._rowWriter = rowWriter;
            this._explainer = explainer;
        }
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="rowWriter">行写者</param>
        /// <param name="explainer">数据解释器</param>
        public DataWriter(IDataRow rowWriter, IDataExplainer explainer)
        {
            this._rowWriter = rowWriter;
            this._explainer = explainer;
        }
        /// <summary>
        /// 释放
        /// </summary>
        protected override void OnDispose()
        {
            if (!disposed)
            {
                if (_streamWriter != null)
                {
                    _streamWriter.Flush();
                    _streamWriter.Close();
                }
            }
        }
        /// <summary>
        /// 写入到string
        /// </summary>
        /// <param name="headNames"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public string WriteString(List<string> headNames, List<List<DataColumn>> rows)
        {
            StringBuilder builder = new StringBuilder();
            _rowWriter.WriteHeadLine(headNames, builder);
            builder.Append("\r\n");
            for (int i = 0; i < rows.Count; i++)
            {
                _rowWriter.WriteLine(rows[i], builder);
                builder.Append("\r\n");
            }
            return builder.ToString();
        }
        /// <summary>
        /// 写入文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="headNames"></param>
        /// <param name="rows"></param>
        public void Write(List<string> headNames, List<List<DataColumn>> rows)
        {
            _streamWriter.Write(WriteString(headNames, rows));
        }
        /// <summary>
        /// 写入到string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">数据</param>
        /// <returns></returns>
        public string WriteString<T>(List<T> source)
        {
            List<List<DataColumn>> rows = new List<List<DataColumn>>();
            var members = DataTableTool.GetMemberInfo(typeof(T));
            source.ForEach((t) =>
            {
                var row = _explainer.GetColumns<T>(t, members);
                rows.Add(row);
            });
            return WriteString(members.Values.ToList(), rows);
        }
        /// <summary>
        /// 写入一个表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        public void Write<T>(List<T> source)
        {
            _streamWriter.Write(WriteString(source));
        }

    }

}
