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
    partial class AssetsInternal
    {
        private class NomalAssetMode : IAssetMode
        {
            public Asset CreateAsset(bool async, string assetPath, List<Asset> dps, AssetLoadArgs arg)
            {
                return new Asset(async, LoadTargetBundle(assetPath, async), dps, arg);
            }

            public IReadOnlyList<string> GetAllAssetPaths()
            {
                return IsManifestNull() ? null : manifest.GetAssets();
            }

            public SceneAsset CreateSceneAsset(bool async, string assetPath, List<Asset> dps, SceneAssetLoadArgs arg)
            {
                return new SceneAsset(async, LoadTargetBundle(assetPath, async), dps, arg);
            }
        }
    }
}
