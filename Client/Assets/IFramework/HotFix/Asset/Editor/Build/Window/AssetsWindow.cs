/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.204
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-09
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using UnityEditor;
using IFramework.GUITool.ToorbarMenu;
using UnityEngine;
using UnityEditor.IMGUI.Controls;

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
            BundlesPreview
        }
        private TreeType treeType = TreeType.Collect;

        private static AssetBuildSetting buildSetting { get { return AssetBuildSetting.Load(); } }
        private static AssetEditorCache cache { get { return AssetEditorCache.Load(); } }



        private void PreView()
        {
            cache.Colllect(buildSetting.GetBuildPaths());
            cache.previewBundles = AssetsBuild.CollectAssetGroup();
            cache.Save();
            col.Reload();
            pre.Reload();
            //treeType = TreeType.Group;
        }
        private void CollectShaderVariant()
        {
            AssetsBuild.CollectShaderVariant(PreView);
        }
        private void OnEnable()
        {
            tree = new ToolBarTree();
            tree.DropDownButton(new GUIContent("Tools"), (rect) =>
            {
                GenericMenu menu = new GenericMenu();
                menu.AddItem(new GUIContent("Edit Setting(Inspector)"), false, () => { Selection.activeObject = buildSetting; });
                menu.AddItem(new GUIContent("Build Atlas"), false, AssetsBuild.BuildAtlas);
                menu.AddItem(new GUIContent("Collect Shader Variant"), false, CollectShaderVariant);


                menu.AddItem(new GUIContent("Collect Asset"), false, PreView);

                menu.AddSeparator("");
                //menu.AddItem(new GUIContent("Bundle/Group Preview"), false, PreView);
                menu.AddItem(new GUIContent("Bundle/Build"), false, AssetsBuild.Build);
                menu.AddItem(new GUIContent("Bundle/Copy To Steam"), false, AssetsBuild.CopyToStreamPath);

                menu.AddItem(new GUIContent("Output/Open Floder"), false, AssetsBuild.OpenOutputFloder);
                menu.AddItem(new GUIContent("Output/Clear Floder"), false, AssetsBuild.ClearOutputFloder);

                menu.DropDown(rect);
            })
            .FlexibleSpace()
            .Delegate(rect =>
            {
                treeType = (TreeType)GUI.Toolbar(rect, (int)treeType,new string[] {"Assets","Bundle Preview"});

            }, 200);
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
