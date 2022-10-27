using System;
using UnityEditor;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace LCollision2D
{
    [CustomEditor(typeof(LayerConfig))]
    public class LayerConfigEditor : Editor
    {
        LayerConfig c { get { return this.target as LayerConfig; } }
        public override void OnInspectorGUI()
        {
            var values = Enum.GetNames(typeof(ShapeLayer));
            for (int i = 0; i < values.Length; i++)
            {
                ShapeLayer s = (ShapeLayer)Enum.Parse(typeof(ShapeLayer), values[i]);
                c.SetName(s, EditorGUILayout.TextField(values[i], c.GetName(s)));
            }
            var reverse = new List<string>(values);
            reverse.Reverse();
            var values_2 = reverse.ToArray();
            GUILayout.BeginHorizontal();
            foreach (var item in values)
            {
                ShapeLayer s = (ShapeLayer)Enum.Parse(typeof(ShapeLayer), item);
                GUILayout.Label($"{c.GetName(s)}\t");
            }
            GUILayout.EndHorizontal();
            for (int i = 0; i < values.Length; i++)
            {
                GUILayout.BeginHorizontal();
                ShapeLayer s = (ShapeLayer)Enum.Parse(typeof(ShapeLayer), values_2[i]);
                GUILayout.Label($"{c.GetName(s)}\t");
                for (int j = 0; j < values.Length - i; j++)
                {
                    GUILayout.Toggle(false, new GUIContent("",$"{values_2[i]}  {values[j]}"));
                }
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
            }

        }
    }

}


