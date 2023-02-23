/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.204
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-09
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using UnityEditor;
using UnityEngine;

namespace IFramework.Hotfix.Asset
{
    partial class AssetsWindow
    {
        [System.Serializable]
        private class WindowLeft
        {
            public enum ShowType
            {
                HelperOption, BuildOption,
            }
            public ShowType type = ShowType.HelperOption;
            private Editor buildSetting_editor;
            private Editor toolSetting_editor;
            public void OnEnable()
            {
                buildSetting_editor = Editor.CreateEditor(buildSetting);
                toolSetting_editor = Editor.CreateEditor(toolSetting);
            }
            Vector2 scroll;
            public void OnGUI(Rect rect)
            {
                var rs = rect.Zoom(AnchorType.MiddleCenter, -10).HorizontalSplit(20);


                type = (ShowType)GUI.Toolbar(rs[0], (int)type, System.Enum.GetNames(typeof(ShowType)));

                GUILayout.BeginArea(rs[1]);
                scroll = GUILayout.BeginScrollView(scroll);
                if (type == ShowType.BuildOption)
                {
                    buildSetting_editor.OnInspectorGUI();
                }
                else
                {
                    toolSetting_editor.OnInspectorGUI();
                }
                GUILayout.EndScrollView();
                GUILayout.EndArea();
            }

             
        }
    }
}
