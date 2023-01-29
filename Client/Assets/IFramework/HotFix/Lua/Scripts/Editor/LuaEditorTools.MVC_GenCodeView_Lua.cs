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
            private Vector2 scroll;
            private MVCPanelGenData sto;
            private EditorTools.ScriptCreater creater = new ScriptCreater();
            private ScriptCreaterFieldsDrawer fields;
            private LuaFloderField field;

            [SerializeField] private string workFolder;
            [SerializeField] private UIPanel panel;
            private const string UIMapName = "MVCMap";
            //private const string PanelNamesName = "PanelNames_MVC";
            private const string key = "MVC_GenCodeView";
            public override string name => "MVC_Gen_Lua";

            public static string hotFixScriptPath => Application.dataPath.CombinePath("Project/Lua").ToAssetsPath();
            private string mapPath => workFolder.CombinePath(UIMapName).Append(".lua.txt");
            private string panelName => panel == null ? "" : panel.name;
            private string panelFolder => panel == null ? "" : workFolder.CombinePath(panelName);
            private string ViewName => panelName.Append("View");

            private void LoadNameSto(string work)
            {
                sto = MVCPanelGenData.CheckExist<MVCPanelGenData>(work);
            }
            public override void OnGUI()
            {
                if (EditorApplication.isCompiling)
                {
                    GUILayout.Label("Editor is Compiling\nplease wait");
                    return;
                }
                EditorGUILayout.LabelField("UIMap Name", UIMapName);
                //EditorGUILayout.LabelField("Panel Names", PanelNamesName);

                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("Work Directory For Module", GUIStyles.Get("toolbar"));
                    GUILayout.Space(20);
                    field.OnGUI(EditorGUILayout.GetControlRect());
                    if (field.leagal)
                        workFolder = field.path;
                    else
                        field.SetPath(workFolder);
                    GUILayout.EndHorizontal();
                }
                panel = EditorGUILayout.ObjectField("UIPanel", panel, typeof(UIPanel), true) as UIPanel;
                if (panel != null)
                    creater.SetGameObject(panel.gameObject);
                EditorGUILayout.LabelField("UIPanelGenPath", panelFolder);
                fields.OnGUI();
                if (GUILayout.Button("Gen"))
                {
                    if (panel == null) EditorWindow.focusedWindow.ShowNotification(new GUIContent("Set UI Panel "));
                    else
                    {
                        string err;
                        if (!creater.FieldCheck(out err)) EditorUtility.DisplayDialog("Err", err, "ok");
                        else
                        {
                            if (!Directory.Exists(panelFolder)) Directory.CreateDirectory(panelFolder);
                            CreateView(panelFolder.CombinePath(ViewName).Append(".lua.txt"));
                            AddCurrentPanelToMap(mapPath);
                            AssetDatabase.Refresh();
                        }
                    }
                }

                GUILayout.Space(10);
                if (GUILayout.Button("Load Panel Names Map")) LoadNameSto(workFolder);
                if (sto == null) return;
                scroll = GUILayout.BeginScrollView(scroll);
                {
                    for (int i = 0; i < sto.map.Count; i++)
                    {
                        var index = i;
                        var _nm = sto.map[index];
                        GUILayout.BeginHorizontal();
                        GUILayout.Label(_nm.panelName);
                        if (GUILayout.Button("", GUIStyles.minus)) DeletePanelFromMap(_nm.panelName);
                        GUILayout.EndHorizontal();
                    }
                    GUILayout.EndScrollView();
                }

            }
            private void WriteMap(string path)
            {
                //string namsPath = path.Replace(UIMapName, PanelNamesName);

                string replace = "";
                string namerp = "";
                LoadNameSto(workFolder);
                sto.map.ForEach(_nm =>
                {
                    namerp = namerp.Append(string.Format("\t{0} = \"{0}\",\n", _nm.panelName));
                    replace = replace.Append("\t" + _nm.content + "\n");
                });
                //string PanelNamesNameSub = namsPath.Replace(hotFixScriptPath, "").Replace(".lua.txt", "").Replace("/", ".").Remove(0, 1);

                //File.WriteAllText(namsPath, NameMapSource.Replace(nameFlag, namerp).ToUnixLineEndings());
                File.WriteAllText(path, mapSource.Replace(mapFlag, replace)
                         //.Replace("#requirePath#", PanelNamesNameSub)
                         .ToUnixLineEndings());
            }
            private void DeletePanelFromMap(string panelName)
            {
                sto.RemoveMap(panelName);
                sto.Save();
                AssetDatabase.DeleteAsset(sto.workspace.CombinePath(panelName));
                //FileUtil.DeleteFileOrDirectory(sto.workspace.CombinePath(panelName));
                //Directory.Delete(sto.workspace.CombinePath(panelName), true);
                WriteMap(sto.workspace.CombinePath(UIMapName).Append(".lua.txt"));
            }
            private void AddCurrentPanelToMap(string path)
            {
                string sub = panelFolder.Replace(hotFixScriptPath, "").Replace("/", ".").Remove(0, 1);
                string content = string.Format("{0} Name = \"{2}\",ViewType = require(\"{3}\") {1},", "{", "}", panelName, sub.Append("." + ViewName));
                LoadNameSto(workFolder);
                sto.AddMap(panelName, content);
                sto.workspace = workFolder;
                sto.Save();
                WriteMap(path);
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
                    string sub = panelFolder.Replace(hotFixScriptPath, "").Replace("/", ".").Remove(0, 1);

                    string result = vSource.Replace("#PanelName#", panelName)
                        .Replace(ViewUseFlag, StaticUse())
                            .Replace(ViewFeildFlag, Fields()).Replace("#sub#", sub + ".");
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
                List<tmp> fs = new List<tmp>();
                var marks = creater.GetMarks();

                if (marks != null)
                {
                    for (int i = 0; i < marks.Count; i++)
                    {
                        string ns = marks[i].fieldType;
                        fs.Add(new tmp()
                        {
                            ns = marks[i].fieldType,
                            fn = marks[i].fieldName,
                            type = ns.Split('.').Last(),
                            path = marks[i].transform.GetPath().Replace(creater.gameObject.transform.GetPath(), "").Remove(0, 1)
                        });
                    }
                }
                string f = "";
                for (int i = 0; i < fs.Count; i++)
                {
                    f = f.Append("\t\t---@type " + fs[i].ns + "\n");
                    f = f.Append(string.Format("\t\t{0} = self:GetComponent(\"{1}\", typeof({2})),{3}", fs[i].fn, fs[i].path, fs[i].type, i == fs.Count - 1 ? "" : "\n"));
                }
                return f;
            }

            public override void OnEnable()
            {
                var last = this.GetFromPrefs<MVC_GenCodeView_Lua>(key);
                if (last != null)
                {
                    this.workFolder = last.workFolder;
                    this.panel = last.panel;
                }
                field = new LuaFloderField();
                field.SetPath(workFolder);
                fields = new ScriptCreaterFieldsDrawer(creater);
            }
            public override void OnHierarchyChanged()
            {
                creater.ColllectMarks();
            }
            public override void OnDisable()
            {
                this.SaveToPrefs(key);
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


            static string mapSource = head +
            "local map =\n" +
            "{\n" +
             mapFlag + 
            "\n}\n" +
            "return map";
            const string mapFlag = "--Todo";

        }
    }


}

