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
    class FastAssetMode : IAssetMode
    {
        public Asset CreateAsset(string assetPath, List<Asset> dps, AssetLoadArgs arg)
        {
            return new EditorAsset(arg);
        }

        public IReadOnlyList<string> GetAllAssetPaths()
        {
            var cache = AssetEditorCache.Load();
            List<string> list = new List<string>();
            cache.GetAssets().ForEach(asset =>
            {
                if (asset.type != AssetInfo.AssetType.Directory)
                {
                    list.Add(asset.path);
                }
            });
            cache.GetSingleFiles().ForEach(asset =>
            {
                list.Add(asset.path);
            });
            return list;
        }

        public SceneAsset CreateSceneAsset(string assetPath, List<Asset> dps, SceneAssetLoadArgs arg)
        {
            return new EditorSceneAsset(arg);
        }

        public IReadOnlyList<string> GetTagAssetPaths(string tag)
        {
            var cache = AssetEditorCache.Load();
            return cache.GetTagAssetPaths(tag);
        }
    }
}
