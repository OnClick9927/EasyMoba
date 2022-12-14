/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.179
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-07
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using static IFramework.Hotfix.Asset.AssetsInternal;

namespace IFramework.Hotfix.Asset
{
    public partial class Assets
    {
        private static LoadManifestOperation manifestop;
        private static bool IsScene(string path)
        {
            return path.EndsWith("unity");
        }

        public static IReadOnlyList<string> GetAllAssetPaths()
        {
            return AssetsInternal.GetAllAssetPaths();
        }
        public static void SetAssetsSetting(AssetsSetting setting)
        {
            AssetsInternal.SetAssetsSetting(setting);
        }
        public static CheckBundleVersionOperation VersionCheck()
        {
            return new CheckBundleVersionOperation();
        }
        public static DownLoadBundleOperation DownLoadBundle(string bundleName)
        {
            return new DownLoadBundleOperation(bundleName);
        }
        public static bool Initialized()
        {
            if (manifestop == null) return false;
            return manifestop.isDone;
        }

        public static LoadManifestOperation InitAsync(bool again = false)
        {
            if (again)
                manifestop = null;
            if (manifestop == null)
                manifestop = new LoadManifestOperation();
            return manifestop;
        }

        public static Asset LoadAsset(string path)
        {
            if (IsScene(path))
            {
                return LoadSceneAsset(path);
            }
            return AssetsInternal.LoadAsset(path);
        }
        public static Asset LoadAssetAsync(string path)
        {
            if (IsScene(path))
            {
                return LoadSceneAssetAsync(path);
            }
            return AssetsInternal.LoadAssetAsync(path);
        }
        public static SceneAsset LoadSceneAssetAsync(string path)
        {
            return AssetsInternal.LoadSceneAssetAsync(path);
        }
        public static SceneAsset LoadSceneAsset(string path)
        {
            return AssetsInternal.LoadSceneAsset(path);

        }
        public static void Release(Asset asset)
        {
            AssetsInternal.Release(asset);
        }
        public static AssetsGroupOperation PrepareAssets(string[] paths)
        {
            return new AssetsGroupOperation(paths);
        }

        public static InstantiateObjectOperation Instantiate(string path, Transform parent)
        {
            return new InstantiateObjectOperation(path, parent, false);
        }
        public static InstantiateObjectOperation InstantiateAsync(string path, Transform parent)
        {
            return new InstantiateObjectOperation(path, parent, true);
        }
        public static void Destroy(GameObject gameObject)
        {
            InstantiateObjectOperation.Destroy(gameObject);
        }
    }
}
