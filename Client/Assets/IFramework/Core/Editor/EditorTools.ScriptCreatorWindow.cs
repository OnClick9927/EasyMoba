/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.1f1
 *Date:           2019-03-18
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using UnityEditor;
using UnityEngine;
using System;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Text;
using IFramework.GUITool;

namespace IFramework
{
    partial class EditorTools
    {
        [EditorWindowCache("ScriptCreatorWindow")]
        public class ScriptCreatorWindow : EditorWindow
        {
            private string path { get { return _creater.createDirectory.CombinePath(_creater.scriptName + ".cs"); } }
            private ScriptCreater _creater = new ScriptCreater();
            private FloderField floderField;
            private ScriptCreaterFieldsDrawer fields;
            private void OnEnable()
            {
                _creater.CollectMonoBehaviors();
                floderField = new FloderField(_creater.createDirectory);
                fields = new ScriptCreaterFieldsDrawer(_creater);
                EditorApplication.hierarchyChanged += HierarchyChanged;
            }
            private void HierarchyChanged()
            {
                _creater.ColllectMarks();
                Repaint();
            }
            private void OnDisable()
            {
                EditorApplication.hierarchyChanged -= HierarchyChanged;
            }
            private void OnGUI()
            {
                _creater.SetGameObject(EditorGUILayout.ObjectField("RootGameObject:", _creater.gameObject, typeof(GameObject), true) as GameObject);
                if (_creater.gameObject == null) return;
                GUILayout.Space(2);
                _creater.CheckSelectMonoBehaviorType();

                _creater.SetNamespace(EditorGUILayout.TextField("Script Namspace", _creater.Namespace));
                _creater.SetScriptName(EditorGUILayout.TextField("Script Name", _creater.scriptName));
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label(new GUIContent("Base Type:", "Click to choose Base Type"), GUILayout.MaxWidth(150));
                    GUIContent content = new GUIContent(_creater.type);
                    if (EditorGUILayout.DropdownButton(content, FocusType.Passive, GUILayout.ExpandWidth(true)))
                    {
                        Rect pos = GUILayoutUtility.GetLastRect();
                        SearchablePopup.Show(pos, _creater.baseTypes.ToArray(), _creater.searchIndex, _creater.SelectMonoBehaviorType);
                        GUIUtility.ExitGUI();
                    }
                    GUILayout.EndHorizontal();
                }
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label(new GUIContent("Create Path:", "Drag Floder To Box"), GUILayout.MaxWidth(150));
                    floderField.OnGUI(EditorGUILayout.GetControlRect());
                    _creater.SetCreateDirectory(floderField.path);
                    GUILayout.EndHorizontal();
                }

                GUILayout.Space(2);
                fields.OnGUI();


                GUILayout.Space(2);
                GUILayout.BeginHorizontal();
                {
                    if (GUILayout.Button("Build", GUILayout.Height(25)))
                    {
                        BuildScript();
                    }
                    if (GUILayout.Button("Bind ", GUILayout.Height(25)))
                    {
                        if (EditorApplication.isCompiling)
                        {
                            EditorWindow.focusedWindow.ShowNotification(new GUIContent("Please Wait  Editor Compiling"));
                            return;
                        }
                        SetFields();
                    }
                    if (GUILayout.Button("Remove", GUILayout.Height(25)))
                    {
                        _creater.DestoryMarks();
                    }
                    GUILayout.EndHorizontal();
                }
            }
            private void BuildScript()
            {
                if (EditorApplication.isCompiling) return;
                if (BuildCheck())
                {
                    string txt = formatScript;
                    if (!txt.Contains("#SCAuthor#")) return;
                    txt = txt.Replace("#SCAuthor#", EditorTools.ProjectConfig.UserName)
                             .Replace("#SCVERSION#", EditorTools.ProjectConfig.Version)
                             .Replace("#SCUNITYVERSION#", Application.unityVersion)
                             .Replace("#SCDATE#", DateTime.Now.ToString("yyyy-MM-dd"))
                             .Replace("#SCNameSpace#", _creater.Namespace)
                             .Replace("#SCSCRIPTNAME#", _creater.scriptName)
                             .Replace("#BaseClass#", _creater.type)
                             .Replace("#SCDescription#", EditorTools.ProjectConfig.Description)
                             .Replace("#SCField#", FieldString());
                    File.WriteAllText(path, txt, Encoding.UTF8);
                    AssetDatabase.Refresh();
                }
            }
            private string FieldString()
            {
                string result = string.Empty;
                _creater.GetMarks().ForEach((mark) =>
                {
                    var fieldType = mark.fieldType;
                    result = result.Append("\t\tpublic " + fieldType + " " + mark.fieldName + ";\n");
                });
                return result;
            }
            private bool BuildCheck()
            {
                bool bo = true;
                if (File.Exists(path))
                    bo = EditorUtility.DisplayDialog("Warnning", "The File Exist \n" + path + "\n Overwrite the original file ?", "yes", "no");
                if (!bo) return false;

                string err;
                if (!_creater.FieldCheckWithScriptName(out err))
                {
                    EditorUtility.DisplayDialog("Err", err, "ok");
                    return false;
                }
                if (!_creater.FieldCheck(out err))
                {
                    EditorUtility.DisplayDialog("Err", err, "ok");
                    return false;
                }
                if (!Directory.Exists(_creater.createDirectory))
                {
                    EditorUtility.DisplayDialog("Err", "Directory Not Exist ", "ok");
                    return false;
                }
                return true;
            }
            private void SetFields()
            {
                if (!File.Exists(path)) return;
                Assembly defaultAssembly = AppDomain.CurrentDomain
                                             .GetAssemblies()
                                             .First(assembly => assembly.GetName().Name == "Assembly-CSharp");
                Type type = defaultAssembly.GetType(_creater.Namespace + "." + _creater.scriptName);
                if (type == null) return;

                ScriptMark[] marks = _creater.GetMarks().ToArray();
                Component component = _creater.GetComponent(type);
                if (component == null) component = _creater.gameObject.AddComponent(type);
                SerializedObject serialiedScript = new SerializedObject(component);

                foreach (var _mark in marks)
                {
                    var _type = _mark.fieldType;
                    if (_type.StartsWith("UnityEngine.") && _type.LastIndexOf(".") == "UnityEngine".Length)
                    {
                        _type = _type.Replace("UnityEngine.", "");
                    }
                    serialiedScript.FindProperty(_mark.fieldName).objectReferenceValue = _mark.GetComponent(_type);
                }
                serialiedScript.ApplyModifiedPropertiesWithoutUndo();
            }
            private const string formatScript = "/*********************************************************************************\n" +
                " *Author:         #SCAuthor#\n" +
                " *Version:        #SCVERSION#\n" +
                " *UnityVersion:   #SCUNITYVERSION#\n" +
                " *Date:           #SCDATE#\n" +
                " *Description:    #SCDescription#\n" +
                " *History:        #SCDATE#--\n" +
                "*********************************************************************************/\n" +
                "\n" +
                "namespace #SCNameSpace#\n" +
                "{\n" +
                "\tpublic class #SCSCRIPTNAME# : #BaseClass#\n" +
                "\t{\n" +
                "#SCField#\n" +
                "\t}\n" +
                "}";
        }



    }
}
