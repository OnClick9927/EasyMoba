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
            [SerializeField] private string _scriptName = "newSp.cs";
            [SerializeField] private List<ScriptMark> marks = new List<ScriptMark>();
            [SerializeField] private string _namespace = "";
            [SerializeField] private string _createDirectory = "Assets";
            [SerializeField] private int _searchIndex;
            [SerializeField] private string _type = "";

            public List<string> baseTypes { get; private set; }
            public string type { get { return _type; } }
            public int searchIndex { get { return _searchIndex; } }
            public string Namespace { get { return _namespace; } }
            public string scriptName { get { return _scriptName; } }
            public string createDirectory { get { return _createDirectory; } }
            public int count { get { return this.marks.Count; } }



            public void CollectMarkComponents(ScriptMark mark)
            {
                mark.componentNames.Clear();
                Component[] cps = mark.gameObject.GetComponents<Component>();
                if (cps == null || cps.Length <= 0) return;
                cps.ToList().ForEach((c) =>
                {
                    if (c != null)
                    {
                        var name = c.GetType().FullName;
                        if (!mark.componentNames.Contains(name))
                        {
                            mark.componentNames.Add(c.GetType().FullName);
                        }
                    }
                });
            }
            /// <summary>
            /// 是否是合法字段名称
            /// </summary>
            /// <param name="self"></param>
            /// <returns></returns>
            public static bool IsLegalFieldName(string self)
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


            public void CollectMonoBehaviors()
            {
                var _list = typeof(MonoBehaviour).GetSubTypesInAssemblys().ToList();
                _list.Insert(0, typeof(MonoBehaviour));
                baseTypes = _list.ConvertAll((type) => { return type.FullName; });
            }
            public void CheckSelectMonoBehaviorType()
            {
                if (_type != baseTypes[_searchIndex])
                {
                    bool find = false;
                    for (int i = 0; i < baseTypes.Count; i++)
                    {
                        if (baseTypes[i] == _type)
                        {
                            _searchIndex = i;
                            find = true;
                            break;
                        }
                    }
                    if (!find)
                    {
                        _type = baseTypes[_searchIndex];
                    }
                }

            }

            public void SelectMonoBehaviorType(int index, string type)
            {
                _searchIndex = index;
                this._type = baseTypes[index];
            }

            public void SetNamespace(string ns)
            {
                this._namespace = ns;
                if (string.IsNullOrEmpty(_namespace) || !_namespace.StartsWith(EditorTools.ProjectConfig.NameSpace))
                {
                    _namespace = EditorTools.ProjectConfig.NameSpace;
                }
            }
            public void SetScriptName(string name)
            {
                this._scriptName = name;
                if (!IsLegalFieldName(_scriptName))
                    _scriptName = gameObject.name.Replace(" ", "").Replace("(", "").Replace(")", "");
            }
            public void SetCreateDirectory(string path)
            {
                this._createDirectory = path.ToAssetsPath();
            }


            public void SetGameObject(GameObject gameObject)
            {
                if (gameObject != this.gameObject)
                {
                    this.gameObject = gameObject;
                    marks.Clear();
                    if (this.gameObject != null)
                    {
                        SetScriptName(string.Empty);
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
            public bool FieldCheckWithScriptName(out string err)
            {
                for (int i = 0; i < marks.Count; i++)
                {
                    var mark = marks[i];
                    if (mark.fieldName == _scriptName)
                    {
                        err = "Field Name Should be diferent With ScriptName";
                        return false;
                    }
                }
                err = "";
                return true;
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


            public Component GetComponent(Type type)
            {
                return gameObject.GetComponent(type);
            }


            public List<ScriptMark> GetMarks()
            {
                return this.marks;
            }
            public void DestoryMarks()
            {
                gameObject.GetComponentsInChildren<ScriptMark>(true).ToList().ForEach((sm) =>
                {
                    GameObject.DestroyImmediate(sm);
                });
            }
            public void RemoveMark(int index)
            {
                this.marks.RemoveAt(index);
            }
            public ScriptMark GetMark(int index)
            {
                return this.marks[index];
            }
            public void SetMark(int index, ScriptMark mark)
            {
                this.marks[index] = mark;
            }
        }



    }
}
