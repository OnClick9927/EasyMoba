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
using IFramework.GUITool;

namespace IFramework.Hotfix.Asset
{
    [EditorWindowCache("AssetsWindow")]
    partial class AssetsWindow : EditorWindow
    {
        private ToolBarTree tree;
        private WindowLeft left = new WindowLeft();
        private WindowRight right = new WindowRight();
        private SplitView sp = new SplitView() { split = 300, minSize = 300 };
        private static AssetsToolSetting toolSetting { get { return AssetsToolSetting.Load<AssetsToolSetting>(); } }
        private static AssetsBuildSetting buildSetting { get { return AssetsBuildSetting.Load<AssetsBuildSetting>(); } }
        private static AssetsEditorCache cache { get { return AssetsEditorCache.Load<AssetsEditorCache>(); } }

        private void JustCollectAssets(bool save)
        {
            cache.Colllect(buildSetting.buildPaths);
            if (save)
            {
                cache.Save();
                right.ReLoad();
            }

        }
        private void PreView(bool md5)
        {
            JustCollectAssets(false);
            cache.previewBundles = AssetsBuild.CollectBundleGroup();
            if (md5)
            {
                cache.previewBundles = AssetsBuild.CollectMain(cache.previewBundles);
            }
            cache.Save();
            right.ReLoad();
        }
        private void CollectShaderVariant()
        {
            AssetsBuild.ShaderVariantCollector.Run(() => { PreView(false); });
        } 
        private void OnDisable()
        {
            right.OnDisable();
        }
        private void OnEnable()
        {
            tree = new ToolBarTree();
            tree.DropDownButton(new GUIContent("Tools"), (rect) =>
            {
                GenericMenu menu = new GenericMenu();
                menu.AddItem(new GUIContent("Help/Build Atlas"), false, AssetsBuild.AtlasBuild.Run);
                menu.AddItem(new GUIContent("Help/Collect Shader Variant"), false, CollectShaderVariant);

                menu.AddItem(new GUIContent("Preview/Just Collect Assets"), false, () => { JustCollectAssets(true); });
                menu.AddItem(new GUIContent("Preview/Bundle"), false, () => { PreView(false); });
                menu.AddItem(new GUIContent("Preview/MD5 Bundle"), false, () => { PreView(true); });


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
                right.treeType = (WindowRight.TreeType)GUI.Toolbar(rect, (int)right.treeType,System.Enum.GetNames(typeof(WindowRight.TreeType)));

            }, 300);


            sp.fistPan += left.OnGUI;
            sp.secondPan += right.OnGUI;
            left.OnEnable();
            right.OnEnable();

        }
        private void OnGUI()
        {
            var rs = this.LocalPosition().HorizontalSplit(20);
            tree.OnGUI(rs[0]);
            sp.OnGUI(rs[1]);
        }
    }
}
