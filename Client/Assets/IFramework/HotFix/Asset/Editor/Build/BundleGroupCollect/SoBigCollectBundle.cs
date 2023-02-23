/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.204
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-09
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System.Collections.Generic;
using static IFramework.Hotfix.Asset.AssetInfo;
using static IFramework.Hotfix.Asset.AssetsBuild;

namespace IFramework.Hotfix.Asset
{
    public class SoBigCollectBundle : ICollectBundle
    {
        public void Create(List<AssetInfo> assets, Dictionary<AssetInfo, List<AssetInfo>> dpsDic, List<BundleGroup> result)
        {
            DefaultCollectBundle.OneFileBundle(assets, AssetType.Scene, result);
            DefaultCollectBundle.AllInOneBundle_ALL(assets, "so_big", result);
        }
    }

}
