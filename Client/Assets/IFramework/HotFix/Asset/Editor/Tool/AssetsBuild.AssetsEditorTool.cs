/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.204
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-09
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System;
using System.Collections.Generic;
using UnityEditor;

namespace IFramework.Hotfix.Asset
{
    partial class AssetsBuild
    {

        public class AssetsEditorTool : AssetsInternal.IAssetLife<Bundle>, AssetsInternal.IAssetLife<Asset>
        {
            private static AssetsEditorTool ins = new AssetsEditorTool();

            [InitializeOnLoadMethod]
            public static void ChangeLoadMode()
            {
                if (tool.fastMode)
                    AssetsInternal.mode = new FastAssetMode();
                AssetsInternal.localSaveDir = outputPath;
                AssetsInternal.SetAssetListen(ins, ins);
                EditorApplication.playModeStateChanged += EditorApplication_playModeStateChanged;
            }
            public static event Action onAssetLifChange;
            private static void EditorApplication_playModeStateChanged(PlayModeStateChange obj)
            {
                switch (obj)
                {
                    case PlayModeStateChange.EnteredEditMode:
                        break;
                    case PlayModeStateChange.ExitingEditMode:
                        break;
                    case PlayModeStateChange.EnteredPlayMode:
                        bundles.Clear();
                        assets.Clear();
                        break;
                    case PlayModeStateChange.ExitingPlayMode:
                        break;
                    default:
                        break;
                }
            }

            public class AssetLife<T> where T : IAsset
            {
                public T asset;
                public System.DateTime time;
                public string path;
                public int count;
                public string tag;
            }
            public static Dictionary<string, AssetLife<Bundle>> bundles = new Dictionary<string, AssetLife<Bundle>>();
            public static Dictionary<string, AssetLife<Asset>> assets = new Dictionary<string, AssetLife<Asset>>();

            public void OnAssetCreate(string path, Bundle asset)
            {
                bundles.Add(path, new AssetLife<Bundle>()
                {
                    asset = asset,
                    time = System.DateTime.Now,
                    path = path,
                    count = 0
                });
                onAssetLifChange?.Invoke();
            }
            public void OnAssetRetain(Bundle asset, int count)
            {
                bundles[asset.path].count = count;
                onAssetLifChange?.Invoke();

            }
            public void OnAssetRelease(Bundle asset, int count)
            {
                bundles[asset.path].count = count;
                onAssetLifChange?.Invoke();

            }
            public void OnAssetUnload(string path, Bundle asset)
            {
                bundles.Remove(path);
                onAssetLifChange?.Invoke();

            }



            public void OnAssetCreate(string path, Asset asset)
            {
                assets.Add(path, new AssetLife<Asset>()
                {
                    asset = asset,
                    time = System.DateTime.Now,
                    path = path,
                    count = 0,
                    tag = AssetsInternal.GetAssetTag(path)
                });
                onAssetLifChange?.Invoke();

            }


            public void OnAssetRelease(Asset asset, int count)
            {
                assets[asset.path].count = count;
                onAssetLifChange?.Invoke();

            }



            public void OnAssetRetain(Asset asset, int count)
            {
                assets[asset.path].count = count;
                onAssetLifChange?.Invoke();

            }



            public void OnAssetUnload(string path, Asset asset)
            {
                assets.Remove(path);
                onAssetLifChange?.Invoke();

            }
        }
    }

}
