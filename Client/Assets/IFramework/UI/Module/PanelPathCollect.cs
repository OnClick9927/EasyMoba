/*********************************************************************************
 *Author:         OnClick
 *Version:        1.0
 *UnityVersion:   2020.3.3f1c1
 *Date:           2022-08-07
 *Description:    Description
 *History:        2022-08-07--
*********************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using IFramework;
using UnityEngine;

namespace IFramework.UI
{
    [System.Serializable]
    public class PanelPathCollect
    {
        [System.Serializable]
        public class Data
        {
            public string name { get { return System.IO.Path.GetFileNameWithoutExtension(path); } }
            public string path;
            public bool isResourcePath;
        }
        public List<Data> datas = new List<Data>();
        public void WriteData(List<Data> datas)
        {
            this.datas = datas;
        }
        public Data GetData(string path)
        {
            return datas.Find(x => x.path == path);
        }
    }
}
