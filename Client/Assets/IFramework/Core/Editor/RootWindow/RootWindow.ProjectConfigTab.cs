/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.51
 *UnityVersion:   2018.4.24f1
 *Date:           2020-09-13
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using UnityEditor;
using IFramework.GUITool;
using System;
using UnityEngine;
using System.Collections.Generic;

#pragma warning disable
namespace IFramework
{
    partial class RootWindow
    {
        class ProjectConfigTab : UserOptionTab
        {
            static class Contents
            {
                public static GUIContent Name = new GUIContent("UserName", "Project Author's Name");
                public static GUIContent Version = new GUIContent("Version", "Version of Project");
                public static GUIContent Namespace = new GUIContent("NameSpace_ProductName", "Script's Namespace and ProductName");
                public static GUIContent Describe = new GUIContent("Description of Scripts");
                public static string logset = "LogSetting in Editor mode";
                public static string enable = "Enable";
                public static string logenable = "Log Enable";
                public static string dockWindow = "Dock EditorWindow";

                
                public static string wenable = "Warning Enable";
                public static string errenable = "Error Enable";
                public static string Ignore = "Log Ignore File Names";

            }
            private Dictionary<int, GUITool.FileField> _files = new Dictionary<int, FileField>();

            public override string Name => "ProjectConfig";

            private FileField GetFileField(int index)
            {
                if (!_files.ContainsKey(index))
                {
                    _files[index] = new FileField();
                    _files[index].onValueChange += (str) => { OnValueChange(index, str); };
                }
                return _files[index];
            }

            private void OnValueChange(int index, string str)
            {
                EditorTools.ProjectConfig.Info.logIgnoreFiles[index] = str;
                EditorTools.ProjectConfig.Save();
            }

            public override void OnGUI(Rect position)
            {
                var Info = EditorTools.ProjectConfig.Info;
                GUILayout.Space(10);
                EditorGUI.BeginChangeCheck();

                GUI.enabled = false;
                EditorGUILayout.TextField(Contents.Name, Info.UserName);
                GUI.enabled = true;
                Info.Version = EditorGUILayout.TextField(Contents.Version, Info.Version);
                Info.NameSpace = EditorGUILayout.TextField(Contents.Namespace, Info.NameSpace);
                GUILayout.Label(Contents.Describe);
                Info.Description = EditorGUILayout.TextArea(Info.Description, GUILayout.Height(100));
                GUILayout.Space(10);
                Info.dockWindow = EditorGUILayout.Toggle(Contents.dockWindow, Info.dockWindow);
                EditorGUI.DrawRect(EditorGUILayout.GetControlRect(GUILayout.Height(2)), new Color(0.5f, 0.5f, 0.5f));
                GUILayout.Label(Contents.logset, GUIStyles.largeLabel);
                Info.enable = EditorGUILayout.Toggle(Contents.enable, Info.enable);
                GUI.enabled = Info.enable;
                Info.enable_L = EditorGUILayout.Toggle(Contents.logenable, Info.enable_L);
                Info.enable_W = EditorGUILayout.Toggle(Contents.wenable, Info.enable_W);
                Info.enable_E = EditorGUILayout.Toggle(Contents.errenable, Info.enable_E);
                GUI.enabled = true;
                GUILayout.Space(10);
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label(Contents.Ignore, GUIStyles.largeLabel);
                    if (GUILayout.Button("", GUIStyles.plus, GUILayout.Width(20)))
                    {
                        Info.logIgnoreFiles.Add(string.Empty);
                    }
                    GUILayout.EndHorizontal();
                }
                for (var i = Info.logIgnoreFiles.Count - 1; i >= 0; i--)
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.Label(String.Empty);
                    var f = GetFileField(i);
                    f.SetPath(Info.logIgnoreFiles[i]);
                    f.OnGUI(GUILayoutUtility.GetLastRect());
                    if (GUILayout.Button("", GUIStyles.minus, GUILayout.Width(20)))
                    {
                        Info.logIgnoreFiles.RemoveAt(i);
                        GUI.FocusControl("");
                    }
                    GUILayout.EndHorizontal();
                }
                if (EditorGUI.EndChangeCheck())
                {
                    EditorTools.ProjectConfig.Save();
                }
            }
        }

    }

}
