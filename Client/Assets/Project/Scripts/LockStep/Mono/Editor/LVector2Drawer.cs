using UnityEditor;
using UnityEngine;
using LockStep.Math;
using IFramework;

namespace LockStep.LCollision2D
{
    [CustomPropertyDrawer(typeof(LVector2))]
    public class LVector2Drawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label) * 2;
        }
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var rs0 = position.HorizontalSplit(18);
            
            EditorGUI.LabelField(rs0[0], label);
            rs0[1].xMin += 10;
            rs0[1].width -= 10;
            var rs = rs0[1].VerticalSplit(position.width / 2);
            var _p = property.FindPropertyRelative("_x");
            var _p2 = property.FindPropertyRelative("_y");
            float f = LFloat.CreateByRaw(_p.longValue).ToFloat();
            float f2 = LFloat.CreateByRaw(_p2.longValue).ToFloat();

            EditorGUI.PropertyField(rs[0], _p, new GUIContent("X", $"Float: {f}"));
            EditorGUI.PropertyField(rs[1], _p2, new GUIContent("Y", $"Float: {f2}"));

        }
    }
}


