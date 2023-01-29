/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.11f1
 *Date:           2020-01-13
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using IFramework.GUITool;
using UnityEngine;

namespace IFramework.Hotfix.Lua
{
    static partial class LuaEditorTools
    {
        private class LuaFloderField : FloderField
        {
            public static string hotFixScriptPath => Application.dataPath.CombinePath("Project/Lua").ToAssetsPath();
            protected override bool Fitter(string path)
            {
                return path.Contains(hotFixScriptPath);
            }
        }

    }


}

