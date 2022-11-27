using System;
using System.Collections.Generic;

namespace EasyMoba.GameLogic
{
    public class SkillDirector
    {
        private readonly SkillConfig config;

        private List<SkillEffectExecutor> executors = new List<SkillEffectExecutor>();

        public SkillDirector(SkillConfig config)
        {
            this.config = config;
        }
        public void FixUpdate(int curFrame)
        {
            executors.RemoveAll(x => x.need_remove);
            for (int i = 0; i < executors.Count; i++)
            {
                var item = executors[i];
                item.FixUpdate(curFrame);
            }
        }
        public void PlaySkill(SkillData skill, MobaUnit unit)
        {
            for (int i = 0; i < skill.effects.Count; i++)
            {
                SkillEffectData effect = config.effets.Find(x => x.effectID == skill.effects[i]);
                SkillEffectExecutor player = SkillEffectGen.GetExecutor(effect, unit);
                executors.Add(player);
            }
        }
    }
}

