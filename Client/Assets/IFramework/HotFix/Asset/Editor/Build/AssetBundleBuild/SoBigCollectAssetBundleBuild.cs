/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.204
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-09
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using UnityEditor;
using System.Collections.Generic;

namespace IFramework.Hotfix.Asset
{
    public class SoBigCollectAssetBundleBuild : ICollectAssetBundleBuild
    {
        public void Create(List<AssetInfo> assets, List<AssetInfo> singles, Dictionary<AssetInfo, List<AssetInfo>> dpsDic, List<AssetBundleBuild> result)
        {
            List<AssetInfo> scenes = assets.FindAll(x => x.type == AssetInfo.AssetType.Scene);
            foreach (var item in scenes) assets.Remove(item);
            foreach (var scene in scenes)
            {
                AssetBundleBuild sceneBundle = new AssetBundleBuild();
                sceneBundle.assetBundleName = scene.path;
                sceneBundle.assetNames = new string[] { scene.path };
                result.Add(sceneBundle);
            }
            AssetBundleBuild assetBundle = new AssetBundleBuild();
            assetBundle.assetBundleName = "so big";
            var paths = assets.ConvertAll(asset => asset.path.ToRegularPath());
            paths.AddRange(singles.ConvertAll(asset => asset.path.ToRegularPath()));
            assetBundle.assetNames = paths.ToArray();
            result.Add(assetBundle);
        }
    }

}
