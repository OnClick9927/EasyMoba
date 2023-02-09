/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.179
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-07
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

using System.Collections.Generic;
namespace IFramework.Hotfix.Asset
{
    public interface IAssetMode
    {
        string GetLocalBundleSaveDirectory();
        Asset CreateAsset(string assetPath, List<Asset> dps, AssetLoadArgs arg);
        SceneAsset CreateSceneAsset(string assetPath, List<Asset> dps, SceneAssetLoadArgs arg);
        IReadOnlyList<string> GetAllAssetPaths();
    }
}
