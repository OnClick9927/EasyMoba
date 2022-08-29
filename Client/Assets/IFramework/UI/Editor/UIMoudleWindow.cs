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
            if (!File.Exists(path))
            {
                File.WriteAllText(path, JsonUtility.ToJson(new PanelPathCollect(), true));
            }
            collect = JsonUtility.FromJson<PanelPathCollect>(File.ReadAllText(path));
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
            menu.Select(_names[0]);
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

        const string path = "Assets/Project/Configs/UICollect.json";
        const string cs_path = "Assets/Project/Scripts/PanelNames.cs";
        const string layer_path = "Assets/Project/Configs/UILayer.json";

        const string res = "Resources";

        protected static PanelPathCollect collect;
        protected static void Collect()
        {
            List<PanelPathCollect.Data> datas = new List<PanelPathCollect.Data>();
            var paths = AssetDatabase.GetAllAssetPaths();
            foreach (var path in paths)
            {
                if (!path.EndsWith("prefab")) continue;
                UIPanel u = AssetDatabase.LoadAssetAtPath<UIPanel>(path);
                if (u == null) continue;
                var _path = path;
                var is_res = path.Contains(res);
                var name = Path.GetFileNameWithoutExtension(path);
                if (is_res)
                {
                    var index = path.IndexOf(res);
                    _path = path.Substring(index + res.Length + 1).Replace(".prefab", "");
                }
                datas.Add(new PanelPathCollect.Data()
                {
                    isResourcePath = is_res,
                    path = _path,
                    name = name
                });
            }
            collect.WriteData(datas);
            File.WriteAllText(path, JsonUtility.ToJson(collect, true));
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
            string s = "public class PanelNames\n" +
                "{\n";
            foreach (var data in collect.datas)
            {
                s = s.Append($"\t public string {data.name} = \"{data.name}\";\n");
            }
            s = s.Append("}");
            File.WriteAllText(cs_path, s);
            AssetDatabase.Refresh();
        }

        public static void BuildLayerConfig()
        {
            Collect();
            UILayerConfig config;
            if (File.Exists(layer_path))
            {
                config = JsonUtility.FromJson<UILayerConfig>(File.ReadAllText(layer_path));
            }
            else
            {
                config = new UILayerConfig();
            }
            foreach (var data in collect.datas)
            {
                var find = config.configs.Find((x) => { return x.name == data.name; });
                if (find == null)
                {
                    config.configs.Add(new UILayerData() { name = data.name, layer = UILayer.Common, order = 0 });
                }
            }
            File.WriteAllText(layer_path, JsonUtility.ToJson(config, true));
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
