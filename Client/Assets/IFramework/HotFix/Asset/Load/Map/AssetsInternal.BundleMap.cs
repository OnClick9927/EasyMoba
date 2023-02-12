/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.179
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-07
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

using UnityEngine;
namespace IFramework.Hotfix.Asset
{
    partial class AssetsInternal
    {
        private class BundleMap : NameMap<Bundle, AssetBundle>
        {

            public Bundle LoadAsync(string path,string bundleName, bool encrypt)
            {
                BundleLoadArgs args = new BundleLoadArgs(BundleLoadType.FromFile, path, encrypt, bundleName);
                Bundle bundle = base.LoadAsync(path, args);
                return bundle;
            }
            public Bundle RequestLoadAsync(string url, string bundleName, bool encrypt)
            {
                BundleLoadArgs args = new BundleLoadArgs(BundleLoadType.FromRequest, url, encrypt, bundleName);
                Bundle bundle = base.LoadAsync(url, args);
                return bundle;
            }
            protected override Bundle CreateNew(string path, IEventArgs args)
            {
                BundleLoadArgs arg = (BundleLoadArgs)args;
                if (arg.type == BundleLoadType.FromFile)
                    return new Bundle(arg);
                return new WebRequestBundle(arg);
            }

            public override void Release(string name)
            {
                Bundle result = null;
                if (map.TryGetValue(name, out result))
                {
                    (result as IRefenceAsset).Release();
                    if ((result as IRefenceAsset).count == 0)
                    {
                        (result as IRefenceAsset).UnLoad();
                        map.Remove(name);
                    }
                }
            }
        }
    }
}
