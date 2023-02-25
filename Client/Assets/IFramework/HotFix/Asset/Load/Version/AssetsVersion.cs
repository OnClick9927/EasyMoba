/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.204
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-09
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System.Collections.Generic;

namespace IFramework.Hotfix.Asset
{
    [System.Serializable]
    public class AssetsVersion
    {
        [System.Serializable]
        public class VersionData
        {
            public string bundleName;
            public long length;
            public string md5;
        }
        public string version;
        public List<VersionData> datas = new List<VersionData>();
    }
}
