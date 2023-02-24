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
        protected virtual string GetBaseUrl() { return string.Empty; }
        public virtual string GetUrlByBundleName(string buildTarget, string bundleName)
        {
            return GetBaseUrl().CombinePath($"{buildTarget}/{bundleName}").ToRegularPath();
        }
        public virtual string GetVersionUrl(string buildTarget)
        {
            return GetBaseUrl().CombinePath($"{buildTarget}/version").ToRegularPath();
        }
        public virtual FileCheckType GetFileCheckType() { return FileCheckType.MD5; }
        public virtual int GetWebRequestTimeout() { return 30; }

        public virtual IAssetStraemEncrypt GetEncrypt() { return new DefaultAssetStraemEncrypt(); }
        public virtual bool GetAutoUnloadBundle() { return true; }

    }
}
