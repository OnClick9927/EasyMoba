using UnityEditor;
using UnityEngine;
using LockStep.Math;

namespace LockStep.LCollision2D
{
    [CustomPropertyDrawer(typeof(LFloat))]
    public class LFloatDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var _p = property.FindPropertyRelative("_val");
            float f = new LFloat(true, _p.longValue).ToFloat();
            EditorGUI.PropertyField(position, _p, new GUIContent(label.text, $"Float:  {f}"));
        }
    }
}


