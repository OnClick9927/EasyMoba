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

namespace IFramework.Hotfix.Lua
{
    static partial class LuaEditorTools
    {
        [CustomEditor(typeof(LuaBehaviour))]
        public class LuaBehaviorEditor:Editor
        {
            LuaBehaviour lua { get { return target as LuaBehaviour; } }
            UnityEditorInternal.ReorderableList list;
            private void OnEnable()
            {

                list = EditorTools.ReorderableListTool.CreateAutoLayout(
                                serializedObject.FindProperty("fields"),
                                new string[] { "name", "obj", },
                                new float[] { 0, 0 }
                                );
            }
            public override void OnInspectorGUI()
            {
                EditorGUI.BeginChangeCheck();
                EditorGUILayout.PropertyField(serializedObject.FindProperty("requireParam"));
                GUILayout.Space(5);
                list.DoLayoutList();
                if (EditorGUI.EndChangeCheck())
                {
                    serializedObject.ApplyModifiedProperties();
                }
            }
        }
    }


}

