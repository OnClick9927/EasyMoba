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
using System;
using IFramework.GUITool;
using UnityEditor.Build.Content;

namespace IFramework.Hotfix.Asset
{
    partial class AssetsWindow
    {


        [CustomEditor(typeof(AssetBuildSetting))]
        class AssetBuildSettingEditor : Editor
        {
            AssetBuildSetting buildSetting { get { return AssetBuildSetting.Load(); } }

            public override void OnInspectorGUI()
            {
                SerializedObject obj = new SerializedObject(buildSetting);
                obj.Update();

                EditorGUI.BeginChangeCheck();
                Box("Toos", () => { FastMode(obj); });
                Box("Build Options", () => { Build(obj); });

                if (EditorGUI.EndChangeCheck())
                {
                    obj.ApplyModifiedProperties();
                    buildSetting.Save();
                }
            }

            private void Build(SerializedObject obj)
            {
                GUILayout.Space(5);
                EditorGUILayout.PropertyField(obj.FindProperty("ignoreFileEtend"), new GUIContent("Ignore File Extends"), true);
                EditorGUILayout.PropertyField(obj.FindProperty("buildPaths"), new GUIContent("Build Directory List"), true);
                EditorGUILayout.PropertyField(obj.FindProperty("bundleSize"), new GUIContent("Bundle Size"), true);
                EditorGUILayout.PropertyField(obj.FindProperty("version"), new GUIContent("Version"), true);
                EditorGUILayout.PropertyField(obj.FindProperty("forceRebuild"), new GUIContent("Force Rebuild"), true);
                EditorGUILayout.PropertyField(obj.FindProperty("IgnoreTypeTreeChanges"), new GUIContent("IgnoreTypeTreeChanges"), true);
                buildSetting.buildGroup.typeIndex = EditorGUILayout.Popup("AssetGroup", buildSetting.buildGroup.typeIndex, buildSetting.buildGroup.shortTypes);
                buildSetting.encrypt.typeIndex = EditorGUILayout.Popup("Encrypt", buildSetting.encrypt.typeIndex, buildSetting.encrypt.shortTypes);
                GUI.enabled = false;
                EditorGUILayout.TextField("Output Path", buildSetting.outputPath);
                EditorGUILayout.EnumPopup("Build Target", EditorUserBuildSettings.activeBuildTarget);
                GUI.enabled = true;

            }
            private void FastMode(SerializedObject obj)
            {
                var prop = obj.FindProperty("fastMode");
                EditorGUILayout.PropertyField(prop, new GUIContent("FastMode"));
                GUI.enabled = false;
                EditorGUILayout.TextField("ShaderVariant Path", AssetBuildSetting.shaderVariantPath);
                GUI.enabled = true;
                var prop_2 = obj.FindProperty("atlasPaths");
                EditorGUILayout.PropertyField(prop_2, new GUIContent("Atlas Directory List"), true);
                var prop_3 = obj.FindProperty("tags");

                EditorGUI.BeginChangeCheck();
                EditorGUILayout.PropertyField(prop_3, new GUIContent("Tags"), true);
                if (EditorGUI.EndChangeCheck())
                {
                    var tags = buildSetting.GetTags();
                    cache.CompareTags(tags);
                }
            }

            private void Box(string label, Action action)
            {
                GUILayout.BeginVertical(GUIStyles.helpBox);
                {
                    GUILayout.Label(label, GUIStyles.BoldLabel);
                    GUILayout.Space(5);
                    action.Invoke();
                    GUILayout.Space(5);
                }
                GUILayout.EndVertical();
                GUILayout.Space(10);

            }
        }


    }

}
