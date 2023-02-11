﻿/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.204
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-09
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System.Collections.Generic;
using static IFramework.Hotfix.Asset.AssetsBuild;
using static IFramework.Hotfix.Asset.AssetInfo;

namespace IFramework.Hotfix.Asset
{
    public class SimpleCollectAssetBundleBuild : ICollectAssetBundleBuild
    {
        public void Create(List<AssetInfo> assets, List<AssetInfo> singles, Dictionary<AssetInfo, List<AssetInfo>> dic, List<AssetGroup> result)
        {
            assets.AddRange(singles);
            DefaultCollectAssetBundleBuild.OneFileBundle(assets, result);
        }
    }

}
