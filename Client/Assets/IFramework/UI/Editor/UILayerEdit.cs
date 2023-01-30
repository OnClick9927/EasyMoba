/*********************************************************************************
 *Author:         Wulala
 *Version:        1.0
 *UnityVersion:   2020.3.3f1c1
 *Date:           2022-09-13
 *Description:    Description
 *History:        2022-09-13--
*********************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using IFramework;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace IFramework.UI
{
    public partial class UIMoudleWindow
    {
        public class UILayerEdit : UIMoudleWindowTab
        {
            public UILayerConfig config = new UILayerConfig();

            private ReorderableList list;
           
            static string layer_path { get { return EditorEnvPath.projectConfigPath.CombinePath("UILayer.json"); } }

            public override string name => "BuildUILayer";
            public override void OnEnable()
            {
                Reload();
                list = new ReorderableList(config.configs, typeof(UILayerData));
                list.drawElementCallback += Draw;
                list.drawHeaderCallback += DrawHwader;
                list.elementHeight = 20;
                list.displayAdd = list.displayRemove = false;
            }

            private void DrawHwader(Rect rect)
            {
                var rs0 = rect.VerticalSplit(220);
                var rs1 = rs0[1].VerticalSplit(120);
                EditorGUI.LabelField(rs0[0], "Name");
                EditorGUI.LabelField(rs1[0], "Layer");
                EditorGUI.LabelField(rs1[1], "Oder");

            }

            private void Draw(Rect rect, int index, bool isActive, bool isFocused)
            {
                rect = rect.Zoom(AnchorType.MiddleCenter, -4);
                UILayerData data = config.configs[index];
                string path = data.panelPath;
                string name = Path.GetFileNameWithoutExtension(path);
                var rs0 = rect.VerticalSplit(200);
                var rs1 = rs0[1].VerticalSplit(120);
                GUI.Label(rs0[0], new GUIContent(name,path));
                data.layer = (UILayer)EditorGUI.EnumPopup(rs1[0],data.layer);
                data.order = EditorGUI.IntField(rs1[1],data.order);
            }
            private void Reload()
            {
                Collect();
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
                    var find = config.configs.Find((x) => { return x.panelPath == data.path; });
                    if (find == null)
                    {
                        config.configs.Add(new UILayerData() { panelPath = data.path, layer = UILayer.Common, order = 0 });
                    }
                }

            }
            private void Save()
            {
                File.WriteAllText(layer_path, JsonUtility.ToJson(config, true));
                AssetDatabase.Refresh();
            }
            public override void OnGUI()
            {
                GUILayout.BeginHorizontal();
                {
                    if (GUILayout.Button("Fresh"))
                    {
                        Reload();
                    }
                    if (GUILayout.Button("Save To File"))
                    {
                        Save();
                    }
                    if (GUILayout.Button("Ping File"))
                    {
                        EditorGUIUtility.PingObject(AssetDatabase.LoadAssetAtPath<TextAsset>(layer_path));
                    }
                }
                GUILayout.EndHorizontal();
 
                list.DoLayoutList();
            }
            public override void OnDisable()
            {
                Save();
            }
        }

    }
}
