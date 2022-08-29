/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.51
 *UnityVersion:   2018.4.24f1
 *Date:           2020-09-13
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using UnityEditor;
using IFramework.GUITool;
using UnityEngine;
using IFramework.GUITool.ToorbarMenu;
using System.Collections.Generic;
using System.Linq;
using System;

#pragma warning disable
namespace IFramework
{
    partial class RootWindow : UnityEditor.EditorWindow
    {
        private ToolBarTree _toolBarTree;
        private MenuTree menu;
        private SplitView _split;
        private static string search = "";
        private Dictionary<string, UserOptionTab> tabs;
        private Dictionary<string, Type> windowtabs = new Dictionary<string, Type>();
        private string showkey = "";

        [MenuItem("Window/IFramework %#i")]
        [MenuItem("Assets/IFramework/RootWindow")]
        static void ShowWindow()
        {
            GetWindow<RootWindow>();
        }
        private void OnEnable()
        {
            this.titleContent = new GUIContent("RootWindow");
            this.minSize = new Vector2(700, 400);
            _toolBarTree = new ToolBarTree();
            _toolBarTree
                .DropDownButton(new GUIContent("Tools"), (rect) =>
                {
                    GenericMenu menu = new GenericMenu();
                    var _lista = EditorTools.EditorWindowTool.user_windows;
                    foreach (var item in _lista)
                    {
                        Type type = item.type;
                        string name = item.searchName;
                        var find = EditorTools.EditorWindowTool.Find(type);
                        menu.AddItem(new GUIContent($"Open/{name}"), find != null, () =>
                        {
                            var finds = EditorTools.EditorWindowTool.Find(type);
                            if (finds == null)
                            {
                                OpenWindow(type);
                            }
                            else
                            {
                                find.Close();
                            }
                        });

                    }
                    menu.AddItem(new GUIContent("Github"), false, () => { Application.OpenURL("https://github.com/OnClick9927/IFramework-Unity"); });
                    menu.AddItem(new GUIContent("Document"), false, () => { Application.OpenURL("https://blog.csdn.net/qq_37221502/category_10284376.html"); });
                    menu.AddItem(new GUIContent("Bilibli"), false, () => { Application.OpenURL("https://space.bilibili.com/382226675"); });
                    menu.AddSeparator("");
                    menu.AddItem(new GUIContent("Join us"), false, () => { Application.OpenURL("https://jq.qq.com/?_wv=1027&k=TTSfAM1P"); });
                    menu.DropDown(rect);
                })
                .FlexibleSpace()
                .SearchField((value) => { search = value; }, search, 200)
                ;
            _split = new SplitView();
            menu = new MenuTree();
            _split.fistPan += menu.OnGUI;
            _split.secondPan += ContentGUI;
            var list = typeof(UserOptionTab).GetSubTypesInAssemblys().ToList();
            list.RemoveAll(t => t.IsAbstract);

            tabs = list.ConvertAll(t => Activator.CreateInstance(t) as UserOptionTab)
                        .ToDictionary(tab => tab.Name);
            var keys = tabs.Keys.ToList();
            keys.Sort();
            var _list = EditorTools.EditorWindowTool.user_windows;
            foreach (var item in _list)
            {
                Type type = item.type;
                string name = item.searchName;
                windowtabs.Add(name, type);
                keys.Add(name);
            }
            menu.ReadTree(keys, false);
            menu.onCurrentChange += (obj) =>
            {
                showkey = obj;


            };
            foreach (var item in tabs.Values)
            {
                item.OnEnable();
            }

        }
        private void OnDisable()
        {

            if (tabs != null)
            {
                foreach (var item in tabs.Values)
                {
                    item.OnDisable();
                }
            }

        }
        private void OnGUI()
        {
            var rs = this.LocalPosition().HorizontalSplit(20);
            _toolBarTree.OnGUI(rs[0]);
            var r2 = rs[1].Zoom(AnchorType.UpperCenter, -10);
            menu.Fitter(search);
            _split.OnGUI(r2);
        }


        private void ContentGUI(Rect position)
        {
            if (tabs == null && windowtabs == null) return;
            GUILayout.BeginArea(position);
            if (tabs.ContainsKey(showkey))
            {
                tabs[showkey].OnGUI(position);
            }
            else
            {
                if (!string.IsNullOrEmpty(showkey))
                {

                    position.position = Vector2.zero;

                    GUIStyle style = new GUIStyle(GUIStyles.button)
                    {
                        richText = true,
                    };
                    GUILayout.Space(10);
                    GUILayout.Label(showkey, new GUIStyle(GUIStyles.largeLabel)
                    {
                        alignment = TextAnchor.MiddleCenter,
                        fontSize = 20,
                        fontStyle = FontStyle.Bold,
                    });
                    var pos = new Rect(0, 0, 300, 200);
                    pos.center = position.center;
                    var rs = pos.HorizontalSplit(pos.height / 2, 10, false);
                    if (GUI.Button(rs[0], $"<size=20><b><color=#00AABB>Open</color></b></size>", style))
                    {
                        var type = windowtabs[showkey];
                        OpenWindow(type);
                    }
                    if (GUI.Button(rs[1], $"<size=20><b><color=#00AABB>Close</color></b></size>", style))
                    {
                        var type = windowtabs[showkey];
                        var find = EditorTools.EditorWindowTool.Find(type);
                        if (find != null)
                        {
                            find.Close();
                        }
                    }

                }
            }
            GUILayout.EndArea();

        }


        public static void OpenWindow(Type type)
        {
            if (EditorTools.ProjectConfig.dockWindow)
            {
                var m = typeof(EditorWindow).GetMethod(nameof(GetWindow), new Type[] { typeof(Type).MakeArrayType() });
                m = m.MakeGenericMethod(type);
                var _win = m.Invoke(null, new object[] { new Type[] { typeof(RootWindow) } }) as EditorWindow;
                _win.Focus();
            }
            else
            {
                EditorWindow.GetWindow(type);
            }

        }
    }

}
