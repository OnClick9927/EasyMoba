/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.204
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-09
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using System.Collections.Generic;
using Object = UnityEngine.Object;
using UnityEngine;
using System.IO;
using IFramework.GUITool;
using static UnityEditor.Progress;
using UnityEditor.TreeViewExamples;

namespace IFramework.Hotfix.Asset
{
    partial class AssetsWindow
    {
        private class CollectTree : TreeView
        {
            public CollectTree(TreeViewState state) : base(state)
            {
                this.Reload();
                showAlternatingRowBackgrounds = true;
                this.multiColumnHeader = new MultiColumnHeader(new MultiColumnHeaderState(new MultiColumnHeaderState.Column[]
                {
                    new MultiColumnHeaderState.Column()
                    {

                    },
                    new MultiColumnHeaderState.Column()
                    {
                         headerContent=new UnityEngine.GUIContent("Type")
                    },

                }));
                this.multiColumnHeader.ResizeToFit();
            }
            protected override TreeViewItem BuildRoot()
            {
                return new TreeViewItem() { id = -10, depth = -1 };
            }

            protected override IList<TreeViewItem> BuildRows(TreeViewItem root)
            {
                var result = GetRows() ?? new List<TreeViewItem>();
                result.Clear();
                BuildDirs(result, root, buildSetting.GetRootDirPaths());
                BuildFiles(result, root, buildSetting.GetSingleFiles());
                SetupParentsAndChildrenFromDepths(root, result);
                return result;
            }
            protected override void DoubleClickedItem(int id)
            {
                var rows = this.FindRows(new List<int>() { id });
                EditorGUIUtility.PingObject(AssetDatabase.LoadAssetAtPath<Object>(rows[0].displayName));
            }





            protected override void RowGUI(RowGUIArgs args)
            {
                float indet = this.GetContentIndent(args.item);
                var first = args.GetCellRect(0).Zoom(AnchorType.MiddleRight, new Vector2(-indet, 0));
                GUI.Label(first, new GUIContent(Path.GetFileName(args.label), args.item.icon));
                var type = buildSetting.GetAssetInfo(args.label).type;
                if (type != AssetInfo.AssetType.Directory)
                {
                    GUI.Label(args.GetCellRect(1), type.ToString());
                }
            }






            private static TreeViewItem CreateItem(string path, TreeViewItem parrent, IList<TreeViewItem> result)
            {
                Object o = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(path);
                var _item = new TreeViewItem()
                {
                    id = o.GetInstanceID(),
                    depth = parrent.depth + 1,
                    displayName = path,
                    parent = parrent,
                    icon = AssetPreview.GetMiniThumbnail(AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(path))
                };
                parrent.AddChild(_item);
                result.Add(_item);
                return _item;
            }
            private void BuildDirs(IList<TreeViewItem> result, TreeViewItem parrent, List<AssetInfo> dirs)
            {
                foreach (var path in dirs)
                {
                    LoopCreate(result, parrent, path);
                }
            }
            private static void BuildFiles(IList<TreeViewItem> result, TreeViewItem parrent, List<AssetInfo> paths)
            {
                foreach (var _path in paths)
                {
                    CreateItem(_path.path, parrent, result);
                }
            }
            private void LoopCreate(IList<TreeViewItem> result, TreeViewItem parrent, AssetInfo info)
            {
                var item = CreateItem(info.path, parrent, result);
                var paths = buildSetting.GetSubFloders(info);
                var filepaths = buildSetting.GetSubFiles(info);
                if (paths.Count > 0 || filepaths.Count > 0)
                {
                    if (IsExpanded(item.id))
                    {
                        BuildDirs(result, item, paths);
                        BuildFiles(result, item, filepaths);
                    }
                    else
                    {
                        item.children = CreateChildListForCollapsedParent();
                    }
                }

            }
        }
    }
}
