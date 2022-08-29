/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.179
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-07
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

namespace IFramework.Hotfix.Asset
{
    public abstract class AssetsSetting
    {
        public abstract string GetUrlByBundleName(string buildTarget, string bundleName);
        public abstract string GetVersionUrl();
        public virtual FileCheckType GetFileCheckType() { return FileCheckType.MD5; }
        public virtual int GetWebRequestTimeout() { return 30; }
    }
}
