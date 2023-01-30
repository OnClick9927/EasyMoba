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
using System.IO;
using System.Collections.Generic;
using IFramework.UI;
using static IFramework.EditorTools;
using IFramework.UI.MVC;

namespace IFramework.Hotfix.Lua
{

    static partial class LuaEditorTools
    {
        [Serializable]
        class MVC_GenCodeView_Lua : UI.UIMoudleWindow.UIMoudleWindowTab
        {
            private EditorTools.ScriptCreater creater = new ScriptCreater();
            private ScriptCreaterFieldsDrawer fields;
            private LuaFloderField FloderField;

            [SerializeField] private string UIdir;
            [SerializeField] private UIPanel panel;
 
            public override string name => "MVC_Gen_Lua";

            private string viewName => panelName.Append("View");
            private string panelName => panel == null ? "" : panel.name;

            public override void OnEnable()
            {
                var last = this.GetFromPrefs<MVC_GenCodeView_Lua>(name);
                if (last != null)
                {
                    this.UIdir = last.UIdir;
                    this.panel = last.panel;
                }
                FloderField = new LuaFloderField();
                fields = new ScriptCreaterFieldsDrawer(creater);
                SetViewData();
            }
            public override void OnHierarchyChanged()
            {
                creater.ColllectMarks();
            }
            public override void OnDisable()
            {
                this.SaveToPrefs(name);
            }

            public override void OnGUI()
            {
                if (EditorApplication.isCompiling)
                {
                    GUILayout.Label("Editor is Compiling\nplease wait");
                    return;
                }
                if (GUILayout.Button("Gen"))
                {
                    if (panel == null) EditorWindow.focusedWindow.ShowNotification(new GUIContent("Set UI Panel "));
                    else
                    {
                        string err;
                        if (!creater.FieldCheck(out err)) EditorUtility.DisplayDialog("Err", err, "ok");
                        else
                        {
                            if (!Directory.Exists(UIdir)) Directory.CreateDirectory(UIdir);
                            CreateView(UIdir.CombinePath(viewName).Append(".lua.txt"));
                            AssetDatabase.Refresh();
                        }
                    }
                }
                //EditorGUILayout.LabelField("Panel Names", PanelNamesName);

                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("Panel Directory", GUIStyles.Get("toolbar"));
                    GUILayout.Space(20);
                    FloderField.OnGUI(EditorGUILayout.GetControlRect());
                    if (FloderField.leagal)
                        UIdir = FloderField.path;
                    else
                        FloderField.SetPath(UIdir);
                    GUILayout.EndHorizontal();
                }
                EditorGUI.BeginChangeCheck();

                panel = EditorGUILayout.ObjectField("UIPanel", panel, typeof(UIPanel), true) as UIPanel;
                if (EditorGUI.EndChangeCheck())
                {
                    SetViewData();
                }
                fields.OnGUI();               

            }

            private void FindDir()
            {
                string total = viewName.Append(".lua.txt");
                string find = AssetDatabase.GetAllAssetPaths().ToList().Find(x => x.EndsWith(total));
                if (string.IsNullOrEmpty(find))
                {
                    FloderField.SetPath(string.Empty);
                }
                else
                {
                    FloderField.SetPath(find.Replace(total, "").ToAssetsPath());
                }
            }

            private void SetViewData()
            {
                if (panel != null)
                {
                    creater.SetGameObject(panel.gameObject);
                    FindDir();
                }
                else
                {
                    creater.SetGameObject(null);
                    FloderField.SetPath(string.Empty);
                }
            }



            private void CreateView(string path)
            {
                if (File.Exists(path))
                {
                    var target = string.Format("function {0}View:OnLoad()", panelName);
                    var txt = File.ReadAllText(path);
                    int start = txt.IndexOf(target);
                    start = txt.IndexOf("self.Controls", start);
                    int depth = 0;
                    int end = -1;
                    for (int i = start + 1; i < txt.Length; i++)
                    {
                        char data = txt[i];
                        if (data == '{')
                        {
                            if (depth == 0)
                                start = i;
                            depth++;
                        }
                        else if (data == '}')
                            depth--;
                        else
                        {
                            continue;
                        }
                        if (depth == 0)
                        {
                            end = i;
                            break;
                        }
                    }
                    if (end == -1) return;
                    txt = txt.Remove(start, end - start + 1);
                    string fs = Fields().Append("\n\t}").AppendHead("{\n");
                    txt = txt.Insert(start, fs);
                    var flag = "---ViewUseFlag";
                    start = txt.IndexOf(flag);
                    end = txt.IndexOf(flag, start + flag.Length);
                    txt = txt.Remove(start, end - start);
                    File.WriteAllText(path, txt.Insert(start, StaticUse().AppendHead(flag + "\n").Append("\n")));
                }
                else
                {

                    string result = vSource.Replace("#PanelName#", panelName)
                        .Replace(ViewUseFlag, StaticUse())
                            .Replace(ViewFeildFlag, Fields());
                    File.WriteAllText(path, result.ToUnixLineEndings());
                }
            }
            private string StaticUse()
            {
                List<string> usings = new List<string>();
                var marks = creater.GetMarks();
                if (marks != null)
                {
                    for (int i = 0; i < marks.Count; i++)
                    {
                        string ns = marks[i].fieldType;
                        if (!usings.Contains(ns))
                        {
                            usings.Add(ns);
                        }
                    }
                }
                string use = "";
                for (int i = 0; i < usings.Count; i++)
                {
                    use = use.Append(string.Format("local {2} = StaticUsing(\"{0}\"){1}", usings[i], i == usings.Count - 1 ? "" : "\n", usings[i].Split('.').Last()));
                }
                return use;
            }
            private string Fields()
            {
                var marks = creater.GetMarks();

                string f = "";

                if (marks != null)
                {
                    for (int i = 0; i < marks.Count; i++)
                    {
                        string fieldType = marks[i].fieldType;
                        string fieldName = marks[i].fieldName;
                        string type = marks[i].fieldType.Split('.').Last();

                        string path = marks[i].transform.GetPath().Replace(creater.gameObject.transform.GetPath(), "").Remove(0, 1);
                        f = f.Append("\t\t---@type " + fieldType + "\n");
                        f = f.Append(string.Format("\t\t{0} = self:GetComponent(\"{1}\", typeof({2})),{3}", fieldName, path,type, i == marks.Count - 1 ? "" : "\n"));
                    }
                }

                return f;
            }

          

            public const string ViewUseFlag = "--using";
            public const string ViewFeildFlag = "--Find";
            public static string head = "--*********************************************************************************\n" +
              "--Author:         " + EditorTools.ProjectConfig.UserName + "\n" +
              "--Version:        " + EditorTools.ProjectConfig.Version + "\n" +
              "--UnityVersion:   " + Application.unityVersion + "\n" +
              "--Date:           " + DateTime.Now.ToString("yyyy-MM-dd") + "\n" +
              "--*********************************************************************************\n";
            static string vSource = head + "\n" +
             "---ViewUseFlag\n" +
             ViewUseFlag + "\n\n" +
             "---ViewUseFlag\n" +
              "---@class #PanelName#View : UIView_MVC" + "\n" +
             "local #PanelName#View = class(\"#PanelName#View\",UIView_MVC)\n\n" +
             "function #PanelName#View:OnLoad()\n" +
             "\tself.Controls = {\n" +
              ViewFeildFlag + "\n\t}\n" +
              "\t--BindUIEvent\n\n" +
             "end\n\n" +
             "function #PanelName#View:OnShow()\n\n" +
             "end\n\n" +
             "function #PanelName#View:OnHide()\n\n" +
             "end\n\n" +
             "function #PanelName#View:OnClose()\n" +
             "\tself.Controls = nil\n" +
             "end\n\n" +

             "return " + "#PanelName#View";


         

        }
    }


}

