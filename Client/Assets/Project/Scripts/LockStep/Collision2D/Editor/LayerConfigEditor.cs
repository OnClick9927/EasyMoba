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
            var values = Enum.GetNames(typeof(CollisionLayer));
            for (int i = 0; i < values.Length; i++)
            {
                CollisionLayer s = (CollisionLayer)Enum.Parse(typeof(CollisionLayer), values[i]);
                c.SetName(s, EditorGUILayout.TextField(values[i], c.GetName(s)));
            }
            var reverse = new List<string>(values);
            reverse.Reverse();
            var values_2 = reverse.ToArray();
            GUILayout.BeginHorizontal();
            foreach (var item in values)
            {
                CollisionLayer s = (CollisionLayer)Enum.Parse(typeof(CollisionLayer), item);
                GUILayout.Label($"{c.GetName(s)}\t");
            }
            GUILayout.EndHorizontal();
            for (int i = 0; i < values.Length; i++)
            {
                GUILayout.BeginHorizontal();
                CollisionLayer s = (CollisionLayer)Enum.Parse(typeof(CollisionLayer), values_2[i]);
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


