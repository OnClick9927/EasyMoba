using System.Collections.Generic;

namespace EasyMoba.GameLogic
{
    public class SkillCollection
    {
        public MobaUnit unit;
        private List<SkillData> skills = new List<SkillData>();
        public void LearnSkill(SkillData skill)
        {
            skills.Add(skill);
        }
        public void PlaySkill(int skill_id)
        {
            SkillData data = skills.Find(x => x.skillID == skill_id);
            if (data == null) return;
            unit.battle.skill.PlaySkill(data, this.unit);
        }
    }
}

