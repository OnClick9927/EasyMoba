/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.179
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-07
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace IFramework.Hotfix.Asset
{
    partial class AssetsInternal
    {


        private class BundleMap : NameMap<Bundle, AssetBundle>
        {
            public Bundle LoadAsync(string path, string bundleName)
            {
                BundleLoadArgs args = new BundleLoadArgs(BundleLoadType.FromFile, path, bundleName);
                Bundle bundle = base.LoadAsync(path, args);
                return bundle;
            }
            public Bundle RequestLoadAsync(string url, string bundleName)
            {
                BundleLoadArgs args = new BundleLoadArgs(BundleLoadType.FromRequest, url, bundleName);
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
                    refs.Release(result);
                    if (!GetAutoUnloadBundle()) return;
                    if (refs.GetCount(result) == 0)
                    {
                        (result as IAsset).UnLoad();
                        map.Remove(name);
                    }
                }
            }
            private List<string> useless = new List<string>();
            public void UnloadBundles()
            {
                if (GetAutoUnloadBundle()) return;
                useless.Clear();
                foreach (var item in map)
                {
                    if (refs.GetCount(item.Value)==0)
                    {
                        useless.Add(item.Key);
                    }
                }
                for (int i = 0; i < useless.Count; i++)
                {
                    string name = useless[i];
                    Bundle result = map[name];
                    (result as IAsset).UnLoad();
                    map.Remove(name);
                }
            }
        }
    }
}
