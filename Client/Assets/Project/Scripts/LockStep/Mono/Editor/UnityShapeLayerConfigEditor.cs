using System;
using UnityEditor;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using static UnityEditor.Progress;
using System.IO;
using IFramework;

namespace LockStep.LCollision2D
{
    [CustomEditor(typeof(UnityShapeLayerConfig))]
    public class UnityShapeLayerConfigEditor : Editor
    {
        UnityShapeLayerConfig c { get { return this.target as UnityShapeLayerConfig; } }

        static CollisionLayer parse(string value)
        {
            return (CollisionLayer)Enum.Parse(typeof(CollisionLayer), value);
        }
        const string path = "Assets/Project/Configs/CollisonLayer.json";
        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Load"))
            {
                if (File.Exists(path))
                {
                    c.cfg = JsonUtility.FromJson<CollisionLayerConfig>(File.ReadAllText(path));
                }
            }
            if (GUILayout.Button("Save"))
            {
                File.WriteAllText(path, JsonUtility.ToJson(c.cfg, true));
                AssetDatabase.Refresh();
            }
            var values = Enum.GetNames(typeof(CollisionLayer));

            var _reverse = new List<string>(values);
            _reverse.Reverse();
            var reverse = _reverse.ToArray();
            var rect = EditorGUILayout.GetControlRect(GUILayout.Height(15 * 20 + 100), GUILayout.Width(15 * 20 + 60));
            for (int i = 0; i < values.Length; i++)
            {
                var _rect = new Rect(rect.x + 60 + i * 20, rect.y, 100, 20);
                GUIUtility.RotateAroundPivot(270, _rect.center);
                GUI.Label(_rect, $"{c.GetName(parse(values[i]))}\t");
                GUI.matrix = Matrix4x4.identity;

            }
            EditorGUI.BeginChangeCheck();
            for (int i = 0; i < values.Length; i++)
            {
                CollisionLayer r = parse(reverse[i]);
                var __rect = new Rect(rect.x, rect.y + i * 20 + 60, 100, 20);
                GUI.Label(__rect, $"{c.GetName(r)}\t", new GUIStyle("label")
                {
                    alignment = TextAnchor.MiddleRight
                });
                for (int j = 0; j < values.Length - i; j++)
                {
                    var z = parse(values[j]);
                    var _rect = new Rect(rect.x + 100 + j * 20, rect.y + i * 20 + 60, 20, 20);

                    var b = GUI.Toggle(_rect, c.CouldLayerCollision(z, r),
                        new GUIContent("", $" {c.GetName(r)} , {c.GetName(z)}"));
                    c.SetCouldLayerCollision(r, z, b);
                }
            }
            GUILayout.Space(50);

            for (int i = 0; i < values.Length; i++)
            {
                CollisionLayer s = parse(values[i]);
                c.SetName(s, EditorGUILayout.TextField(values[i], c.GetName(parse(values[i]))));
            }
            if (EditorGUI.EndChangeCheck())
            {
                EditorTools.AssetTool.Update(c);
            }
        }
    }

}


