/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.204
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-09
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using UnityEngine;
using UnityEditor;
using IFramework.GUITool;

namespace IFramework.Hotfix.Asset
{
    partial class AssetsBuild
    {
        [CustomEditor(typeof(AssetsBuildSetting))]
        class AssetBuildSettingEditor : Editor
        {
            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();

                SerializedObject obj = new SerializedObject(setting);
                //obj.Update();
                EditorGUI.BeginChangeCheck(); 
                Build(obj);

                if (EditorGUI.EndChangeCheck())
                {
                    obj.ApplyModifiedProperties();
                    setting.Save();
                    cache.CompareTags(setting.tags);
                }
            }

            private void Build(SerializedObject obj)
            {
                GUILayout.Space(5);
                EditorGUILayout.PropertyField(obj.FindProperty("tags"), new GUIContent("Tags"), true);
        
      
                setting.buildGroup.typeIndex = EditorGUILayout.Popup("Bundle Group", setting.buildGroup.typeIndex, setting.buildGroup.shortTypes);
                setting.encrypt.typeIndex = EditorGUILayout.Popup("Encrypt", setting.encrypt.typeIndex, setting.encrypt.shortTypes);
                GUI.enabled = false;
                EditorGUILayout.TextField("Output Path", AssetsBuild.outputPath);
                EditorGUILayout.EnumPopup("Build Target", EditorUserBuildSettings.activeBuildTarget);
                GUI.enabled = true;
            }
        }


    }

}
