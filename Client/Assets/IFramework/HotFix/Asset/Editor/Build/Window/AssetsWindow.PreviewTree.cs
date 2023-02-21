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
using static IFramework.Hotfix.Asset.AssetsBuild;

namespace IFramework.Hotfix.Asset
{
    partial class AssetsWindow
    {
        private class PreviewTree : TreeView
        {
            private enum SearchType
            {
                Bundle,
                AssetByPath,
                AssetByTag

            }
            List<AssetGroup> previewBundles { get { return cache.previewBundles; } }

            private GUITool.SearchField search;

            public PreviewTree(TreeViewState state) : base(state)
            {
                search = new GUITool.SearchField(this.searchString, System.Enum.GetNames(typeof(SearchType)), 0);
                search.onValueChange += (value) => { this.searchString = value.ToLower(); };
                search.onModeChange += (value) => { this.Reload(); };

                showAlternatingRowBackgrounds = true;

                this.multiColumnHeader = new MultiColumnHeader(new MultiColumnHeaderState(new MultiColumnHeaderState.Column[]
                {
                    new MultiColumnHeaderState.Column()
                    {
                        minWidth=400
                    },
                    new MultiColumnHeaderState.Column()
                    {
                         headerContent=new UnityEngine.GUIContent("Size"),
                         maxWidth=150
                    },
                       new MultiColumnHeaderState.Column()
                    {
                         headerContent=new UnityEngine.GUIContent("Tag"),
                             maxWidth=150
                    },

               }));

                this.multiColumnHeader.ResizeToFit();
                Reload();
            }


            protected override void SearchChanged(string newSearch)
            {
                Reload();
            }
            public override void OnGUI(Rect rect)
            {
                var rs = rect.HorizontalSplit(20);
                search.OnGUI(rs[0]);
                base.OnGUI(rs[1]);
            }

            protected override TreeViewItem BuildRoot()
            {
                return new TreeViewItem() { id = -10, depth = -1 };
            }
            private static TreeViewItem CreateItem(string path, TreeViewItem parrent, IList<TreeViewItem> result)
            {
                Object o = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(path);
                var _item = new TreeViewItem()
                {
                    id = o.GetInstanceID(),
                    depth = 1,
                    displayName = path,
                    icon = AssetPreview.GetMiniThumbnail(AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(path))
                };
                _item.parent = parrent;
                parrent.AddChild(_item);
                result.Add(_item);
                return _item;
            }

            private TreeViewItem BuildBundle(int i, TreeViewItem root, IList<TreeViewItem> result)
            {
                var bundle = previewBundles[i];
                var _item = new TreeViewItem()
                {
                    id = i,
                    depth = 0,
                    parent = root,
                    displayName = bundle.name,
                    icon = EditorGUIUtility.TrIconContent("Folder Icon").image as Texture2D,
                    

                };
                root.AddChild(_item);
                result.Add(_item);
                return _item;
            }
            private void InnerBuildRows(TreeViewItem root, IList<TreeViewItem> result)
            {
                SearchType type = (SearchType)this.search.mode;
                for (int i = 0; i < previewBundles.Count; i++)
                {
                    var bundle = previewBundles[i];

                    if (string.IsNullOrEmpty(searchString))
                    {

                        var _item = BuildBundle(i, root, result);
                        if (bundle.assets.Count <= 0) continue;
                        if (IsExpanded(_item.id))
                        {
                            for (int j = 0; j < bundle.assets.Count; j++)
                            {
                                var path = bundle.assets[j];
                                CreateItem(path, _item, result);
                            }
                        }
                        else
                        {
                            _item.children = CreateChildListForCollapsedParent();
                        }
                    }
                    else
                    {
                        if (type == SearchType.Bundle)
                        {
                            if (!bundle.name.ToLower().Contains(searchString)) continue;
                            BuildBundle(i, root, result);
                        }
                        else
                        {
                            if (bundle.assets.Count <= 0) continue;
                            for (int j = 0; j < bundle.assets.Count; j++)
                            {
                                var path = bundle.assets[j];
                                if (type == SearchType.AssetByPath)
                                {
                                    if (!path.ToLower().Contains(searchString)) continue;
                                }
                                else if (type == SearchType.AssetByTag)
                                {
                                    var tag = cache.GetTag(path);
                                    if (string.IsNullOrEmpty(tag)) continue;
                                    if (!tag.Contains(searchString)) continue;
                                }
                                CreateItem(path, root, result);
                            }
                        }

                    }
                }
            }
            protected override IList<TreeViewItem> BuildRows(TreeViewItem root)
            {
                var result = GetRows() ?? new List<TreeViewItem>();
                result.Clear();

                if (previewBundles != null)
                {
                    InnerBuildRows(root, result);
                }

                SetupParentsAndChildrenFromDepths(root, result);
                return result;
            }
            protected override void RowGUI(RowGUIArgs args)
            {
                float indet = this.GetContentIndent(args.item);
                var first = args.GetCellRect(0).Zoom(AnchorType.MiddleRight, new Vector2(-indet, 0));
                long length = 0;
                if (args.item.depth == 0)
                {
                    GUI.Label(first, new GUIContent(args.label, args.item.icon));
                    AssetGroup group = cache.GetGroupByBundleName(args.label);
                    length = group.length;
                }
                else
                {
                    string path = args.label;
                    GUI.Label(first, new GUIContent(path, args.item.icon));
                    AssetGroup group = cache.GetGroupByAssetPath(path);
                    length = group.GetLength(path);
                    GUI.Label(args.GetCellRect(2), new GUIContent(cache.GetTag(path)));
                }
                var tmp = length;
                int stage = 0;
                while (tmp > 1024)
                {
                    tmp /= 1024;
                    stage++;
                }
                var show = $"{(length / Mathf.Pow(1024, stage)).ToString("0.00")} {stages[stage]}";
                GUI.Label(args.GetCellRect(1), new GUIContent(show));

            }
            List<string> stages = new List<string>()
            {
                "B","KB","MB","GB","TB"
            };
            protected override void DoubleClickedItem(int id)
            {
                var rows = this.FindRows(new List<int>() { id });
                EditorGUIUtility.PingObject(AssetDatabase.LoadAssetAtPath<Object>(rows[0].displayName));
            }

        }
    }
}
