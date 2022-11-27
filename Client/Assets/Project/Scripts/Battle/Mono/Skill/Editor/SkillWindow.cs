using UnityEditor;
using IFramework;
using IFramework.GUITool;
using IFramework.GUITool.ToorbarMenu;
using UnityEngine;
using UnityEditorInternal;
using System.Linq;
using System.IO;

namespace EasyMoba.GameLogic.Mono
{
    [EditorWindowCache("SkillWindow")]
    public class SkillWindow : EditorWindow
    {
        static void BuildStoScript()
        {
            string path = "Assets/Project/Scripts/Battle/Mono/Skill/Editor/Effects";
            string left = "{";
            string right = "}";
            if (Directory.Exists(path))
            {
                AssetDatabase.DeleteAsset(path);
            }
            AssetDatabase.CreateFolder("Assets/Project/Scripts/Battle/Mono/Skill/Editor", "Effects");
            var skill_effectTypes = typeof(SkillEffectData).GetSubTypesInAssemblys().ToList();
            foreach (var type in skill_effectTypes)
            {
                string txt = $"namespace EasyMoba.GameLogic.Mono{left}public class {type.Name}Sto: SkillEffectDataSto<{type.Name}>{left}{right}{right}";
                string _path = $"{path}/{type.Name}Sto.cs";
                System.IO.File.WriteAllText(_path, txt);
            }
            AssetDatabase.Refresh();
        }
        private SkillEditorConfig config;
        private SplitView sp = new SplitView();
        private ToolBarTree toolbar;
        ReorderableList list;
        private void OnEnable()
        {
            config = AssetDatabase.LoadAssetAtPath<SkillEditorConfig>("Assets/Project/Scripts/Battle/Mono/Skill/Editor/New Skill Editor Config.asset");

            list = new ReorderableList(config.skills, typeof(SkillData));
            list.headerHeight = 0;
            list.drawElementCallback += DrawEle;
            toolbar = new ToolBarTree();
            list.onAddCallback += Add;
            list.onRemoveCallback += Remove;
            toolbar.DropDownButton(new GUIContent("Tools"), (rect) => {
                GenericMenu menu = new GenericMenu();

                menu.AddItem(new GUIContent("Build EffectStos"), false, BuildStoScript);
                menu.DropDown(rect);
            });
            sp.fistPan += list.DoList;
            sp.secondPan += Sp_secondPan;

        }

        private void Remove(ReorderableList list)
        {
            var index = list.index;
            config.RemoveSkill(config.skills[index]);
        }

        private void Add(ReorderableList list)
        {
            config.AddSkill();
        }

        private void OnGUI()
        {
            var rs = this.LocalPosition().HorizontalSplit(20);
            toolbar.OnGUI(rs[0]);
            sp.OnGUI(rs[1]);
        }
        private void DrawEle(Rect rect, int index, bool isActive, bool isFocused)
        {
            SkillDataSto skill = config.skills[index];
            GUI.Label(rect, skill.skillName + "  " + skill.skillID.ToString());
        }


        private void Sp_secondPan(UnityEngine.Rect obj)
        {
            if (list.index == -1) return;
            SkillDataSto data = config.skills[list.index];
            GUILayout.BeginArea(obj);
            var editor = Editor.CreateEditor(data);
            editor.OnInspectorGUI();
            GUILayout.BeginHorizontal();
            GUILayout.Label("effects", GUIStyles.toolbarPopup);
            if (GUILayout.Button("+",GUILayout.Width(20)))
            {
                GenericMenu menu = new GenericMenu();

                foreach (var item in SkillEditorConfig.skill_effectTypes)
                {
                    menu.AddItem(new GUIContent("Add Effect/"+item.Name), false, () => { config.AddSkillEffect(data, item); });
                }
                menu.ShowAsContext();
            }
            GUILayout.EndHorizontal();
        

            for (int i = 0; i < data.effects.Count; i++)
            {
                var effect = data.effects[i];
                var _editor = Editor.CreateEditor(effect);
                GUILayout.BeginHorizontal();
                _editor.OnInspectorGUI();
                if (GUILayout.Button("-", GUILayout.Width(20),GUILayout.ExpandHeight(false)))
                {
                    config.RemoveSkillEffect(data, effect);
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndArea();
        }



    }
}

