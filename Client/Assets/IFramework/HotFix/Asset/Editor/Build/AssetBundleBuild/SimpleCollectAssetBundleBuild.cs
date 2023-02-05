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
    public class SimpleCollectAssetBundleBuild : ICollectAssetBundleBuild
    {
        public void Create(List<AssetInfo> assets, List<AssetInfo> singles, Dictionary<AssetInfo, List<AssetInfo>> dic, List<AssetBundleBuild> result)
        {
            foreach (var asset in assets)
            {
                var path = asset.path.ToRegularPath();
                AssetBundleBuild assetBundle = new AssetBundleBuild();
                assetBundle.assetBundleName = path;
                assetBundle.assetNames = new string[] { path };
                result.Add(assetBundle);
            }
            foreach (var single in singles)
            {
                var path = single.path.ToRegularPath();
                AssetBundleBuild singleBundle = new AssetBundleBuild();
                singleBundle.assetBundleName = path;
                singleBundle.assetNames = new string[] { path };
                result.Add(singleBundle);
            }
        }
    }

}
