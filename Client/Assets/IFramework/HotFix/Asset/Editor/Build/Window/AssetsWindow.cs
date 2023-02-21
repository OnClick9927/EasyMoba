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
using IFramework.GUITool;
using UnityEditorInternal.VR;
using UnityEngine.UIElements;

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
        private SplitView sp = new SplitView() { split = 300, minSize = 300 };
        private Editor editor;
        private enum TreeType
        {
            Collect,
            BundlesPreview
        }
        private TreeType treeType = TreeType.Collect;

        private static AssetBuildSetting buildSetting { get { return AssetBuildSetting.Load(); } }
        private static AssetEditorCache cache { get { return AssetEditorCache.Load(); } }


        private void JustCollectAssets()
        {
            cache.Colllect(buildSetting.GetBuildPaths());
            cache.Save();
            col.Reload();
        }
        private void PreView()
        {
            cache.Colllect(buildSetting.GetBuildPaths());
            cache.previewBundles = AssetsBuild.CollectAssetGroup();
            cache.Save();
            col.Reload();
            pre.Reload();
            //treeType = TreeType.Group;
        }
        private void PreViewMD5()
        {
            cache.Colllect(buildSetting.GetBuildPaths());
            cache.previewBundles = AssetsBuild.CollectMain(AssetsBuild.CollectAssetGroup());
            cache.Save();
            col.Reload();
            pre.Reload();
            //EditorGUIUtility.PingObject(EditorTools.AssetTool.Load<AssetManifest>(AssetManifest.Path));
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
                menu.AddItem(new GUIContent("Help/Build Atlas"), false, AssetsBuild.BuildAtlas);
                menu.AddItem(new GUIContent("Help/Collect Shader Variant"), false, CollectShaderVariant);

                menu.AddItem(new GUIContent("Preview/Just Collect Assets"), false, JustCollectAssets);
                menu.AddItem(new GUIContent("Preview/Bundle"), false, PreView);
                menu.AddItem(new GUIContent("Preview/MD5 Bundle"), false, PreViewMD5);


                menu.AddSeparator("");
                menu.AddItem(new GUIContent("Bundle/Build"), false, AssetsBuild.Build);
                menu.AddItem(new GUIContent("Bundle/Copy To Steam"), false, AssetsBuild.CopyToStreamPath);

                menu.AddItem(new GUIContent("Output/Open Floder"), false, AssetsBuild.OpenOutputFloder);
                menu.AddItem(new GUIContent("Output/Clear Floder"), false, AssetsBuild.ClearOutputFloder);

                menu.DropDown(rect);
            })
            .FlexibleSpace()
            .Delegate(rect =>
            {
                treeType = (TreeType)GUI.Toolbar(rect, (int)treeType, new string[] { "Assets", "Bundle Preview" });

            }, 200);
            col = new CollectTree(collectstate);
            pre = new PreviewTree(previewstate);
            sp.fistPan += Sp_fistPan;
            sp.secondPan += Sp_secondPan;
            editor = Editor.CreateEditor(buildSetting);
        }

        private void Sp_secondPan(Rect obj)
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
        Vector2 scroll;
        private void Sp_fistPan(Rect obj)
        {
            GUILayout.BeginArea(obj);
            scroll = GUILayout.BeginScrollView(scroll);
            editor.OnInspectorGUI();
            GUILayout.EndScrollView();
            GUILayout.EndArea();
        }


        private void OnGUI()
        {
            var rs = this.LocalPosition().HorizontalSplit(20);
            tree.OnGUI(rs[0]);
            sp.OnGUI(rs[1]);
        }
    }
}
