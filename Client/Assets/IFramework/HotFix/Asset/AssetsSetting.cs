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
        public enum FileCheckType
        {
            MD5,
            FileLength
        }
        public abstract string GetUrlByBundleName(string buildTarget, string bundleName);
        public abstract string GetVersionUrl(string buildTarget);
        public virtual FileCheckType GetFileCheckType() { return FileCheckType.MD5; }
        public virtual int GetWebRequestTimeout() { return 30; }

        public virtual IAssetStraemEncrypt GetEncrypt() { return new DefaultAssetStraemEncrypt(); }
        public virtual bool GetAutoUnloadBundle() { return true; }

    }
}
