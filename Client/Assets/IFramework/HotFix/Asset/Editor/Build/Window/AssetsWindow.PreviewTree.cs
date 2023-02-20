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
using static IFramework.Hotfix.Asset.AssetsBuild;

namespace IFramework.Hotfix.Asset
{
    partial class AssetsWindow
    {
        private class PreviewTree : TreeView
        {
            private AssetsWindow window;
            List<AssetGroup> previewBundles { get { return cache.previewBundles; } }
            public PreviewTree(TreeViewState state, AssetsWindow window) : base(state)
            {
                this.window = window;
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

            static Dictionary<TreeViewItem, TreeViewItem> dic = new Dictionary<TreeViewItem, TreeViewItem>();
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
                dic[_item] = parrent;
                _item.parent = parrent;
                parrent.AddChild(_item);
                result.Add(_item);
                return _item;
            }

            protected override IList<TreeViewItem> BuildRows(TreeViewItem root)
            {
                var result = GetRows() ?? new List<TreeViewItem>();
                result.Clear();
                if (previewBundles != null)
                {
                    for (int i = 0; i < previewBundles.Count; i++)
                    {
                        var bundle = previewBundles[i];
                        var _item = new TreeViewItem()
                        {
                            id = i,
                            depth = 0,
                            parent = root,
                            displayName = bundle.name,
                        };

                        root.AddChild(_item);
                        result.Add(_item);
                        if (bundle.assets.Count > 0)
                        {
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




                    }
                }
                SetupParentsAndChildrenFromDepths(root, result);
                return result;
            }
            protected override void RowGUI(RowGUIArgs args)
            {
                float indet = this.GetContentIndent(args.item);
                var first = args.GetCellRect(0).Zoom(AnchorType.MiddleRight, new Vector2(-indet, 0));
                string group_name = args.label;
                if (args.item.depth == 0)
                {
                    group_name = args.label;
                    GUI.Label(first, new GUIContent(args.label));
                }
                else
                {

                    group_name = dic[args.item].displayName;
                    GUI.Label(first, new GUIContent(args.label, args.item.icon));
                }
                var find = previewBundles.Find(x => x.name == group_name);
                if (find == null)
                {
                    return;
                }
                long len = 0;

                if (args.item.depth == 0)
                {
                    len = find.length;
                }
                else
                {
                    len = find.GetLength(args.label);
                }

                var tmp = len;
                int stage = 0;
                while (tmp > 1024)
                {
                    tmp /= 1024;
                    stage++;
                }

                var show = $"{(len / Mathf.Pow(1024, stage)).ToString("0.00")} {stages[stage]}";
                GUI.Label(args.GetCellRect(1), new GUIContent(show));
                GUI.Label(args.GetCellRect(2), new GUIContent(cache.GetTag(args.label)));

               

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
