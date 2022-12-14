/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.204
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-09
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using UnityEditor;
using System.Linq;
using IFramework.GUITool;
using IFramework.GUITool.ToorbarMenu;
using UnityEngine;
using System;
using UnityEditor.IMGUI.Controls;
using System.IO;

namespace IFramework.Hotfix.Asset
{
    [EditorWindowCache("AssetsWindow")]
    partial class AssetsWindow : EditorWindow
    {
        private ToolBarTree tree;
        private SplitView splitView = new SplitView();
        private static CollectTree col;
        private Settings tools = new Settings();
        private TreeViewState state=new TreeViewState();
        private static AssetBuildSetting buildSetting { get { return AssetBuildSetting.Load(); } }
        private static string[] types;
        private static string[] shortTypes;

        private static int typeIndex;
        private static void BuildAtlas()
        {
            AssetsBuild.BuildAtlas();
        }
        private static void Colllect()
        {
            buildSetting.Colllect();
            buildSetting.Save();
            col.Reload();
        }
        private static void BuildBundle()
        {
            var type_str = types[typeIndex];
            Type type = Type.GetType(type_str);
            AssetsBuild.Build(type);
        }
        private static void OpenFolder()
        {
            EditorTools.OpenFolder(AssetBuildSetting.outputPath);
        }
        private static void ClearFolder()
        {
            Directory.Delete(AssetBuildSetting.outputPath, true);
        }
        private void OnEnable()
        {
            tree = new ToolBarTree();
            tree.DropDownButton(new GUIContent("Tools"), (rect) =>
            {
                GenericMenu menu = new GenericMenu();
                menu.AddItem(new GUIContent("Build Atlas"), false, BuildAtlas);
                menu.AddItem(new GUIContent("Collect Asset"), false, Colllect);
                menu.AddItem(new GUIContent("Bundle/Build"), false, BuildBundle);
                menu.AddItem(new GUIContent("Bundle/Open Output Floder"), false, OpenFolder);
                menu.AddItem(new GUIContent("Bundle/Clear Output Floder"), false, ClearFolder);

                menu.DropDown(rect);
            });
            types = typeof(ICollectAssetBundleBuild).GetSubTypesInAssemblys()
                  .Where(type => !type.IsAbstract)
                  .Select(type => type.FullName).ToArray();
            shortTypes = typeof(ICollectAssetBundleBuild).GetSubTypesInAssemblys()
                  .Where(type => !type.IsAbstract)
                  .Select(type => type.Name).ToArray();
            col = new CollectTree(state);
            splitView.fistPan += tools.OnGUI;
            splitView.secondPan += col.OnGUI;
        }
        private void OnGUI()
        {
            var rs = this.LocalPosition().HorizontalSplit(20);
            tree.OnGUI(rs[0]);
            splitView.OnGUI(rs[1]);
        }
    }
}
