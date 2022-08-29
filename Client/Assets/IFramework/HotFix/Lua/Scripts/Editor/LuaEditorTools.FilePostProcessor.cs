/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.11f1
 *Date:           2020-01-13
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace IFramework.Hotfix.Lua
{
    static partial class LuaEditorTools
    {
        public class FilePostProcessor : AssetPostprocessor
        {
            private static Queue<string> _changed = new Queue<string>();
            private static Action<string> _reload;
            static string frameworkpath
            {
                get
                {
                    return EditorEnv.frameworkPath.CombinePath("Hotfix/Lua/Resources");
                }
            }
            const string projectpath = "Assets/Project/Lua";

            private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
            {
                if (!EditorApplication.isPlaying || !Application.isPlaying || !XLuaModule.available) return;
                if (_reload == null)
                    _reload = Launcher.modules.GetModule<XLuaModule>().gtable.Get<Action<string>>("UpdateFunctions");

                for (int index = 0; index < importedAssets.Length; index++)
                {
                    var path = importedAssets[index];
                    if (path.EndsWith(".lua.txt"))
                    {
                        if (path.Contains(frameworkpath))
                        {
                            path = path.Replace(frameworkpath, "");
                        }
                        else if (path.Contains(projectpath))
                        {
                            path = path.Replace(projectpath, "");
                        }
                        path = path.Replace(".lua.txt", "").Replace("/", ".").Remove(0, 1);
                        _changed.Enqueue(path);
                    }
                }

                if (_changed.Count > 0)
                {
                    EditorEnv.delayCall += () =>
                    {
                        if (!EditorApplication.isPlaying || !Application.isPlaying || !XLuaModule.available) return;
                        while (_changed.Count > 0)
                        {
                            string str = _changed.Dequeue();
                            if (_reload != null)
                            {
                                _reload(str);
                                Debug.Log($"<color=#00A0A0> 重载 Lua 代码 :{str}</color>");
                            }
                        }
                        _reload = null;
                    };
                }
            }
        }
    }


}

