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
using IFramework.UI.MVVM;

namespace IFramework.Hotfix.Lua
{
    static partial class LuaEditorTools
    {

        [Serializable]
        class MVVM_GenCodeView_Lua : UI.UIMoudleWindow.UIMoudleWindowTab
        {
            private Vector2 scroll;
            private MVVMPanelGenData sto;
            private EditorTools.ScriptCreater creater = new ScriptCreater();
            private ScriptCreaterFieldsDrawer fields;
            private LuaFloderField field;

            [SerializeField] private string workFolder;
            [SerializeField] private UIPanel panel;
            private const string UIMapName = "MVVMMap";
            //private const string PanelNamesName = "PanelNames_MVVM";
            private const string key = "MVVM_GenCodeView";
            public override string name => "MVVM_Gen_Lua";

            public static string hotFixScriptPath => Application.dataPath.CombinePath("Project/Lua").ToAssetsPath();
            private string mapPath => workFolder.CombinePath(UIMapName).Append(".lua.txt");
            private string panelName => panel == null ? "" : panel.name;
            private string panelFolder => panel == null ? "" : workFolder.CombinePath(panelName);
            private string ViewName => panelName.Append("View");
            private string VMName => panelName.Append("ViewModel");
            private string ViewEventName => panelName.Append("ViewEventType");
            private string viewModelFieldsName => panelName.Append("ViewModelFields");



            private void LoadNameSto(string work)
            {
                sto = MVVMPanelGenData.CheckExist<MVVMPanelGenData>(work);
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
                            CreateVM(panelFolder.CombinePath(VMName).Append(".lua.txt"));
                            AddCurrentPanelToMap(mapPath);
                            CreateViewEvent(panelFolder.CombinePath(ViewEventName + ".lua.txt"));
                            CreateViewModelFields(panelFolder.CombinePath(viewModelFieldsName + ".lua.txt"));
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
                        var _nm=sto.map[index];
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
                string content = string.Format("{0} Name = \"{2}\",ViewType = require(\"{3}\"), VMType = require(\"{4}\") {1},", "{", "}", panelName, sub.Append("." + ViewName), sub.Append("." + VMName));
                LoadNameSto(workFolder);
                sto.AddMap(panelName, content);
                sto.workspace = workFolder;
                sto.Save();
                WriteMap(path);
            }

            private void CreateViewEvent(string path)
            {
                if (File.Exists(path)) return;
                File.WriteAllText(path, vEveSource.Replace("#PanelName#", panelName).ToUnixLineEndings());

            }
            private void CreateViewModelFields(string path)
            {
                if (File.Exists(path)) return;
                File.WriteAllText(path, vmFieldsSource.Replace("#PanelName#", panelName).ToUnixLineEndings());
            }
            private void CreateVM(string path)
            {
                if (File.Exists(path))
                    return;
                string sub = panelFolder.Replace(hotFixScriptPath, "").Replace("/", ".").Remove(0, 1);
                File.WriteAllText(path, vmSOurce.Replace("#sub#", sub + ".").Replace("#PanelName#", panelName).ToUnixLineEndings());
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
                var last = this.GetFromPrefs<MVVM_GenCodeView_Lua>(key);
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


            public static string head = "--*********************************************************************************\n" +
              "--Author:         " + EditorTools.ProjectConfig.UserName + "\n" +
              "--Version:        " + EditorTools.ProjectConfig.Version + "\n" +
              "--UnityVersion:   " + Application.unityVersion + "\n" +
              "--Date:           " + DateTime.Now.ToString("yyyy-MM-dd") + "\n" +
              "--Description:    " + EditorTools.ProjectConfig.Description + "\n" +
              "--History:        " + DateTime.Now.ToString("yyyy-MM-dd") + "\n" +
              "--*********************************************************************************\n";
            static string vEveSource = head + "\n" +
                "---@class " + "#PanelName#ViewEventType\n" +
                "local " + "#PanelName#View" + "EventType ={\n" +
                "}\n" +
                "return " + "#PanelName#View" + "EventType";
            static string vmFieldsSource = head + "\n" +
            "---@class " + "#PanelName#ViewModelFields\n" +
            "local " + "#PanelName#" + "ViewModelFields ={\n" +
            "}\n" +
            "return " + "#PanelName#" + "ViewModelFields";
            static string vSource = head + "\n" +
             "---ViewUseFlag\n" +
             ViewUseFlag + "\n\n" +
             "---ViewUseFlag\n" +
            "---@type " + "#PanelName#ViewModelFields\n" +
            "local " + "#PanelName#" + "ViewModelFields = require(\"" + "#sub#" + "#PanelName#" + "ViewModelFields\")\n" +
             "---@type " + "#PanelName#ViewEventType\n" +
            "local " + "#PanelName#View" + "EventType = require(\"" + "#sub#" + "#PanelName#View" + "EventType\")\n" +
              "---@class " + "#PanelName#View" + " : UIView_MVVM" + "\n" +
             "local " + "#PanelName#View" + " = class(\"" + "#PanelName#View" + "\",UIView_MVVM)\n" + "\n" +
             "function " + "#PanelName#View" + ":OnLoad()" + "\n" +
             "\tself.Controls = {" + "\n" +
              ViewFeildFlag + "\n" +
              "\t}" + "\n" +
              "\t--BindUIEvent" + "\n\n" +
             "end\n" + "\n" +
             "function " + "#PanelName#View" + ":BindProperty()" + "\n" +
              "\t--BindContextField" + "\n\n" +

             "end\n" + "\n" +

             "function " + "#PanelName#View" + ":OnShow()" + "\n" +
             "" + "\n" +
             "end\n" + "\n" +
             "function " + "#PanelName#View" + ":OnHide()" + "\n" +
             "" + "\n" +
             "end\n" + "\n" +
             "function " + "#PanelName#View" + ":OnClose()" + "\n" +
             "\tself.Controls = nil" + "\n" +
             "end\n" + "\n" +

             "return " + "#PanelName#View";
            static string vmSOurce = head + "\n" +
            "---@type " + "#PanelName#ViewModelFields\n" +
            "local " + "#PanelName#" + "ViewModelFields = require(\"" + "#sub#" + "#PanelName#" + "ViewModelFields\")\n" +
             "---@type " + "#PanelName#ViewEventType\n" +
            "local " + "#PanelName#View" + "EventType = require(\"" + "#sub#" + "#PanelName#View" + "EventType\")\n" +
            "---@class " + "#PanelName#ViewModel" + " : ViewModel" + "\n" +
            "local #PanelName#ViewModel = class(\"#PanelName#ViewModel\",ViewModel)\n" + "\n" +
            "--return #PanelName#ViewModel's Fields By table" + "\n" +
            "--Example return { myCount = 666 }" + "\n" +
            "function #PanelName#ViewModel:GetFieldTable()" + "\n" +
            "" + "\n" +
            "end\n" + "\n" +
            "function #PanelName#ViewModel:OnInitialize()" + "\n" +
            "" + "\n" +
            "end\n" + "\n" +
            "--View's  Event " + "\n" +
            "function #PanelName#ViewModel:ListenViewEvent(code,...)" + "\n" +
            "" + "\n" +
            "end\n" + "\n" +
            "function #PanelName#ViewModel:OnDispose()" + "\n" +
            "" + "\n" +
            "end\n" + "\n" +
            "return #PanelName#ViewModel\n";
            //static string NameMapSource = head +
            //    "" + "\n" +
            //"local PanelNames =" + "\n" +
            //"{" + "\n" +
            //nameFlag + "\n" +
            //"}" + "\n" +
            //"return PanelNames" + "\n";
            static string mapSource = head +
            "local PanelNames = require(\"#requirePath#\")" + "\n" +
            "local map =" + "\n" +
            "{" + "\n" +
           mapFlag + "\n" +
            "}" + "\n" +
            "return map";
            const string mapFlag = "--Todo";
            public const string ViewUseFlag = "--using";
            public const string ViewFeildFlag = "--Find";
            const string nameFlag = "--Name";
            private class FormatUserCSScript : UnityEditor.AssetModificationProcessor
            {
                public static void OnWillCreateAsset(string metaPath)
                {
                    if (!EditorPrefs.GetBool(key, false)) return;

                    string filePath = metaPath.Replace(".meta", "");
                    if (!filePath.EndsWith(".lua.txt")) return;
                    string realPath = filePath.ToAbsPath();
                    if (!filePath.Contains(hotFixScriptPath))
                    {
                        File.Delete(realPath);
                        return;
                    }
                    string txt = File.ReadAllText(realPath);

                    if (!txt.Contains("#User#")) return;
                    //这里实现自定义的一些规则
                    txt = txt.Replace("#User#", EditorTools.ProjectConfig.UserName)
                             .Replace("#UserSCRIPTNAME#", Path.GetFileNameWithoutExtension(filePath.Replace(".lua", "")))
                             .Replace("#UserNameSpace#", EditorTools.ProjectConfig.NameSpace)
                             .Replace("#UserVERSION#", EditorTools.ProjectConfig.Version)
                             .Replace("#UserDescription#", EditorTools.ProjectConfig.Description)
                             .Replace("#UserUNITYVERSION#", Application.unityVersion)
                             .Replace("#UserDATE#", DateTime.Now.ToString("yyyy-MM-dd")).ToUnixLineEndings();

                    File.WriteAllText(realPath, txt, System.Text.Encoding.UTF8);
                    EditorPrefs.SetBool(key, false);
                    AssetDatabase.Refresh();

                }

                private static string newScriptName = "NewLuaClass.lua.txt";
                private static string originScriptPathWithNameSpace0 = EditorEnv.projectMemoryPath.CombinePath("UserLuaScript0.txt");
                private static string originScriptPathWithNameSpace = EditorEnv.projectMemoryPath.CombinePath("UserLuaScript.txt");
                [MenuItem("Assets/IFramework/Create/FormatLuaBehaviourClass")]
                private static void Create0()
                {
                    CreateOriginIfNull0();
                    CopyAsset.Copy(newScriptName, originScriptPathWithNameSpace0);
                    EditorPrefs.SetBool(key, true);
                }

                [MenuItem("Assets/IFramework/Create/FormatLuaClass")]
                private static void Create()
                {
                    CreateOriginIfNull();
                    CopyAsset.Copy(newScriptName, originScriptPathWithNameSpace);
                    EditorPrefs.SetBool(key, true);
                }
                [MenuItem("Assets/IFramework/Create/FormatLuaClass", true)]
                [MenuItem("Assets/IFramework/Create/FormatLuaBehaviourClass", true)]
                private static bool ValidateCreate()
                {
                    if (Selection.activeObject)
                    {
                        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
                        if (!path.Contains(hotFixScriptPath))
                        {
                            return false;
                        }
                        return true;
                    }
                    return false;
                }
                private static void CreateOriginIfNull()
                {
                    if (File.Exists(originScriptPathWithNameSpace)) return;
                    using (FileStream fs = new FileStream(originScriptPathWithNameSpace, FileMode.Create, FileAccess.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            fs.Lock(0, fs.Length);
                            sw.WriteLine("--*********************************************************************************");
                            sw.WriteLine("--Author:         #User#");
                            sw.WriteLine("--Version:        #UserVERSION#");
                            sw.WriteLine("--UnityVersion:   #UserUNITYVERSION#");
                            sw.WriteLine("--Date:           #UserDATE#");
                            sw.WriteLine("--Description:    #UserDescription#");
                            sw.WriteLine("--History:        #UserDATE#--");
                            sw.WriteLine("--*********************************************************************************");
                            sw.WriteLine("local #UserSCRIPTNAME# = class(\"#UserSCRIPTNAME#\")");
                            sw.WriteLine("");
                            sw.WriteLine("function #UserSCRIPTNAME#:ctor(...)");
                            sw.WriteLine("end");
                            sw.WriteLine("");
                            sw.WriteLine("return #UserSCRIPTNAME#");
                            fs.Unlock(0, fs.Length);
                            sw.Flush();
                            fs.Flush();
                        }
                    }
                    AssetDatabase.Refresh();
                }
                private static void CreateOriginIfNull0()
                {
                    if (File.Exists(originScriptPathWithNameSpace0)) return;
                    using (FileStream fs = new FileStream(originScriptPathWithNameSpace0, FileMode.Create, FileAccess.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(fs))
                        {

                            fs.Lock(0, fs.Length);
                            sw.WriteLine("--*********************************************************************************");
                            sw.WriteLine("--Author:         #User#");
                            sw.WriteLine("--Version:        #UserVERSION#");
                            sw.WriteLine("--UnityVersion:   #UserUNITYVERSION#");
                            sw.WriteLine("--Date:           #UserDATE#");
                            sw.WriteLine("--Description:    #UserDescription#");
                            sw.WriteLine("--History:        #UserDATE#--");
                            sw.WriteLine("--*********************************************************************************");
                            sw.WriteLine("local #UserSCRIPTNAME# = class(\"#UserSCRIPTNAME#\")");
                            sw.WriteLine("");
                            sw.WriteLine("function #UserSCRIPTNAME#:ctor(target,fields)");
                            sw.WriteLine("\ttarget.self = self");
                            sw.WriteLine("\tself.target = target");
                            sw.WriteLine("\tself.fields = fields");
                            sw.WriteLine("end");
                            sw.WriteLine("");
                            sw.WriteLine("function #UserSCRIPTNAME#:OnInitialize()");
                            sw.WriteLine("end");
                            sw.WriteLine("");
                            sw.WriteLine("function #UserSCRIPTNAME#:Awake()");
                            sw.WriteLine("end");
                            sw.WriteLine("");
                            sw.WriteLine("function #UserSCRIPTNAME#:OnEnable()");
                            sw.WriteLine("end");
                            sw.WriteLine("");
                            sw.WriteLine("function #UserSCRIPTNAME#:Start()");
                            sw.WriteLine("end");
                            sw.WriteLine("");
                            sw.WriteLine("function #UserSCRIPTNAME#:Update()");
                            sw.WriteLine("end");
                            sw.WriteLine("");
                            sw.WriteLine("function #UserSCRIPTNAME#:OnDisable()");
                            sw.WriteLine("end");
                            sw.WriteLine("");
                            sw.WriteLine("function #UserSCRIPTNAME#:OnDestroy()");
                            sw.WriteLine("end");
                            sw.WriteLine("");
                            sw.WriteLine("return #UserSCRIPTNAME#");
                            fs.Unlock(0, fs.Length);
                            sw.Flush();
                            fs.Flush();
                        }
                    }
                    AssetDatabase.Refresh();
                }

            }

        }
    }


}

