using System;

namespace EasyMoba.GameLogic
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class SkillEffectAttribute : Attribute
    {
        public int effect_id;
        public SkillEffectAttribute(int effect_id)
        {
            this.effect_id = effect_id;
        }
    }
}

