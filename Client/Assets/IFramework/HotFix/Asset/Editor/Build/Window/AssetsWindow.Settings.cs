/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.204
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-09
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using UnityEditor;
using UnityEngine;
using System;
using IFramework.GUITool;

namespace IFramework.Hotfix.Asset
{
    partial class AssetsWindow
    {
        private class Settings : GUIBase
        {
            public AssetsWindow window;
            private Vector2 scroll;
            public override void OnGUI(Rect position)
            {
                base.OnGUI(position);
                GUILayout.BeginArea(position);
                {
                    scroll = GUILayout.BeginScrollView(scroll);
                    {
                        Draw();
                    }
                    GUILayout.EndScrollView();
                }
                GUILayout.EndArea();
            }

            private void Draw()
            {
                SerializedObject obj = new SerializedObject(buildSetting);
                obj.Update();

                EditorGUI.BeginChangeCheck();
                Box("LoadType In Editor Mode", () => { FastMode(obj); });
                Box("SpriteAtlas Collect", () => { Atlas(obj); });
                Box("Collect All Asset For Build", () => { Collect(obj); });
                Box("Build AssetBundle By Collected Assets", Build);
                if (EditorGUI.EndChangeCheck())
                {
                    obj.ApplyModifiedProperties();
                    buildSetting.Save();

                }
            }
            private void Build()
            {
                window.typeIndex = EditorGUILayout.Popup("AssetBundleBuildCollect", window.typeIndex, window.shortTypes);
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
            private void Collect(SerializedObject obj)
            {
                var prop = obj.FindProperty("ignoreFileEtend");
                EditorGUILayout.PropertyField(prop, new GUIContent("Ignore File Extends"), true);
                prop = obj.FindProperty("buildPaths");
                EditorGUILayout.PropertyField(prop, new GUIContent("Build Directory List"), true);
            }
            private void Box(string label, Action action)
            {
                GUILayout.BeginVertical("box");
                {
                    GUILayout.Space(5);
                    GUILayout.Label(label, GUIStyles.toolbarDropDown);
                    action.Invoke();
                    GUILayout.Space(5);
                }
                GUILayout.EndVertical();
            }
            protected override void OnDispose()
            {

            }
        }

    }
}
