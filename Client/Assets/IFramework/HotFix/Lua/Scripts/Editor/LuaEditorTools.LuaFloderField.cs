/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.11f1
 *Date:           2020-01-13
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using IFramework.GUITool;

namespace IFramework.Hotfix.Lua
{
    static partial class LuaEditorTools
    {
        private class LuaFloderField : FloderField
        {
            protected override bool Fitter(string path)
            {
                return path.Contains(MVVM_GenCodeView_Lua.hotFixScriptPath);
            }
        }

    }


}

