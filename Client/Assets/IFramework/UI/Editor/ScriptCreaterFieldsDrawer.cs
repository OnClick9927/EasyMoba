/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.1f1
 *Date:           2019-03-18
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using UnityEditor;
using UnityEngine;
using UnityEditor.IMGUI.Controls;
using System.Collections.Generic;
using System;

namespace IFramework.UI
{
    public class ScriptCreaterFieldsDrawer
    {
        private class Tree : TreeView
        {
            private GameObject go;
            private ScriptCreater sc;
            public void SetGameObject(ScriptCreater sc)
            {
                this.sc = sc;
                if (this.go != sc.gameObject)
                {
                    this.go = sc.gameObject;
                    this.Reload();
                }
            }
            public Tree(TreeViewState state) : base(state)
            {
                this.showBorder = true;
                this.showAlternatingRowBackgrounds = true;
                this.multiColumnHeader = new MultiColumnHeader(new MultiColumnHeaderState(new MultiColumnHeaderState.Column[]
                {
                        new MultiColumnHeaderState.Column()
                        {
                            headerContent=new GUIContent("Name")
                        },
                        new MultiColumnHeaderState.Column()
                        {
                           headerContent=new GUIContent("Mark")
                        },
                         new MultiColumnHeaderState.Column()
                        {
                           headerContent=new GUIContent("FieldName")
                        },
                })); ;
                Reload();
                this.multiColumnHeader.ResizeToFit();
            }

            protected override TreeViewItem BuildRoot()
            {
                return new TreeViewItem { id = 0, depth = -1 };
            }
            protected override IList<TreeViewItem> BuildRows(TreeViewItem root)
            {
                var rows = GetRows() ?? new List<TreeViewItem>();
                rows.Clear();
                if (this.go != null)
                {
                    var gameObject = this.go;
                    var item = CreateTreeViewItemForGameObject(gameObject);
                    root.AddChild(item);
                    rows.Add(item);
                    if (gameObject.transform.childCount > 0)
                    {
                        if (IsExpanded(item.id))
                        {
                            AddChildrenRecursive(gameObject, item, rows);
                        }
                        else
                        {
                            item.children = CreateChildListForCollapsedParent();
                        }
                    }
                }


                SetupDepthsFromParentsAndChildren(root);
                return rows;
            }
            static TreeViewItem CreateTreeViewItemForGameObject(GameObject gameObject)
            {
                return new TreeViewItem(gameObject.GetInstanceID(), -1, gameObject.name);
            }
            GameObject GetGameObject(int instanceID)
            {
                return (GameObject)EditorUtility.InstanceIDToObject(instanceID);
            }
            void AddChildrenRecursive(GameObject go, TreeViewItem item, IList<TreeViewItem> rows)
            {
                int childCount = go.transform.childCount;

                item.children = new List<TreeViewItem>(childCount);
                for (int i = 0; i < childCount; ++i)
                {
                    var childTransform = go.transform.GetChild(i);
                    var childItem = CreateTreeViewItemForGameObject(childTransform.gameObject);
                    item.AddChild(childItem);
                    rows.Add(childItem);

                    if (childTransform.childCount > 0)
                    {
                        if (IsExpanded(childItem.id))
                        {
                            AddChildrenRecursive(childTransform.gameObject, childItem, rows);
                        }
                        else
                        {
                            childItem.children = CreateChildListForCollapsedParent();
                        }
                    }
                }
            }
            protected override void RowGUI(RowGUIArgs args)
            {
                var go = GetGameObject(args.item.id);
                if (go != null)
                {
                    float indet = this.GetContentIndent(args.item);
                    var first = args.GetCellRect(0).Zoom(AnchorType.MiddleRight, new Vector2(-indet, 0));

                    GUI.Label(first, args.label);
                    ScriptMark sm = go.GetComponent<ScriptMark>();
                    if (sm != null)
                    {
                        var rect = args.GetCellRect(1);
                        GUI.Label(rect, sm.fieldType);
                        rect = args.GetCellRect(2);
                        GUI.Label(rect, sm.fieldName);
                    }
                }
            }
            List<GameObject> goes = new List<GameObject>();
            List<ScriptMark> sms = new List<ScriptMark>();
            List<Type> cs = new List<Type>();
            Dictionary<Type, int> help = new Dictionary<Type, int>();

            void SaveGo()
            {
                EditorTools.AssetTool.Update(this.go);
                Reload();
            }
            void JustRemove()
            {
                for (int i = 0; i < sms.Count; i++)
                {
                    GameObject.DestroyImmediate(sms[i], true);
                }
            }
            void RemoveFunc()
            {
                JustRemove();
                SaveGo();
            }
            void ValidField(ScriptMark sm)
            {
                sc.ValidateMarkFieldName(sm);
            }
            void FreshFieldName()
            {
                var all = sc.GetMarks();
                for (int i = 0; i < all.Count; i++)
                {
                    ValidField(all[i]);
                }
                SaveGo();
            }
            void AddFunc(object o)
            {
                Type type = o as Type;
                JustRemove();
                for (int i = 0; i < goes.Count; i++)
                {
                    ScriptMark sm = goes[i].AddComponent<ScriptMark>();
                    sm.fieldType = type.FullName;
                    ValidField(sm);
                }
                SaveGo();
            }
            void DestoryMarks()
            {
                sc.DestoryMarks();
                SaveGo();
            }
            protected override void ContextClicked()
            {
                GenericMenu menu = new GenericMenu();
                var s = this.GetSelection();
                if (s.Count != 0)
                {
                    goes.Clear();
                    sms.Clear();
                    cs.Clear();
                    help.Clear();
                    for (int i = 0; i < s.Count; i++)
                    {
                        var go = GetGameObject(s[i]);
                        goes.Add(go);
                        ScriptMark sm = go.GetComponent<ScriptMark>();
                        if (sm != null) sms.Add(sm);
                        Component[] _cs = go.GetComponents<Component>();
                        for (int j = 0; j < _cs.Length; j++)
                        {
                            Type c = _cs[j].GetType();
                            if (!(_cs[j] is ScriptMark))
                                if (help.ContainsKey(c)) help[c]++;
                                else help[c] = 1;
                        }
                    }
                    foreach (var item in help)
                        if (s.Count == 1)
                            cs.Add(item.Key);
                        else
                          if (item.Value > 1) cs.Add(item.Key);

                    if (cs.Count == 0)
                        menu.AddDisabledItem(new GUIContent("AddComponent"));
                    else
                        for (int i = 0; i < cs.Count; i++)
                        {
                            var type = cs[i];
                            menu.AddItem(new GUIContent($"MarkComponent/{type.FullName}"), false, AddFunc, type);
                        }
                    if (sms.Count == 0)
                        menu.AddDisabledItem(new GUIContent("Remove Selected Marks"));
                    else
                        menu.AddItem(new GUIContent("Remove"), false, RemoveFunc);
                }
                menu.AddSeparator("");
                if (go == null)
                    menu.AddDisabledItem(new GUIContent("FreshFieldName"));
                else
                    menu.AddItem(new GUIContent("FreshFieldName"), false, FreshFieldName);
                menu.AddItem(new GUIContent("DestoryAllMarks"), false, DestoryMarks);

                menu.ShowAsContext();
            }
        }
        private ScriptCreater _creater;
        private Tree _tree;
        public ScriptCreaterFieldsDrawer(ScriptCreater creater, TreeViewState state)
        {
            this._creater = creater;
            if (state == null)
            {
                state = new TreeViewState();
            }
            _tree = new Tree(state);

        }


        public void OnGUI()
        {
            _tree.SetGameObject(_creater);
            _tree.OnGUI(EditorGUILayout.GetControlRect(GUILayout.ExpandHeight(true)));
        }
    }

}
