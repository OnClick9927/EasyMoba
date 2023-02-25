﻿/*********************************************************************************
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

namespace IFramework.Hotfix.Asset
{
    partial class AssetsWindow
    {
        private class DpTree : TreeView
        {
            public AssetInfo assetinfo;
            public void SetAssetInfo(AssetInfo info)
            {
                this.assetinfo = info;
                showAlternatingRowBackgrounds = true;
                this.Reload();
            }
            public DpTree(TreeViewState state) : base(state)
            {
                this.multiColumnHeader = new MultiColumnHeader(new MultiColumnHeaderState(new MultiColumnHeaderState.Column[]
{
                    new MultiColumnHeaderState.Column()
                    {
                        minWidth=400,
                         headerContent=new UnityEngine.GUIContent("Dependence"),

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
                                     new MultiColumnHeaderState.Column()
                    {
                         headerContent=new UnityEngine.GUIContent("Bundle"),
                    },
                                                                   new MultiColumnHeaderState.Column()
                    {
                         headerContent=new UnityEngine.GUIContent("Bundle Size"),
                    },


}));

                this.multiColumnHeader.ResizeToFit();
                Reload();
            }

            private void Build(TreeViewItem root, List<string> assets, IList<TreeViewItem> result)
            {
                foreach (var item in assets)
                {
                    CreateItem(item, root, result);
                }
            }
            protected override IList<TreeViewItem> BuildRows(TreeViewItem root)
            {
                var result = GetRows() ?? new List<TreeViewItem>();
                result.Clear();

                if (this.assetinfo != null && this.assetinfo.dps.Count > 0)
                {
                    Build(root, assetinfo.dps, result);
                }

                SetupParentsAndChildrenFromDepths(root, result);
                return result;
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
            protected override void RowGUI(RowGUIArgs args)
            {
                string path = args.label;
                float indet = this.GetContentIndent(args.item);

                BundleGroup group = cache.GetGroupByAssetPath(path);
                GUI.Label(args.GetCellRect(0).Zoom(AnchorType.MiddleRight, new Vector2(-indet, 0)), new GUIContent(path, args.item.icon));
                GUI.Label(args.GetCellRect(1), PreviewTree.GetSizeString(group.GetLength(path)));
                GUI.Label(args.GetCellRect(2), cache.GetTag(path));
                EditorGUI.SelectableLabel(args.GetCellRect(3), group.name);
                GUI.Label(args.GetCellRect(4), PreviewTree.GetSizeString(group.length));
            }


        }
    }
}
