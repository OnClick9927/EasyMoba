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
using UnityEditorInternal;

namespace IFramework
{
    partial class EditorTools
    {
        public class ScriptCreaterFieldsDrawer
        {
            private ReorderableList list;
            private ScriptCreater _creater;

            public ScriptCreaterFieldsDrawer(ScriptCreater creater)
            {
                this._creater = creater;
                list = new ReorderableList(_creater.GetMarks(), typeof(ScriptMark));
                list.drawElementCallback = EleCall;
                list.drawHeaderCallback = (rect) => { GUI.Label(rect, "Fields(Type:ScriptMark)"); };
                list.onRemoveCallback += (list) => { _creater.RemoveMark(list.index); };
                list.elementHeightCallback = (index) => { return _creater.GetMark(index) == null ? 20 : 40; };
            }
            private void EleCall(Rect rect, int index, bool isActive, bool isFocused)
            {
                if (index >= _creater.count) return;
                rect = rect.Zoom(AnchorType.MiddleCenter, -4);
                var rs0 = rect.VerticalSplit(140, 10);
                var mark = _creater.GetMark(index);
                _creater.SetMark(index, EditorGUI.ObjectField(rs0[0], mark, typeof(ScriptMark), true) as ScriptMark);
                var rs1 = rs0[1].HorizontalSplit(18, 1);
                mark = _creater.GetMark(index);

                if (mark != null)
                {
                    _creater.CollectMarkComponents(mark);


                    mark.index = EditorGUI.Popup(rs1[0], "Type", mark.index, mark.componentNames.ToArray());
                    mark.fieldName = EditorGUI.TextField(rs1[1], "Name", mark.fieldName);



                    mark.fieldType = mark.componentNames[mark.index];
                    _creater.ValidateMarkFieldName(mark);
                }

            }
            private Vector2 _scroll;
            public void OnGUI()
            {
                _scroll = GUILayout.BeginScrollView(_scroll);
                list.DoLayoutList();
                GUILayout.EndScrollView();
            }
        }



    }
}
