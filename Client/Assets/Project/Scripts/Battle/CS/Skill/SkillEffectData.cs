using System.Collections.Generic;

namespace EasyMoba.GameLogic
{

    [System.Serializable]
    public class SkillEffectData
    {
        public int effectID;
        public int delay;

        public int loop;
    }

    [System.Serializable]
    [SkillEffect(1)]
    public class TestSkillEffectData : SkillEffectData
    {
        public int test;
    }
    [System.Serializable]
    [SkillEffect(2)]
    public class BuffEffectData : SkillEffectData
    {
        public List<BuffData> buffs = new List<BuffData>();
    }
}

