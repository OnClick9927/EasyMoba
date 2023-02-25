/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.204
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-09
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using UnityEngine;
using UnityEditor.IMGUI.Controls;
using static IFramework.Hotfix.Asset.AssetsBuild;

namespace IFramework.Hotfix.Asset
{


    partial class AssetsWindow
    {
        [System.Serializable]
        private class WindowRight
        {
            public enum TreeType
            {
                Assets,
                Bundles,
                AssetLife
            }
            public TreeType treeType = TreeType.Assets;
            [SerializeField] private TreeViewState collectstate = new TreeViewState();
            [SerializeField] private TreeViewState previewstate = new TreeViewState();
            [SerializeField] private TreeViewState rtstate = new TreeViewState();

            [SerializeField] private CollectTree.SearchType colSearchType = CollectTree.SearchType.Name;
            [SerializeField] private PreviewTree.SearchType preSearchType = PreviewTree.SearchType.AssetByPath;
            [SerializeField] private RTTree.SearchType rtSearchType = RTTree.SearchType.Asset;

            private CollectTree col;
            private PreviewTree pre;
            private RTTree rt;

            public void OnEnable()
            {
                col = new CollectTree(collectstate, colSearchType);
                pre = new PreviewTree(previewstate, preSearchType);
                rt = new RTTree(rtstate, rtSearchType);
                AssetsEditorTool.onAssetLifChange += rt.Reload;
            }
            public void OnDisable()
            {
                colSearchType = col._searchType;
                preSearchType = pre._searchType;
                rtSearchType = rt._searchType;
                AssetsEditorTool.onAssetLifChange -= rt.Reload;
            }
            public void OnGUI(Rect rect)
            {
                switch (treeType)
                {
                    case TreeType.Assets:
                        col.OnGUI(rect);
                        break;
                    case TreeType.Bundles:
                        pre.OnGUI(rect);
                        break;
                    case TreeType.AssetLife:
                        rt.OnGUI(rect);
                        break;
                    default:
                        break;
                }

            }
            public void ReLoad()
            {
                col.Reload();
                pre.Reload();
            }
        }
    }
}
