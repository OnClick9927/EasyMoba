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
using System.Collections.Generic;

namespace IFramework.Hotfix.Asset
{
    [EditorWindowCache("AssetsWindow")]
    partial class AssetsWindow : EditorWindow
    {
        private ToolBarTree tree;
        private SplitView splitView = new SplitView();
        private CollectTree col;
        private PreviewTree pre;
        private Settings tools = new Settings();
        private TreeViewState collectstate = new TreeViewState();
        private TreeViewState previewstate = new TreeViewState();
        private int treeType = 0;

        private static AssetBuildSetting buildSetting { get { return AssetBuildSetting.Load(); } }
        private string[] types;
        private string[] shortTypes;
        private int typeIndex;
        private List<AssetBundleBuild> previewBundles;

        private void BuildAtlas()
        {
            AssetsBuild.BuildAtlas();
        }
        private void Colllect()
        {
            buildSetting.Colllect();
            buildSetting.Save();
            col.Reload();
        }
        private void BuildBundle()
        {
            var type_str = types[typeIndex];
            Type type = Type.GetType(type_str);
            AssetsBuild.Build(type);
        }
        private void OpenFolder()
        {
            EditorTools.OpenFolder(AssetBuildSetting.outputPath);
        }
        private void ClearFolder()
        {
            Directory.Delete(AssetBuildSetting.outputPath, true);
        }
        private void PreView()
        {
            Colllect();
            var type_str = types[typeIndex];
            Type type = Type.GetType(type_str);
            previewBundles = AssetsBuild.ColectAssetBundleBuild(type);
            pre.Reload();
            treeType = 1;
        }
        private void OnEnable()
        {
            tree = new ToolBarTree();
            tree.DropDownButton(new GUIContent("Tools"), (rect) =>
            {
                GenericMenu menu = new GenericMenu();
                menu.AddItem(new GUIContent("Build Atlas"), false, BuildAtlas);
                menu.AddItem(new GUIContent("Collect Asset"), false, Colllect);
                menu.AddItem(new GUIContent("Bundle/Preview"), false, PreView);
                menu.AddItem(new GUIContent("Bundle/Build"), false, BuildBundle);

                menu.AddItem(new GUIContent("Bundle/Open Output Floder"), false, OpenFolder);
                menu.AddItem(new GUIContent("Bundle/Clear Output Floder"), false, ClearFolder);

                menu.DropDown(rect);
            })
            .Delegate(rect =>
            {
                treeType = GUI.Toolbar(rect, treeType, new GUIContent[] {
                new GUIContent("Collect"),
                new GUIContent("Preview")

            });
            },150);
            types = typeof(ICollectAssetBundleBuild).GetSubTypesInAssemblys()
                  .Where(type => !type.IsAbstract)
                  .Select(type => type.FullName).ToArray();
            shortTypes = typeof(ICollectAssetBundleBuild).GetSubTypesInAssemblys()
                  .Where(type => !type.IsAbstract)
                  .Select(type => type.Name).ToArray();
            col = new CollectTree(collectstate);
            pre = new PreviewTree(previewstate, this);
            splitView.minSize = 150;
            splitView.fistPan += tools.OnGUI;
            splitView.secondPan += ContentGUI;
            tools.window = this;
        }

        private void ContentGUI(Rect obj)
        {
            if (treeType == 0)
            {
                col.OnGUI(obj);
            }
            else
            {
                pre.OnGUI(obj);
            }
        }

        private void OnGUI()
        {
            var rs = this.LocalPosition().HorizontalSplit(20);
            tree.OnGUI(rs[0]);
            splitView.OnGUI(rs[1]);
        }
    }
}
