/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.11f1
 *Date:           2020-01-13
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using UnityEditor;
using UnityEngine;
using System.Linq;
using System;
using System.Collections.Generic;
using IFramework.GUITool;
using IFramework.GUITool.ToorbarMenu;
using System.IO;
using System.Diagnostics;
using System.Text;

namespace IFramework.UI
{

    [EditorWindowCache("UIModule")]
    public partial class UIMoudleWindow : EditorWindow
    {
        private Dictionary<string, UIMoudleWindowTab> _tabs;
        private MenuTree menu;
        private SplitView sp = new SplitView();
        private ToolBarTree toolBar;
        private string _name;
        private void OnEnable()
        {
            if (!File.Exists(UICollectPath))
            {
                File.WriteAllText(UICollectPath, JsonUtility.ToJson(new PanelPathCollect(), true));
            }
            collect = JsonUtility.FromJson<PanelPathCollect>(File.ReadAllText(UICollectPath));
            menu = new MenuTree();
            _tabs = typeof(UIMoudleWindowTab).GetSubTypesInAssemblys()
                                     .ToList()
                                     .ConvertAll((type) => { return Activator.CreateInstance(type) as UIMoudleWindowTab; })
                                     .ToDictionary((tab) => { return tab.name; });

            var _names = _tabs.Keys.ToList();

            foreach (var item in _tabs.Values)
            {
                item.OnEnable();
            }
            menu.ReadTree(_names);
            menu.onCurrentChange += (name) =>
            {
                _name = name;
            };
            if (string.IsNullOrEmpty(_name))
            {
                menu.Select(_names[0]);
            }
            else
            {
                menu.Select(_name);
            }
            sp.fistPan += Sp_fistPan;
            sp.secondPan += Sp_secondPan;

            var methods = GetType().GetMethods(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
            toolBar = new ToolBarTree();
            toolBar.DropDownButton(new GUIContent("Build"), (rect) =>
            {
                GenericMenu menu = new GenericMenu();
                foreach (var method in methods)
                {
                    menu.AddItem(new GUIContent($"{method.Name}"), false, () =>
                    {
                        method.Invoke(null, null);
                    });
                }
                menu.DropDown(rect);
            });
            toolBar.FlexibleSpace()
                .SearchField((str) => { menu.Fitter(str); }, "", 200);
        }

        static string UICollectPath {get{ return EditorEnvPath.projectConfigPath.CombinePath("UICollect.json"); } }
        static string cs_path { get { return EditorEnvPath.projectScriptPath.CombinePath("PanelNames.cs"); } }

        const string res = "Resources";

        protected static PanelPathCollect collect;
        protected static PanelPathCollect Collect()
        {
            var paths = AssetDatabase.GetAllAssetPaths();
            foreach (var path in paths)
            {
                if (!path.EndsWith("prefab")) continue;
                UIPanel u = AssetDatabase.LoadAssetAtPath<UIPanel>(path);
                if (u == null) continue;
                var _path = path;
                var is_res = path.Contains(res);
                if (is_res)
                {
                    var index = path.IndexOf(res);
                    _path = path.Substring(index + res.Length + 1).Replace(".prefab", "");
                }
                if (collect.datas.Find(x => x.path == _path)==null)
                {
                    collect.datas.Add(new PanelPathCollect.Data()
                    {
                        isResourcePath = is_res,
                        path = _path,
                    });
                };
            }
            File.WriteAllText(UICollectPath, JsonUtility.ToJson(collect, true));
            return collect;
        }


        private void Sp_secondPan(Rect obj)
        {
            GUILayout.BeginArea(obj);
            {
                GUILayout.Space(10);
                _tabs[_name].OnGUI();
                GUILayout.Space(10);

            }
            GUILayout.EndArea();
        }

        private void Sp_fistPan(Rect obj)
        {
            menu.OnGUI(obj);
        }
        public static void CS_BuildPanelNames()
        {
            Collect();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("public class PanelNames");
            sb.AppendLine("{");
            foreach (var data in collect.datas)
            {
                sb.AppendLine($"\t public static string {data.name} = \"{data.path}\";");
            }
            sb.AppendLine("}");
            File.WriteAllText(cs_path, sb.ToString());
            AssetDatabase.Refresh();
        }



        private void OnDisable()
        {
            foreach (var item in _tabs.Values)
            {
                item.OnDisable();
            }
        }
        private void OnGUI()
        {
            var rs = this.LocalPosition().HorizontalSplit(20);
            toolBar.OnGUI(rs[0]);
            sp.OnGUI(rs[1]);

        }
        private void OnHierarchyChange()
        {
            Collect();
            _tabs[_name].OnHierarchyChanged();
            Repaint();
        }

    }
}
