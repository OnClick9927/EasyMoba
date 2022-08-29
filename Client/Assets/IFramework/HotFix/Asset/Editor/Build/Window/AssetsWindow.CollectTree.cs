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
            }
            protected override TreeViewItem BuildRoot()
            {
                return new TreeViewItem() { id = -10, depth = -1 };
            }
            protected override IList<TreeViewItem> BuildRows(TreeViewItem root)
            {
                List<TreeViewItem> result = new List<TreeViewItem>();
                var roots = buildSetting.GetRootPaths();
                foreach (var path in roots)
                {
                    LoopCreate(result, root, path);
                }
                foreach (var _path in buildSetting.GetSingleFiles())
                {
                    var _item = new TreeViewItem()
                    {
                        id = result.Count,
                        depth = root.depth + 1,
                        displayName = _path,
                        parent = root,
                        icon = AssetInfo.GetMiniThumbnail(_path)
                    };
                    result.Add(_item);
                    root.AddChild(_item);
                }
                SetupParentsAndChildrenFromDepths(root, result);
                return result;
            }
            private void LoopCreate(List<TreeViewItem> result, TreeViewItem root, AssetInfo path)
            {
                var item = new TreeViewItem()
                {
                    id = result.Count,
                    depth = root.depth + 1,
                    displayName = path.path,
                    icon = path.GetMiniThumbnail()
                };
                root.AddChild(item);
                result.Add(item);

                var paths = buildSetting.GetSubFloders(path);
                var filepaths = buildSetting.GetSubFiles(path);

                if (paths.Count != 0 || filepaths.Count != 0)
                {
                    if (IsExpanded(item.id))
                    {
                        foreach (var _path in paths)
                        {
                            LoopCreate(result, item, _path);
                        }
                        foreach (var _path in filepaths)
                        {
                            var _item = new TreeViewItem()
                            {
                                id = result.Count,
                                depth = root.depth + 2,
                                displayName = _path.path,
                                parent = root,
                                icon = _path.GetMiniThumbnail()
                            };
                            result.Add(_item);
                            root.AddChild(_item);

                        }
                    }
                    else
                    {
                        item.children = CreateChildListForCollapsedParent();
                    }
                }

            }

            protected override void DoubleClickedItem(int id)
            {
                var rows = this.FindRows(new List<int>() { id });
                EditorGUIUtility.PingObject(AssetDatabase.LoadAssetAtPath<Object>(rows[0].displayName));
            }
        }

    }
}
