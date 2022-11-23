using System;

namespace EasyMoba.GameLogic
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class SkillEffectAttribute : Attribute
    {
        public int type_code;
        public SkillEffectAttribute(int type_code)
        {
            this.type_code = type_code;
        }
    }
}

