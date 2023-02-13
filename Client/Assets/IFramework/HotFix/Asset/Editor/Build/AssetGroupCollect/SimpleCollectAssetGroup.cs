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

namespace IFramework.Hotfix.Asset
{
    public class SimpleCollectAssetGroup : ICollectAssetGroup
    {
        public void Create(List<AssetInfo> assets, List<AssetInfo> singles, Dictionary<AssetInfo, List<AssetInfo>> dic, List<AssetGroup> result)
        {
            assets.AddRange(singles);
            DefaultCollectAssetGroup.OneFileBundle(assets, result);
        }
    }

}