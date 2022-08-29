/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.11f1
 *Date:           2020-01-13
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using UnityEditor;
using IFramework.GUITool;
using UnityEngine;
using System.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using static IFramework.UI.UIMoudleWindow;

namespace IFramework.UI.MVVM
{
    public partial class UIMoudleWindow
    {
        [Serializable]
        public class MVVM_GenCodeView : UIMoudleWindowTab
        {
            private const string key = "MVVM_GenCodeView";
            public override string name { get { return "MVVM_Gen_CS"; } }
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
            [SerializeField] private string UIMapName = "UIMap_MVVM";
            //[SerializeField] private List<string> panelTypes;
            [SerializeField] private UIPanel panel;
            [SerializeField] private FloderField FloderField;
            //[SerializeField] private string panelType;
            [SerializeField] private List<string> modelTypes;
            [SerializeField] private string modelType;
            private MVVMPanelGenData sto;
            string UIMap_CSName { get { return UIMapName.Append(".cs"); } }

            public override void OnEnable()
            {
                var last = this.GetFromPrefs<MVVM_GenCodeView>(key);
                if (last != null)
                {
                    this.panel = last.panel;
                    this.UIMapDir = last.UIMapDir;
                    this.UIMapName = last.UIMapName;
                    this.modelTypes = last.modelTypes;
                    this.modelType = last.modelType;
                }
                this.FloderField = new FloderField(UIMapDir);
                modelTypes = typeof(IModel).GetSubTypesInAssemblys()
                  .Where(type => !type.IsAbstract && type.IsClass)
                  .Select((type) =>
                  {
                      return type.FullName;
                  }).ToList();
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

                GUILayout.BeginHorizontal();
                {
                    if (GUILayout.Button("Create EventArgs And Model"))
                    {
                        if (panel == null)
                        {
                            EditorWindow.focusedWindow.ShowNotification(new GUIContent("Select panel first"));
                        }
                        else
                        {
                            if (panel != null && !Directory.Exists(PanelGenDir))
                            {
                                Directory.CreateDirectory(PanelGenDir);
                            }
                            CreateEventArgs(panel.GetType(), ns);
                            CreateModel(panel.GetType(), ns);
                        }
                    }

                    GUILayout.Space(20);

                    if (GUILayout.Button("Fresh Model Types"))
                    {
                        modelTypes = typeof(IModel).GetSubTypesInAssemblys()
                            .Where(type => !type.IsAbstract && type.IsClass)
                            .Select((type) =>
                            {
                                return type.FullName;
                            }).ToList();
                    }
                    GUILayout.EndHorizontal();
                }

                GUILayout.Space(10);

                GUILayout.Space(10);
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("Click To Select Model Type", GUIStyles.toolbar);
                    Rect pos = GUILayoutUtility.GetLastRect();
                    if (GUILayout.Button(new GUIContent(string.Format("ModelType: {0}", modelType)), GUIStyles.label))
                    {
                        if (modelTypes == null)
                        {
                            EditorWindow.focusedWindow.ShowNotification(new GUIContent("Fresh Model Types"));
                            return;
                        }
                        int index = -1;
                        for (int i = 0; i < modelTypes.Count; i++)
                        {
                            if (modelTypes[i] == modelType)
                            {
                                index = i; break;
                            }
                        }
                        SearchablePopup.Show(pos, modelTypes.ToArray(), index, (i, str) =>
                        {
                            modelType = str;
                        });
                    }


                    GUILayout.EndHorizontal();
                }

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
                    if (string.IsNullOrEmpty(modelType))
                    {
                        EditorWindow.focusedWindow.ShowNotification(new GUIContent("Select UI Model Type "));
                        return;
                    }
                    string _modelType = modelType.Split('.').ToList().Last();
                    string paneltype = panel.GetType().Name;
                    string vmType = paneltype.Append("ViewModel");
                    string viewType = paneltype.Append("View");
                    if (panel != null && !Directory.Exists(PanelGenDir))
                    {
                        Directory.CreateDirectory(PanelGenDir);
                    }
                    WriteView(viewType, vmType, panel.GetType(), paneltype, ns);
                    WriteVM(vmType, viewType, ns);
                    WriteMap(UIMapDir.CombinePath(UIMap_CSName), panel.name, ns, modelType, panel.GetType());
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
                sto = MVVMPanelGenData.CheckExist<MVVMPanelGenData>(UIMapDir);
                UIMapName = sto.MapName;
            }



            private void CreateEventArgs(Type type, string ns)
            {
                WriteTxt(PanelGenDir.CombinePath($"{type.Name}Args.cs"), argsOrigin, null, ns);
                AssetDatabase.Refresh();
            }
            private void CreateModel(Type type, string ns)
            {
                WriteTxt(PanelGenDir.CombinePath($"{type.Name}Model.cs"), modelOrigin, null, ns);
                AssetDatabase.Refresh();
            }
            private void WriteVM(string vmType, string viewType, string ns)
            {
                string designPath = PanelGenDir.CombinePath(vmType.Append(".Design.cs"));
                string path = PanelGenDir.CombinePath(vmType.Append(".cs"));

                WriteTxt(designPath, vmDesignScriptOrigin,
                               (str) =>
                               {
                                   string fieldStr = " ";
                                   string syncStr = " ";
                                   Type t = AppDomain.CurrentDomain.GetAssemblies()
                                               .SelectMany((a) => { return a.GetTypes(); })
                                               .ToList().Find((type) => { return type.FullName == modelType; });
                                   var fs = t.GetFields();
                                   for (int i = 0; i < fs.Length; i++)
                                   {
                                       var info = fs[i];
                                       fieldStr = WriteField(fieldStr, info.FieldType, info.Name);
                                       syncStr = WriteSyncStr(syncStr, info.Name);
                                   }

                                   return str.Replace("#ModelType#", t.FullName)
                                             .Replace("#FieldString#", fieldStr)
                                             .Replace("#viewType#", viewType)
                                             .Replace("#SyncModelValue#", syncStr)
                                             .Replace(".Design", "");
                               }
                           , ns);
                if (!File.Exists(path))
                {
                    WriteTxt(path, vmScriptOrigin, (str) =>
                    {
                        return str.Replace("#viewType#", viewType);
                    }, ns);
                }
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
            private string WriteField(string result, Type ft, string fn)
            {
                return result.Append(string.Format("\t\tprivate {0} _{1};\n", ft.FullName, fn))
                                .Append(string.Format("\t\tpublic {0} {1}\n", ft.FullName, fn))
                                .Append(string.Format("\t\t{0}\n", "{"))
                                //.Append(string.Format("\t\t\tget {0} return GetProperty(ref _{1}, this.GetPropertyName(() => _{1})); {2}\n", "{", fn, "}"))
                                .Append(string.Format("\t\t\tget {0} return GetProperty(ref _{1}); {2}\n", "{", fn, "}"))

                                .Append(string.Format("\t\t\tprivate set"))
                                .Append(string.Format("\t\t\t{0}\n", "{"))
                                .Append(string.Format("\t\t\t\tTmodel.{0} = value;\n", fn))
                                //.Append(string.Format("\t\t\t\tSetProperty(ref _{0}, value, this.GetPropertyName(() => _{0}));\n", fn))
                                .Append(string.Format("\t\t\t\tSetProperty(ref _{0}, value);\n", fn))

                                .Append(string.Format("\t\t\t{0}\n", "}"))
                                .Append(string.Format("\t\t{0}\n\n", "}"));
            }
            private string WriteSyncStr(string result, string fn)
            {
                return result.Append(string.Format("\t\t\tthis.{0} = Tmodel.{0};\n", fn));

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
            private void WriteMap(string path, string panelName, string ns, string modelType, Type panelType)
            {
                LoadGenData();
                string content = string.Format("{2} {0} ,System.Tuple.Create(typeof({1}),typeof({4}.{5}View),typeof({4}.{5}ViewModel)){3}", panelName, modelType, "{", "}", ns, panelType.Name);
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

            private const string argsOrigin = head +
            "namespace #UserNameSpace#\n" +
            "{\n" +
            "\tpublic class #UserSCRIPTNAME# : IFramework.IEventArgs\n" +
            "\t{\n" +
            "\t\t//write your args fields here\n" +
            "\t}\n" +
            "}";
            private const string modelOrigin = head +
            "namespace #UserNameSpace#\n" +
            "{\n" +
            "\tpublic class #UserSCRIPTNAME# : IFramework.IModel\n" +
            "\t{\n" +
            "\t\t//write your model fields here\n" +
            "\t}\n" +
            "}";
            private const string vmDesignScriptOrigin = head +
            "namespace #UserNameSpace#\n" +
            "{\n" +
            "\tpublic partial class #UserSCRIPTNAME# : IFramework.UI.MVVM.UIViewModel<#ModelType#>\n" +
            "\t{\n" +
            "#FieldString#\n" +
            "\t\tprotected override void SyncModelValue()\n" +
            "\t\t{\n" +
            "#SyncModelValue#\n" +
            "\t\t}\n" +
            "\n" +
            "\t}\n" +
            "}";
            private const string vmScriptOrigin = head +
            "namespace #UserNameSpace#\n" +
            "{\n" +
            "\tpublic partial class #UserSCRIPTNAME#\n" +
            "\t{\n" +

            "\t\tprotected override void Initialize()\n" +
            "\t\t{\n" +
            "\n" +
            "\t\t}\n" +
            "\n" +
            "\t\tprotected override void OnDispose()\n" +
            "\t\t{\n" +
            "\n" +
            "\t\t}\n" +
            "\n" +
            "\t\tprotected override void Listen(IFramework.IEventArgs message)\n" +
            "\t\t{\n" +
            "\n" +
            "\t\t}\n" +
            "\n" +

            "\t}\n" +

            "}";
            private const string viewDesignScriptOrigin = head +
            "namespace #UserNameSpace#\n" +
            "{\n" +
            "\tpublic partial class #UserSCRIPTNAME# : IFramework.UI.MVVM.UIView<#VMType#, #PanelType#> \n" +
            "\t{\n" +
            "#panelfield#\n" +
            "\t}\n" +
            "}";
            private const string viewScriptOrigin = head +
            "namespace #UserNameSpace#\n" +
            "{\n" +
            "\tpublic partial class #UserSCRIPTNAME#\n" +
            "\t{\n" +
            "\t\tprotected override void BindProperty()\n" +
            "\t\t{\n" +
            "\t\t\tbase.BindProperty();\n" +
            "\t\t\t//ToDo\n" +
            "\t\t}\n" +
            "\n" +
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
           "\t\tpublic static System.Collections.Generic.Dictionary<string, System.Tuple<System.Type, System.Type, System.Type>> map = \n" +
           "\t\tnew System.Collections.Generic.Dictionary<string, System.Tuple<System.Type, System.Type, System.Type>>()\n" +
           "\t\t{\n" +
           "\n" +
           "//ToDo\n" +
           "\t\t}\n;" +
           "\t }\n" +
           "}\n";

        }
    }
}
