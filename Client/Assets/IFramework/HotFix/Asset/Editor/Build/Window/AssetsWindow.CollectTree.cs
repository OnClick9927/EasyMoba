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
using System.Runtime.CompilerServices;

namespace IFramework.Hotfix.Asset
{
    partial class AssetsWindow
    {
        private class CollectTree : TreeView
        {
            private enum SearchType
            {
                Name,
                Tag
            }
            private GUITool.SearchField search;
            public CollectTree(TreeViewState state) : base(state)
            {
                this.Reload();
                search = new GUITool.SearchField(this.searchString, System.Enum.GetNames(typeof(SearchType)), 0);
                search.onValueChange += (value) => { this.searchString = value.ToLower(); };
                showAlternatingRowBackgrounds = true;
                this.multiColumnHeader = new MultiColumnHeader(new MultiColumnHeaderState(new MultiColumnHeaderState.Column[]
                {
                    new MultiColumnHeaderState.Column()
                    {
                        minWidth=400
                    },
                    new MultiColumnHeaderState.Column()
                    {
                         headerContent=new UnityEngine.GUIContent("Type"),
                         maxWidth=200
                    },
                    new MultiColumnHeaderState.Column()
                    {
                         headerContent=new UnityEngine.GUIContent("Tag"),
                           maxWidth=200
                    },

                }));
                this.multiColumnHeader.ResizeToFit();
            }
            protected override void SearchChanged(string newSearch)
            {
                Reload();
            }
            protected override TreeViewItem BuildRoot()
            {
                return new TreeViewItem() { id = -10, depth = -1 };
            }

            protected override IList<TreeViewItem> BuildRows(TreeViewItem root)
            {
                var result = GetRows() ?? new List<TreeViewItem>();
                result.Clear();
                if (string.IsNullOrEmpty(this.searchString))
                {
                    BuildDirs(result, root, cache.GetRootDirPaths());
                    BuildFiles(result, root, cache.GetSingleFiles());
                }
                else
                {
                    BuildDirsForSearch(result, root, cache.GetRootDirPaths());
                    BuildFilesForSearch(result, root, cache.GetSingleFiles());
                }
                SetupParentsAndChildrenFromDepths(root, result);
                return result;
            }
            protected override void DoubleClickedItem(int id)
            {
                var rows = this.FindRows(new List<int>() { id });
                EditorGUIUtility.PingObject(AssetDatabase.LoadAssetAtPath<Object>(rows[0].displayName));
            }
            public override void OnGUI(Rect rect)
            {
                var rs = rect.HorizontalSplit(20);
                search.OnGUI(rs[0]);
                base.OnGUI(rs[1]);
            }

            protected override void ContextClicked()
            {
                var select = this.GetSelection();
                List<string> paths = new List<string>();
                foreach (var item in select)
                {
                    string path = this.FindItem(item, this.rootItem).displayName;
                    paths.Add(path);
                }
                GenericMenu menu = new GenericMenu();
                var tags = buildSetting.GetTags();
                foreach (var tag in tags)
                {
                    menu.AddItem(new GUIContent($"SetTag/{tag}"), false, () =>
                    {
                        cache.AddAsset(tag, paths);
                    });
                }
                menu.AddItem(new GUIContent("RemoveTag"), false, () =>
                {
                    cache.RemoveAsset(paths);
                });
                menu.ShowAsContext();
            }


            protected override void RowGUI(RowGUIArgs args)
            {
                float indet = this.GetContentIndent(args.item);
                var first = args.GetCellRect(0).Zoom(AnchorType.MiddleRight, new Vector2(-indet, 0));
                GUI.Label(first, new GUIContent(Path.GetFileName(args.label), args.item.icon));
                var info = cache.GetAssetInfo(args.label);
                if (info.type != AssetInfo.AssetType.Directory)
                {
                    GUI.Label(args.GetCellRect(1), info.type.ToString());
                    GUI.Label(args.GetCellRect(2), cache.GetTag(info.path));
                }
            }


            private void LoopCreateForSearch(IList<TreeViewItem> result, TreeViewItem root, AssetInfo info)
            {
                var paths = cache.GetSubFloders(info);
                var filepaths = cache.GetSubFiles(info);
                if (paths.Count > 0 || filepaths.Count > 0)
                {
                    BuildDirsForSearch(result, root, paths);
                    BuildFilesForSearch(result, root, filepaths);
                }

            }
            private void BuildDirsForSearch(IList<TreeViewItem> result, TreeViewItem parrent, List<AssetInfo> dirs)
            {
                foreach (var path in dirs)
                {
                    LoopCreateForSearch(result, parrent, path);
                }
            }
            private void BuildFilesForSearch(IList<TreeViewItem> result, TreeViewItem parrent, List<AssetInfo> paths)
            {
                foreach (var _path in paths)
                {
                    SearchType type = (SearchType)this.search.mode;
                    var source = string.Empty;
                    switch (type)
                    {
                        case SearchType.Name:
                            source = Path.GetFileName(_path.path);
                            break;
                        case SearchType.Tag:
                            source = cache.GetTag(_path.path);
                            break;
                    }
                    if (string.IsNullOrEmpty(source)) continue;
                    source = source.ToLower();
                    bool could = source.Contains(this.searchString);
                    if (could)
                    {
                        CreateItem(_path.path, parrent, result);    
                    }
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
                var paths = cache.GetSubFloders(info);
                var filepaths = cache.GetSubFiles(info);
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
