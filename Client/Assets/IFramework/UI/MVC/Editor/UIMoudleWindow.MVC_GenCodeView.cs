/*********************************************************************************
 *Author:         OnClick
 *Version:        1.0
 *UnityVersion:   2020.3.3f1c1
 *Date:           2022-08-03
 *Description:    Description
 *History:        2022-08-03--
*********************************************************************************/
using UnityEditor;
using IFramework.GUITool;
using UnityEngine;
using System;
using System.IO;
using static IFramework.UI.UIMoudleWindow;

namespace IFramework.UI.MVC
{
    public partial class UIMoudleWindow
    {
        [Serializable]
        public class MVC_GenCodeView : UIMoudleWindowTab
        {
            private const string key = "MVC_GenCodeView_";
            public override string name { get { return "MVC_Gen_CS"; } }
            [SerializeField] private string UIMapDir = "Assets/Project";
            [SerializeField]
            private string PanelGenDir
            {
                get
                {
                    if (panel == null) return "";
                    string path = UIMapDir.CombinePath(panel.name);
                    return path;
                }
            }
            private string ns
            {
                get
                {
                    if (panel != null)
                    {
                        return panel.GetType().Namespace;
                    }
                    return "";
                }
            }
            [SerializeField] private string UIMapName = "UIMap_MVC";
            [SerializeField] private UIPanel panel;
            [SerializeField] private FloderField FloderField;
            private MVCPanelGenData sto;
            string UIMap_CSName { get { return UIMapName.Append(".cs"); } }

            public override void OnEnable()
            {
                var last = this.GetFromPrefs<MVC_GenCodeView>(key);
                if (last != null)
                {
                    this.panel = last.panel;
                    this.UIMapDir = last.UIMapDir;
                    this.UIMapName = last.UIMapName;
                }
                this.FloderField = new FloderField(UIMapDir);
            }
            public override void OnDisable()
            {
                this.SaveToPrefs(key);
            }

            public override void OnGUI()
            {
                if (EditorApplication.isCompiling)
                {
                    GUILayout.Label("Editor is Compiling");
                    GUILayout.Label("please wait");
                    return;
                }
                GUILayout.Space(5);
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("Work Directory For Module", GUIStyles.toolbar);
                    GUILayout.Space(20);

                    FloderField.OnGUI(EditorGUILayout.GetControlRect());
                    UIMapDir = FloderField.path;
                    GUILayout.EndHorizontal();
                }
                GUILayout.BeginHorizontal();
                {
                    EditorGUI.BeginChangeCheck();
                    UIMapName = EditorGUILayout.TextField("UI Map Name", UIMapName);
                    if (GUILayout.Button("Load Map Config", GUILayout.Width(120)))
                    {
                        LoadGenData();
                    }
                    if (EditorGUI.EndChangeCheck())
                    {
                        if (sto != null)
                        {
                            sto.MapName = UIMapName;
                            sto.Save();
                        }
                    }
                    GUILayout.EndHorizontal();
                }

                EditorGUI.BeginChangeCheck();
                panel = EditorGUILayout.ObjectField("UIPanel", panel, typeof(UIPanel), true) as UIPanel;
                EditorGUILayout.LabelField("UIPanelGenPath", PanelGenDir);
                if (EditorGUI.EndChangeCheck())
                {
                    if (panel != null && !Directory.Exists(PanelGenDir))
                    {
                        Directory.CreateDirectory(PanelGenDir);
                        AssetDatabase.Refresh();
                    }
                }

                GUILayout.Space(10);


                GUILayout.Space(10);
                if (GUILayout.Button("Gen"))
                {
                    if (string.IsNullOrEmpty(UIMapDir))
                    {
                        EditorWindow.focusedWindow.ShowNotification(new GUIContent("Set UI Map Gen Dir "));
                        return;
                    }
                    if (panel == null)
                    {
                        EditorWindow.focusedWindow.ShowNotification(new GUIContent("Select UI Panel"));
                        return;
                    }
                    string paneltype = panel.GetType().Name;
                    string vmType = paneltype.Append("ViewModel");
                    string viewType = paneltype.Append("View");
                    if (panel != null && !Directory.Exists(PanelGenDir))
                    {
                        Directory.CreateDirectory(PanelGenDir);
                    }
                    WriteView(viewType, vmType, panel.GetType(), paneltype, ns);
                    WriteMap(UIMapDir.CombinePath(UIMap_CSName), panel.name, ns, panel.GetType());
                    AssetDatabase.Refresh();
                }
                GUILayout.Space(10);

                if (sto != null)
                {
                    scroll = GUILayout.BeginScrollView(scroll);
                    {
                        for (int i = 0; i < sto.map.Count; i++)
                        {
                            var index = i;
                            var _nm = sto.map[index];
                            GUILayout.BeginHorizontal();
                            {
                                GUILayout.Label(_nm.panelName);
                                if (GUILayout.Button("", GUIStyles.minus))
                                {
                                    sto.RemoveMap(_nm.panelName);
                                    sto.Save();
                                    AssetDatabase.DeleteAsset(sto.workspace.CombinePath(_nm.panelName));
                                    //Directory.Delete(sto.workspace.CombinePath(_nm.panelName), true);
                                    WriteMap(sto.workspace.CombinePath(UIMap_CSName), sto.ns);
                                }
                                GUILayout.EndHorizontal();
                            }
                        }

                        GUILayout.EndScrollView();
                    }
                }

            }
            Vector2 scroll;
            private void LoadGenData()
            {
                sto = MVCPanelGenData.CheckExist<MVCPanelGenData>(UIMapDir);
                UIMapName = sto.MapName;
            }





            private void WriteView(string viewType, string vmType, Type type, string panelType, string ns)
            {
                string designPath = PanelGenDir.CombinePath(viewType.Append(".Design.cs"));
                string path = PanelGenDir.CombinePath(viewType.Append(".cs"));

                WriteTxt(designPath, viewDesignScriptOrigin,
               (str) =>
               {

                   return str.Replace("#VMType#", vmType)
                   .Replace("#PanelType#", panelType)
                   .Replace("#panelfield#", GetPanelField(type))
                   .Replace(".Design", "");
               }, ns
               );
                if (!File.Exists(path))
                {
                    WriteTxt(path, viewScriptOrigin, null, ns);
                }
            }
            private string GetPanelField(Type panel)
            {
                string result = "";
                foreach (var field in panel.GetFields())
                {
                    result += string.Format("\t\tprivate {0} {2} {1} get {1} return Tpanel.{2}; {3} {3}\n", field.FieldType.FullName, "{", field.Name, "}");

                }

                return result;
            }

            private void WriteMap(string path, string ns)
            {
                string replace = "";
                string namerp = "";
                LoadGenData();
                sto.map.ForEach(_nm =>
                {
                    namerp = namerp.Append("\t\tpublic const string " + _nm.panelName + " = " + "\"" + _nm.panelName + "\";\n");
                    replace = replace.Append("\t\t\t" + _nm.content + ",\n");
                });
                WriteTxt(path, mapScriptOrigin.Replace("//Names", namerp).Replace("//ToDo", replace), null, ns);
            }
            private void WriteMap(string path, string panelName, string ns, Type panelType)
            {
                LoadGenData();
                string content = string.Format("{1} {0} ,typeof({3}.{4}View){2}", panelName, "{", "}", ns, panelType.Name);
                sto.AddMap(panelName, content);
                sto.ns = ns;
                sto.workspace = UIMapDir;
                sto.Save();
                WriteMap(path, ns);
            }
            private static void WriteTxt(string writePath, string source, Func<string, string> func, string ns)
            {
                source = source.Replace("#User#", EditorTools.ProjectConfig.UserName)
                         .Replace("#UserSCRIPTNAME#", Path.GetFileNameWithoutExtension(writePath))
                           .Replace("#UserNameSpace#", ns)
                           .Replace("#UserVERSION#", EditorTools.ProjectConfig.Version)
                           .Replace("#UserDescription#", EditorTools.ProjectConfig.Description)
                           .Replace("#UserUNITYVERSION#", Application.unityVersion)
                           .Replace("#UserDATE#", DateTime.Now.ToString("yyyy-MM-dd")).ToUnixLineEndings();
                if (func != null)
                    source = func.Invoke(source);
                File.WriteAllText(writePath, source, System.Text.Encoding.UTF8);
            }


            private const string head = "/*********************************************************************************\n" +
            " *Author:         #User#\n" +
            " *Version:        #UserVERSION#\n" +
            " *UnityVersion:   #UserUNITYVERSION#\n" +
            " *Date:           #UserDATE#\n" +
            " *Description:    #UserDescription#\n" +
            " *History:        #UserDATE#--\n" +
            "*********************************************************************************/\n";



            private const string viewDesignScriptOrigin = head +
            "namespace #UserNameSpace#\n" +
            "{\n" +
            "\tpublic partial class #UserSCRIPTNAME# : IFramework.UI.MVC.UIView<#PanelType#> \n" +
            "\t{\n" +
            "#panelfield#\n" +
            "\t}\n" +
            "}";
            private const string viewScriptOrigin = head +
            "namespace #UserNameSpace#\n" +
            "{\n" +
            "\tpublic partial class #UserSCRIPTNAME#\n" +
            "\t{\n" +
            "\t\tprotected override void OnLoad()\n" +
            "\t\t{\n" +
            "\t\t}\n" +
            "\n" +
            "\t\tprotected override void OnShow()\n" +
            "\t\t{\n" +
            "\t\t}\n" +
            "\n" +
             "\t\tprotected override void OnHide()\n" +
            "\t\t{\n" +
            "\t\t}\n" +
            "\n" +
            "\t\tprotected override void OnClose()\n" +
            "\t\t{\n" +
            "\t\t}\n" +
            "\n" +
            "\t}\n" +
            "}";
            private const string mapScriptOrigin = head +
           "namespace #UserNameSpace#\n" +
           "{\n" +
            "\tpartial class #UserSCRIPTNAME#\n" +
            "\t{\n" +
            "//Names\n" +
            "\t}\n" +
           "\tpublic partial class #UserSCRIPTNAME# \n" +
           "\t{\n" +
           "\t\tpublic static System.Collections.Generic.Dictionary<string, System.Type> map = \n" +
           "\t\tnew System.Collections.Generic.Dictionary<string, System.Type>()\n" +
           "\t\t{\n" +
           "\n" +
           "//ToDo\n" +
           "\t\t}\n;" +
           "\t }\n" +
           "}\n";

        }
    }
}
