using System.Collections.Generic;
using UnityEngine;

namespace EasyMoba.GameLogic.Mono
{
    public class SkillDataSto : ScriptableObject
    {
        public int skillID;
        public string skillName;
        public string des;
        public string icon;
        public int CD;
        [HideInInspector]
        public List<SkillEffectDataSto> effects = new List<SkillEffectDataSto>();
    }
}

