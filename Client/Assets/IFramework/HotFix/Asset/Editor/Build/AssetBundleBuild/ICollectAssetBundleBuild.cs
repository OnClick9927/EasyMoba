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
    public interface ICollectAssetBundleBuild
    {
        void Create(List<AssetInfo> assets, List<string> singles, Dictionary<AssetInfo, List<AssetInfo>> dpsDic, List<AssetBundleBuild> result);
    }
}
