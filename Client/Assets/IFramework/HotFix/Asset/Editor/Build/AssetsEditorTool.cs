/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.204
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-09
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System.Collections.Generic;
using UnityEditor;
namespace IFramework.Hotfix.Asset
{
    [InitializeOnLoad]
    static class AssetsEditorTool
    {
        static AssetsEditorTool()
        {
            ChangeLoadMode();
        }
        public static void ChangeLoadMode()
        {
            AssetsInternal.downloadDirectory = AssetBuildSetting.outputPath;
            if (AssetBuildSetting.Load().fastMode)
            {
                AssetsInternal.mode = new FastAssetMode();
            }
            else
            {
                AssetsInternal.mode = null;
            }
        }

        private static List<string> Assets_GetAllAssetPath()
        {
            var build = AssetBuildSetting.Load();
            List<string> list = new List<string>();
            build.GetAssets().ForEach(asset =>
            {
                if (!asset.IsDirectory())
                {
                    list.Add(asset.path);
                }
            });
            build.GetSingleFiles().ForEach(asset =>
            {
                list.Add(asset);
            });
            return list;
        }

        private static SceneAsset Assets_SceneAssetCreater(bool arg1, Bundle arg2, List<Asset> arg3, SceneAssetLoadArgs arg4)
        {
            return new EditorSceneAsset(arg1, arg4);
        }

        private static Asset Assets_AssetCreater(bool arg1, Bundle arg2, List<Asset> arg3, AssetLoadArgs arg4)
        {
            return new EditorAsset(arg1, arg4);
        }
    }
}
