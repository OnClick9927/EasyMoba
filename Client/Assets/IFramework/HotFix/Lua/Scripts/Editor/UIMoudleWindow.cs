/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.11f1
 *Date:           2020-01-13
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using UnityEditor;
using System.IO;
namespace IFramework.UI
{
    partial class UIMoudleWindow
    {
        const string lua_path = "Assets/Project/Lua/UI/PanelNames.lua.txt";

        public static void Lua_BuildPanelNames()
        {
            Collect();
            string s = "local M = \n" +
                "{\n";
            foreach (var data in collect.datas)
            {
                s = s.Append($"\t {data.name} = \"{data.name}\";\n");
            }
            s = s.Append("}\n" +
                "return M");
            File.WriteAllText(lua_path, s);
            AssetDatabase.Refresh();
        }
    }
}

