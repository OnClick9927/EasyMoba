using System.Collections.Generic;
using IFramework;
using UnityEngine;
using System;
using System.Linq;
using UnityEditor;
using UnityEngine.Windows;

namespace EasyMoba.GameLogic.Mono
{
    public class SkillEffectDataSto : ScriptableObject
    {

    }
    public class SkillEffectDataSto<T> : SkillEffectDataSto where T : SkillEffectData
    {
        public T effect;
    }
    [CreateAssetMenu]
    public class SkillEditorConfig : ScriptableObject
    {

        public static List<Type> skill_effectTypes;
        static SkillEditorConfig()
        {
            skill_effectTypes = typeof(SkillEffectDataSto).GetSubTypesInAssemblys().ToList();
            skill_effectTypes.RemoveAll(x => x.IsGenericType);
        }
        public List<SkillEffectDataSto> effects = new List<SkillEffectDataSto>();
        public List<SkillDataSto> skills = new List<SkillDataSto>();

        private void Update()
        {
            List<UnityEngine.Object> objs = new List<UnityEngine.Object>();
            objs.AddRange(skills);
            objs.AddRange(effects);
            EditorTools.AssetTool.Update(this, objs.ToArray());

        }
        public void AddSkill()
        {
            var sto = ScriptableObject.CreateInstance<SkillDataSto>();
            sto.name = Guid.NewGuid().ToString();
            skills.Add(sto);
            Update();
        }
        internal void RemoveSkill(SkillDataSto skillDataSto)
        {
            skills.Remove(skillDataSto);
            if (skillDataSto.effects != null)
            {
                foreach (var item in skillDataSto.effects)
                {
                    effects.Remove(item);
                }
            }
            Update();
        }

        public void AddSkillEffect(SkillDataSto skill, Type data)
        {
            var sto = ScriptableObject.CreateInstance(data) as SkillEffectDataSto;
            sto.name = Guid.NewGuid().ToString();

            skill.effects.Add(sto);
            effects.Add(sto);
            Update();
        }

        internal void RemoveSkillEffect(SkillDataSto data, SkillEffectDataSto effect)
        {
            data.effects.Remove(effect);
            effects.Remove(effect);
            Update();
        }
    }
}

