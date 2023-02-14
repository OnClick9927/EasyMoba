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

namespace IFramework.Hotfix.Asset
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
            Box("LoadType In Editor Mode", () => { FastMode(obj); });
            Box("SpriteAtlas Collect", () => { Atlas(obj); });
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
            var prop = obj.FindProperty("ignoreFileEtend");
            EditorGUILayout.PropertyField(prop, new GUIContent("Ignore File Extends"), true);
            prop = obj.FindProperty("buildPaths");
            EditorGUILayout.PropertyField(prop, new GUIContent("Build Directory List"), true);
            buildSetting.bundleSize = EditorGUILayout.LongField("Bundle Size", buildSetting.bundleSize);

            buildSetting.version = EditorGUILayout.TextField("Version", buildSetting.version);
            buildSetting.buildGroup.typeIndex = EditorGUILayout.Popup("AssetGroup", buildSetting.buildGroup.typeIndex, buildSetting.buildGroup.shortTypes);
            buildSetting.encrypt.typeIndex = EditorGUILayout.Popup("Encrypt", buildSetting.encrypt.typeIndex, buildSetting.encrypt.shortTypes);

            var op = (BuildAssetBundleOptions)EditorGUILayout.EnumFlagsField("BuildAssetBundleOptions", buildSetting.option);
            if (buildSetting.option != op)
            {
                buildSetting.option = op;
                buildSetting.Save();
            }

        }
        private void FastMode(SerializedObject obj)
        {
            var prop = obj.FindProperty("fastMode");
            EditorGUILayout.PropertyField(prop, new GUIContent("FastMode"));
        }
        private void Atlas(SerializedObject obj)
        {
            var prop = obj.FindProperty("atlasPaths");
            EditorGUILayout.PropertyField(prop, new GUIContent("Atlas Directory List"), true);

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
