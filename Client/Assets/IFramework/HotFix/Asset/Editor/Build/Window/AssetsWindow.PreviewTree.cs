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

namespace IFramework.Hotfix.Asset
{
    partial class AssetsWindow
    {
        private class PreviewTree : TreeView
        {
            private AssetsWindow window;
            List<AssetBundleBuild> previewBundles { get { return window.previewBundles; } }
            public PreviewTree(TreeViewState state, AssetsWindow window) : base(state)
            {
                this.window = window;
                showAlternatingRowBackgrounds = true;

                this.multiColumnHeader = new MultiColumnHeader(new MultiColumnHeaderState(new MultiColumnHeaderState.Column[]
                {
                    new MultiColumnHeaderState.Column()
                    {

                    },
                    new MultiColumnHeaderState.Column()
                    {
                         headerContent=new UnityEngine.GUIContent("Size"),
                    },

               }));

                this.multiColumnHeader.ResizeToFit();
                Reload();
            }

          
            protected override TreeViewItem BuildRoot()
            {
                return new TreeViewItem() { id = -10, depth = -1 };
            }
            private Dictionary<int, long> size = new Dictionary<int, long>();
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

            protected override IList<TreeViewItem> BuildRows(TreeViewItem root)
            {
                var result = GetRows() ?? new List<TreeViewItem>();
                size.Clear();
                result.Clear();
                if (previewBundles != null)
                {
                    for (int i = 0; i < previewBundles.Count; i++)
                    {
                        var bundle = previewBundles[i];
                        var _item = new TreeViewItem()
                        {
                            id = bundle.assetBundleName.GetHashCode(),
                            depth = root.depth + 1,
                            displayName = bundle.assetBundleName,
                        };

                        root.AddChild(_item);
                        result.Add(_item);
                        long total = 0;
                        for (int j = 0; j < bundle.assetNames.Length; j++)
                        {
                            var path = bundle.assetNames[j];
                            FileInfo info = new FileInfo(path);
                            var len = info.Length;
                            total += len;
                        }
                        size[_item.id] = total;

                        if (IsExpanded(_item.id))
                        {
                            for (int j = 0; j < bundle.assetNames.Length; j++)
                            {
                                var path = bundle.assetNames[j];
                                FileInfo info = new FileInfo(path);
                                var len = info.Length;
                                var item = CreateItem(path, _item, result);
                                size[item.id] = len;
                            }
                        }
                        else
                        {
                            _item.children = CreateChildListForCollapsedParent();
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
                if (args.item.depth == 0)
                {
                    GUI.Label(first, new GUIContent(args.label));
                }
                else
                {
                    GUI.Label(first, new GUIContent(args.label, args.item.icon));
                }
                var second = args.GetCellRect(1);
                var len = size[args.item.id];
                var tmp = len;
                int stage = 0;
                while (tmp > 1024)
                {
                    tmp /= 1024;
                    stage++;
                }

                var show = $"{(len / Mathf.Pow(1024, stage)).ToString("0.00")} {stages[stage]}";
                GUI.Label(second, new GUIContent(show));


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
