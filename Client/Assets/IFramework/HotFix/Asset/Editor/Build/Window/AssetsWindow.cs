/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.204
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-09
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using UnityEditor;
using IFramework.GUITool;
using IFramework.GUITool.ToorbarMenu;
using UnityEngine;
using UnityEditor.IMGUI.Controls;
using System.IO;
using System;

namespace IFramework.Hotfix.Asset
{
    [EditorWindowCache("AssetsWindow")]
    partial class AssetsWindow : EditorWindow
    {
        private ToolBarTree tree;
        private CollectTree col;
        private PreviewTree pre;
        private TreeViewState collectstate = new TreeViewState();
        private TreeViewState previewstate = new TreeViewState();
        private enum TreeType
        {
            Collect,
            Preview
        }
        private TreeType treeType = TreeType.Collect;

        private static AssetBuildSetting buildSetting { get { return AssetBuildSetting.Load(); } }
        private static AssetEditorCache cache { get { return AssetEditorCache.Load(); } }


        private void Colllect()
        {
            cache.Colllect(buildSetting.GetBuildPaths());
            cache.Save();
            col.Reload();
            treeType = TreeType.Collect;
        }
        private void PreView()
        {
            Colllect();
            cache.previewBundles = AssetsBuild.ColectAssetGroup();
            cache.Save();
            pre.Reload();
            treeType = TreeType.Preview;
        }
        private void OnEnable()
        {
            tree = new ToolBarTree();
            tree.DropDownButton(new GUIContent("Tools"), (rect) =>
            {
                GenericMenu menu = new GenericMenu();
                menu.AddItem(new GUIContent("Edit Setting(Inspector)"), false, () => { Selection.activeObject = buildSetting; });
                menu.AddItem(new GUIContent("Build Atlas"), false, AssetsBuild.BuildAtlas);
                menu.AddItem(new GUIContent("Collect Asset"), false, Colllect);
                menu.AddSeparator("");
                menu.AddItem(new GUIContent("Bundle/Preview"), false, PreView);
                menu.AddItem(new GUIContent("Bundle/Build"), false, AssetsBuild.Build);
                menu.AddItem(new GUIContent("Bundle/Copy To Steam"), false, AssetsBuild.CopyToStreamPath);

                menu.AddItem(new GUIContent("Open Output Floder"), false, AssetsBuild.OpenOutputFloder);
                menu.AddItem(new GUIContent("Clear Output Floder"), false, AssetsBuild.ClearOutputFloder);

                menu.DropDown(rect);
            })
            .Delegate(rect =>
            {
                treeType = (TreeType)GUI.Toolbar(rect, (int)treeType, Enum.GetNames(typeof(TreeType)));

            }, 150);
            col = new CollectTree(collectstate);
            pre = new PreviewTree(previewstate, this);

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
            ContentGUI(rs[1]);
        }
    }
}
