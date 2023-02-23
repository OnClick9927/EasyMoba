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
        private Editor buildSetting_editor;
        private Editor toolSetting_editor;

        private enum TreeType
        {
            Collect,
            BundlesPreview
        }
        private TreeType treeType = TreeType.Collect;

        private static AssetsToolSetting toolSetting { get { return AssetsToolSetting.Load<AssetsToolSetting>(); } }

        private static AssetsBuildSetting buildSetting { get { return AssetsBuildSetting.Load<AssetsBuildSetting>(); } }
        private static AssetsEditorCache cache { get { return AssetsEditorCache.Load<AssetsEditorCache>(); } }


        private void JustCollectAssets()
        {
            cache.Colllect(buildSetting.GetBuildPaths());
            cache.Save();
            col.Reload();
        }
        private void PreView()
        {
            cache.Colllect(buildSetting.GetBuildPaths());
            cache.previewBundles = AssetsBuild.CollectBundleGroup();
            cache.Save();
            col.Reload();
            pre.Reload();
            //treeType = TreeType.Group;
        }
        private void PreViewMD5()
        {
            cache.Colllect(buildSetting.GetBuildPaths());
            cache.previewBundles = AssetsBuild.CollectMain(AssetsBuild.CollectBundleGroup());
            cache.Save();
            col.Reload();
            pre.Reload();
            //EditorGUIUtility.PingObject(EditorTools.AssetTool.Load<AssetManifest>(AssetManifest.Path));
            //treeType = TreeType.Group;
        }
        private void CollectShaderVariant()
        {
            AssetsBuild.ShaderVariantCollector.Run(PreView);
        }
        private void OnEnable()
        {
            tree = new ToolBarTree();
            tree.DropDownButton(new GUIContent("Tools"), (rect) =>
            {
                GenericMenu menu = new GenericMenu();
                menu.AddItem(new GUIContent("Help/Build Atlas"), false, AssetsBuild.AtlasBuild.Run);
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
            buildSetting_editor = Editor.CreateEditor(buildSetting);
            toolSetting_editor = Editor.CreateEditor(toolSetting);

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
            toolSetting_editor.OnInspectorGUI();
            GUILayout.Space(10);
            buildSetting_editor.OnInspectorGUI();
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
