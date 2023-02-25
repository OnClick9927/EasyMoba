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
    public struct BundleLoadArgs : IEventArgs
    {
        public BundleLoadType type;
        public string bundleName;
        public string path;

        public BundleLoadArgs(BundleLoadType type, string path,  string bundleName)
        {
            this.type = type;
            this.path = path;
            this.bundleName = bundleName;
        }
    }
}
