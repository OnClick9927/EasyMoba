using UnityEditor;
using UnityEngine;

namespace LockStep.LCollision2D
{
    [CustomPropertyDrawer(typeof(CollisionLayer))]
    public class CollisionLayerDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var index = property.enumValueIndex;
            var names = UnityShapeLayerConfig.GetLayerNames();
            for (int i = 0; i < names.Length; i++)
            {
                if (string.IsNullOrEmpty(names[i]))
                    names[i] = i.ToString();
            }
            property.enumValueIndex = EditorGUI.Popup(position, label.text, index,
                names, EditorStyles.popup);
        }
    }

}


