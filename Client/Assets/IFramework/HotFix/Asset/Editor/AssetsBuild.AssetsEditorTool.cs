﻿/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.204
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-09
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using UnityEditor;
namespace IFramework.Hotfix.Asset
{
    partial class AssetsBuild
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
                if (tool.fastMode)
                    AssetsInternal.mode = new FastAssetMode();
                AssetsInternal.localSaveDir = outputPath;
            }
        }
    }

}