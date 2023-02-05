/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.1f1
 *Date:           2019-03-18
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace IFramework
{
    partial class EditorTools
    {
        [System.Serializable]
        public class ScriptCreater
        {
            public GameObject gameObject;
            [SerializeField] private List<ScriptMark> marks = new List<ScriptMark>();

            /// <summary>
            /// 是否是合法字段名称
            /// </summary>
            /// <param name="self"></param>
            /// <returns></returns>
            private static bool IsLegalFieldName(string self)
            {
                if (string.IsNullOrEmpty(self)) return false;
                return Regex.IsMatch(self, @"^[_a-zA-Z][_a-zA-Z0-9]*$");
            }
            public void ValidateMarkFieldName(ScriptMark mark)
            {
                mark.fieldName = string.IsNullOrEmpty(mark.fieldName) ? mark.name : mark.fieldName;
                if (!IsLegalFieldName(mark.fieldName)) mark.fieldName = mark.name;
                mark.fieldName = mark.fieldName.Replace(" ", "").Replace("(", "").Replace(")", "");
            }

            public void SetGameObject(GameObject gameObject)
            {
                if (gameObject != this.gameObject)
                {
                    this.gameObject = gameObject;
                    marks.Clear();
                    if (this.gameObject != null)
                    {
                        ColllectMarks();
                    }
                }
            }
            public void ColllectMarks()
            {
                if (gameObject == null) return;
                var marks = gameObject.GetComponentsInChildren<ScriptMark>(true);
                if (marks == null) return;
                var list = marks.ToList();
                if (this.marks != null) list.AddRange(this.marks);
                list = list.Distinct().ToList();
                list.RemoveAll((o) => { return o == null; });
                this.marks.Clear();
                this.marks.AddRange(list);
            }
            public bool FieldCheck(out string err)
            {
                if (marks == null || marks.Count == 0)
                {
                    ColllectMarks();
                }
                for (int i = 0; i < marks.Count; i++)
                {
                    var mark = marks[i];
                    if (string.IsNullOrEmpty(mark.fieldType))
                    {
                        err = "Please Open the Toggle On Inspector To Edit Fields";
                        return false;
                    }
                    var sameFields = marks.ToList().FindAll((__sm) => { return mark.fieldName == __sm.fieldName; });
                    if (sameFields.Count > 1)
                    {
                        err = "Can't Exist Same Name Field";
                        return false;
                    }

                }
                err = "";
                return true;
            }
            public List<ScriptMark> GetMarks()
            {
                return this.marks;
            }
            public void DestoryMarks()
            {
                gameObject.GetComponentsInChildren<ScriptMark>(true).ToList().ForEach((sm) =>
                {
                    GameObject.DestroyImmediate(sm,true);
                });
            }
 
        }



    }
}
