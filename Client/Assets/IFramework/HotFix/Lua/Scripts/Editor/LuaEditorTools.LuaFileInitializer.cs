/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.322
 *UnityVersion:   2018.4.17f1
 *Date:           2020-06-07
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System.Collections.Generic;
using System.IO;

namespace IFramework.Hotfix.Lua
{
    static partial class LuaEditorTools
    {
        class LuaFileInitializer : EditorEnv.FileInitializer
        {
            protected override List<string> directorys
            {
                get
                {
                    return new List<string>()
                    {
                        "Assets/Project/Lua",
                        "Assets/Project/Lua/UI"
                    };
                }
            }

            protected override List<string> files
            {
                get
                {
                    return new List<string>() {
                        "Assets/Project/Lua/FixCsharp.lua.txt",
                        "Assets/Project/Lua/GameLogic.lua.txt",
                        "Assets/Project/Lua/GlobalDefine.lua.txt",
                    };
                }
            }
            protected override bool CreateFile(int index, string path)
            {
                if (!File.Exists(path))
                {
                    if (index == 0)
                    {
                        File.WriteAllText(path, "Log.L('Start Fix C# ')\n");
                    }
                    if (index == 1)
                    {
                        File.WriteAllText(path, "Log.L('Game Logic')\n");
                    }
                    if (index == 2)
                    {
                        File.WriteAllText(path, "Log.L('GlobalDefine')\n");
                    }
                }
                return true;
            }
        }
    }
}
