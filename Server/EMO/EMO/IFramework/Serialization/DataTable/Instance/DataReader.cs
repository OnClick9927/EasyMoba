/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.11f1
 *Date:           2019-09-08
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EMO.IFramework;

namespace IFramework.Serialization.DataTable
{
    /// <summary>
    /// 数据表读者
    /// </summary>
    internal class DataReader : Unit, IDataReader
    {
        private List<List<DataColumn>> _rows;
        private IDataRow _rowReader;
        private IDataExplainer _explainer;
        private TextReader _streamReader;
        private List<string> _headNames;
        public List<string> headNames { get { return _headNames; } }

        public List<List<DataColumn>> rows { get { return _rows; } }
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="streamReader">流读者</param>
        /// <param name="rowReader">行读者</param>
        /// <param name="explainer">数据解释器</param>
        public DataReader(TextReader streamReader, IDataRow rowReader, IDataExplainer explainer)
        {
            this._explainer = explainer;
            this._streamReader = streamReader;
            this._rowReader = rowReader;
            _rows = new List<List<DataColumn>>();
            Read(_streamReader.ReadToEnd());
        }
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="text">数据表字符串</param>
        /// <param name="rowReader">行读者</param>
        /// <param name="explainer">数据解释器</param>
        public DataReader(string text, IDataRow rowReader, IDataExplainer explainer)
        {
            this._explainer = explainer;
            this._rowReader = rowReader;
            _rows = new List<List<DataColumn>>();
            Read(text);
        }
        private void Read(string str)
        {
            List<string> rowValues = str.Replace("\r\n", "\n").Split('\n').ToList();
            string HeadStr = rowValues[0];
            rowValues.RemoveAt(0);
            _headNames = _rowReader.ReadHeadLine(HeadStr);


            if (string.IsNullOrEmpty(rowValues.Last())) rowValues.RemoveAt(rowValues.Count - 1);
            rowValues.ForEach((row) =>
            {
                List<DataColumn> cols = _rowReader.ReadLine(row, headNames);
                _rows.Add(cols);
            });
        }

        /// <summary>
        /// 释放
        /// </summary>
        protected override void OnDispose()
        {
            if (!disposed)
            {
                _headNames.Clear();
                _rows.Clear();
                if (_streamReader != null)
                {
                    _streamReader.Close();
                    _streamReader.Dispose();
                }
            }
        }
        /// <summary>
        /// 获取一张表数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> Get<T>()
        {
            List<T> ts = new List<T>();
            var members = DataTableTool.GetMemberInfo(typeof(T));

            _rows.ForEach((cols) =>
            {
                T t = _explainer.CreatInstance<T>(cols, members);
                if (t != null) ts.Add(t);
            });
            return ts;
        }
    }

}
