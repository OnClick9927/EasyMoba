/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.179
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-07
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

using System.Collections.Generic;
using Object = UnityEngine.Object;
namespace IFramework.Hotfix.Asset
{
    partial class AssetsInternal
    {
        private class AssetMap : NameMap<Asset, Object>
        {

            public Asset LoadAssetAyync(string path)
            {
                AssetLoadArgs args = new AssetLoadArgs(path);
                Asset asset = base.LoadAsync(path, args);
                return asset;
            }


            public SceneAsset LoadSceneAssetAsync(string path)
            {
                SceneAssetLoadArgs args = new SceneAssetLoadArgs(path);
                SceneAsset asset = this.LoadAsync(path, args) as SceneAsset;
                return asset;
            }
            public override void Release(string path)
            {
                Asset result = null;
                if (map.TryGetValue(path, out result))
                {
                    refs.Release(result);
                    AssetsInternal.ReleseBundleByAssetPath(result.path);
                    ReleaseDpAssets(result.path);
                    if (refs.GetCount(result) == 0)
                    {
                        (result as IAsset).UnLoad();
                        map.Remove(path);
                    }
                }
            }


            private List<Asset> GetDpAssets(string assetPath)
            {
                List<Asset> result = null;
                var paths = GetDps(assetPath);
                if (paths != null)
                {
                    result = new List<Asset>();
                    foreach (var path in paths)
                    {
                        Asset asset = Find(path);
                        if (asset != null)
                        {
                            result.Add(asset);
                        }
                    }
                }
                return result;
            }

            private List<string> GetDps(string assetPath)
            {
                return AssetsInternal.GetAssetDps(assetPath);
            }
            private void ReleaseDpAssets(string assetPath)
            {
                var paths = GetDps(assetPath);
                if (paths != null)
                {
                    foreach (var path in paths)
                    {
                        Release(path);
                    }
                }
            }

            protected override Asset CreateNew(string name, IEventArgs args)
            {
                if (args is AssetLoadArgs)
                    return AssetsInternal.CreateAsset(name, GetDpAssets(name), (AssetLoadArgs)args);
                if (args is SceneAssetLoadArgs)
                    return AssetsInternal.CreateSceneAsset(name, GetDpAssets(name), (SceneAssetLoadArgs)args);
                return null;
            }
        }
    }
}
