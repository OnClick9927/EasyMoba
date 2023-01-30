/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.11f1
 *Date:           2020-01-13
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

namespace IFramework.Hotfix.Lua
{
    class LuaEditorPaths
    {
        public static string lua_ui_path { get { return hotFixScriptPath.CombinePath("UI"); } }
        public static string lua_panel_names_path  { get { return lua_ui_path.CombinePath("PanelNames.lua.txt"); } }

        public static string hotFixScriptPath { get { return EditorEnvPath.projectPath.CombinePath("Lua"); } }

    }
}

