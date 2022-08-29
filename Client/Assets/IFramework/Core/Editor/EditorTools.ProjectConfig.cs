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
using System.Collections.Generic;
using System;
using System.Reflection;
using System.IO;
using UnityEditorInternal;
using System.Text;
using UnityEditor.Callbacks;
using System.Text.RegularExpressions;

namespace IFramework
{

    public static partial class EditorTools
    {
        [OnEnvironmentInit]
        public static class ProjectConfig
        {
            //用正则来匹配对应的文件名和行号
            static Regex reg = new Regex("at[\u4e00-\u9fa5 \f\r\t\na-zA-Z0-9\\.\\-/]*:[0-9]+");
            private static string GetStackTrace()
            {
                var window = EditorWindowTool.Find("UnityEditor.ConsoleWindow");
                if (window == null || window != EditorWindow.focusedWindow) return null;
                var consoleWindowType = window.GetType();
                var activeTextFieldInfo = consoleWindowType.GetField("m_ActiveText", BindingFlags.Instance | BindingFlags.NonPublic);
                return (string)activeTextFieldInfo.GetValue(window);
            }
            private static bool Contains(string source)
            {
                for (var i = 0; i < Info.logIgnoreFiles.Count; i++)
                {
                    if (source.Contains(Info.logIgnoreFiles[i]))
                    {
                        return true;
                    }
                }
                return false;
            }
            [OnOpenAsset(0)]
            static bool ReposLog(int instanceID, int line)
            {
                var trackInfo = GetStackTrace();
                if (string.IsNullOrEmpty(trackInfo) || !Contains(trackInfo)) return false;
                MatchCollection collection = reg.Matches(trackInfo);
                foreach (Match item in collection)
                {
                    string value = item.Value;
                    value = value.Substring(3);
                    string[] values = value.Split(':');
                    string path = values[0];
                    string _line = values[1];
                    if (!Contains(path))
                    {
                        InternalEditorUtility.OpenFileAtLineExternal(path, int.Parse(_line));
                        return true;
                    }
                }
                return false;
            }
            public static string NameSpace { get { return Info.NameSpace; } }
            public static string UserName { get { return Info.UserName; } }
            public static string Version { get { return Info.Version; } }
            public static string Description { get { return Info.Description; } }
            public static bool enable { get { return Info.enable; } }
            public static bool enable_L { get { return Info.enable_L; } }
            public static bool enable_W { get { return Info.enable_W; } }
            public static bool enable_E { get { return Info.enable_E; } }
            public static bool dockWindow { get { return Info.dockWindow; } }

            public const string configName = "ProjectConfig";
            [Serializable]
            public class ProjectConfigInfo
            {
                public bool enable = true;
                public bool enable_L = true;
                public bool enable_W = true;
                public bool enable_E = true;
                public bool dockWindow = true;
                public string Description;
                public List<string> logIgnoreFiles = new List<string>();

                public string Version { get { return PlayerSettings.bundleVersion; } set { PlayerSettings.bundleVersion = value; } }
                public string NameSpace { get { return PlayerSettings.productName; } set { PlayerSettings.productName = value; } }
                public string UserName { get; private set; }
                public ProjectConfigInfo()
                {
                    Description = "Description";
                }

                private static string path { get { return EditorEnv.projectMemoryPath.CombinePath("ProjectConfig.json"); } }
                public static ProjectConfigInfo Load()
                {
                    if (!File.Exists(path))
                    {
                        File.WriteAllText(path, JsonUtility.ToJson(new ProjectConfigInfo()));
                    }

                    var __info = JsonUtility.FromJson<ProjectConfigInfo>(File.ReadAllText(path));
                    var type = typeof(UnityEditor.Connect.UnityOAuth).Assembly.GetType("UnityEditor.Connect.UnityConnect");
                    var m = type.GetMethod("GetUserInfo");
                    var instance = type.GetProperty("instance");
                    var userInfo = m.Invoke(instance.GetValue(null), null);
                    var _type = userInfo.GetType();
                    var p = _type.GetProperty("displayName");
                    __info.UserName = (string)p.GetValue(userInfo);
                    if (!__info.logIgnoreFiles.Contains(default_path))
                    {
                        __info.logIgnoreFiles.Add(default_path);
                    }
                    __info.Save();
                    return __info;
                }
                public void Save()
                {
                    File.WriteAllText(path, JsonUtility.ToJson(this, true));
                }
            }

            private static string default_path { get { return UnityLogger.GetLogFilePath(); } }
            private static ProjectConfigInfo __info;
            public static ProjectConfigInfo Info
            {
                get
                {
                    if (__info == null)
                    {
                        __info = ProjectConfigInfo.Load();
                    }
                    return __info;
                }
            }
            public static void Save()
            {
                __info.Save();
            }



            static ProjectConfig()
            {
                Log.loger = new UnityLogger();
                Log.enable_L = ProjectConfig.enable_L;
                Log.enable_W = ProjectConfig.enable_W;
                Log.enable_E = ProjectConfig.enable_E;
                Log.enable = ProjectConfig.enable;
            }

            class FormatProjectScript
            {
                const string key = "FormatUserScript";

                private class FormatUserScriptProcessor : UnityEditor.AssetModificationProcessor
                {
                    public static void OnWillCreateAsset(string metaPath)
                    {
                        if (!EditorPrefs.GetBool(key, false)) return;

                        string filePath = metaPath.Replace(".meta", "");
                        if (!filePath.EndsWith(".cs")) return;
                        string realPath = filePath.ToAbsPath();
                        string txt = File.ReadAllText(realPath);

                        if (!txt.Contains("#User#")) return;
                        //这里实现自定义的一些规则
                        txt = txt.Replace("#User#", ProjectConfig.UserName)
                                 .Replace("#UserSCRIPTNAME#", Path.GetFileNameWithoutExtension(filePath))
                                 .Replace("#UserNameSpace#", ProjectConfig.NameSpace)
                                 .Replace("#UserVERSION#", ProjectConfig.Version)
                                .Replace("#UserDescription#", ProjectConfig.Description)

                                 .Replace("#UserUNITYVERSION#", Application.unityVersion)
                                 .Replace("#UserDATE#", DateTime.Now.ToString("yyyy-MM-dd")).ToUnixLineEndings();

                        File.WriteAllText(realPath, txt, Encoding.UTF8);
                        EditorPrefs.SetBool(key, false);
                        AssetDatabase.Refresh();
                    }
                }
                private class FormatUserCSScript
                {

                    private static string newScriptName = "newScript.cs";
                    private static string originScriptPathWithNameSpace = EditorEnv.projectMemoryPath.CombinePath("UserCSharpScript.txt");

                    [MenuItem("Assets/IFramework/Create/FormatCSharpScript", priority = -1000)]
                    public static void Create()
                    {
                        CreateOriginIfNull();
                        CopyAsset.Copy(newScriptName, originScriptPathWithNameSpace);
                        EditorPrefs.SetBool(key, true);
                    }
                    private static void CreateOriginIfNull()
                    {
                        if (File.Exists(originScriptPathWithNameSpace)) return;
                        using (FileStream fs = new FileStream(originScriptPathWithNameSpace, FileMode.Create, FileAccess.Write))
                        {
                            using (StreamWriter sw = new StreamWriter(fs))
                            {
                                fs.Lock(0, fs.Length);
                                sw.WriteLine("/*********************************************************************************");
                                sw.WriteLine(" *Author:         #User#");
                                sw.WriteLine(" *Version:        #UserVERSION#");
                                sw.WriteLine(" *UnityVersion:   #UserUNITYVERSION#");
                                sw.WriteLine(" *Date:           #UserDATE#");
                                sw.WriteLine(" *Description:    #UserDescription#");
                                sw.WriteLine(" *History:        #UserDATE#--");
                                sw.WriteLine("*********************************************************************************/");
                                sw.WriteLine("using System;");
                                sw.WriteLine("using System.Collections;");
                                sw.WriteLine("using System.Collections.Generic;");
                                sw.WriteLine("using IFramework;");

                                sw.WriteLine("");
                                sw.WriteLine("namespace #UserNameSpace#");
                                sw.WriteLine("{");
                                sw.WriteLine("\tpublic class #UserSCRIPTNAME#");
                                sw.WriteLine("\t{");
                                sw.WriteLine("\t");
                                sw.WriteLine("\t}");
                                sw.WriteLine("}");
                                fs.Unlock(0, fs.Length);
                                sw.Flush();
                                fs.Flush();
                            }
                        }
                        AssetDatabase.Refresh();
                    }
                }
                private class FormatUserMonoScript
                {
                    private static string newScriptName = "newScript.cs";
                    private static string originScriptPathWithNameSpace = EditorEnv.projectMemoryPath.CombinePath("UserMonoScript.txt");

                    [MenuItem("Assets/IFramework/Create/FormatMonoScript", priority = -1000)]
                    public static void Create()
                    {
                        CreateOriginIfNull();
                        CopyAsset.Copy(newScriptName, originScriptPathWithNameSpace);
                        EditorPrefs.SetBool(key, true);
                    }

                    private static void CreateOriginIfNull()
                    {
                        if (File.Exists(originScriptPathWithNameSpace)) return;
                        using (FileStream fs = new FileStream(originScriptPathWithNameSpace, FileMode.Create, FileAccess.Write))
                        {
                            using (StreamWriter sw = new StreamWriter(fs))
                            {
                                fs.Lock(0, fs.Length);
                                sw.WriteLine("/*********************************************************************************");
                                sw.WriteLine(" *Author:         #User#");
                                sw.WriteLine(" *Version:        #UserVERSION#");
                                sw.WriteLine(" *UnityVersion:   #UserUNITYVERSION#");
                                sw.WriteLine(" *Date:           #UserDATE#");
                                sw.WriteLine(" *Description:    #UserDescription#");
                                sw.WriteLine(" *History:        #UserDATE#--");
                                sw.WriteLine("*********************************************************************************/");
                                sw.WriteLine("using System;");
                                sw.WriteLine("using System.Collections;");
                                sw.WriteLine("using System.Collections.Generic;");
                                sw.WriteLine("using UnityEngine;");
                                sw.WriteLine("using IFramework;");

                                sw.WriteLine("");
                                sw.WriteLine("namespace #UserNameSpace#");
                                sw.WriteLine("{");
                                sw.WriteLine("\tpublic class #UserSCRIPTNAME# : MonoBehaviour");
                                sw.WriteLine("\t{");
                                sw.WriteLine("\t");
                                sw.WriteLine("\t}");
                                sw.WriteLine("}");
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
}
