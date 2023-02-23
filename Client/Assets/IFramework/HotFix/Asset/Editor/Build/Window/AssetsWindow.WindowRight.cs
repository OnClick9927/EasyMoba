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

namespace IFramework.Hotfix.Asset
{
    partial class AssetsWindow
    {
        [System.Serializable]
        private class WindowRight
        {  
            public enum TreeType
            {
                Collect,
                BundlesPreview
            }
            public TreeType treeType = TreeType.Collect;
            [SerializeField] private TreeViewState collectstate = new TreeViewState();
            [SerializeField] private TreeViewState previewstate = new TreeViewState();
            [SerializeField] private CollectTree.SearchType colSearchType = CollectTree.SearchType.Name;
            [SerializeField] private PreviewTree.SearchType preSearchType = PreviewTree.SearchType.AssetByPath;
            private CollectTree col;
            private PreviewTree pre;
            public void OnEnable()
            {
                col = new CollectTree(collectstate, colSearchType);
                pre = new PreviewTree(previewstate, preSearchType);
            }
            public void OnDisable()
            {
                colSearchType = col._searchType;
                preSearchType = pre._searchType;
            }
            public void OnGUI(Rect rect)
            {
                if (treeType == 0)
                {
                    col.OnGUI(rect);
                }
                else
                {
                    pre.OnGUI(rect);
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
