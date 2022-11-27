using System.Collections.Generic;

namespace EasyMoba.GameLogic
{
    [System.Serializable]
    public class SkillData
    {
        public int skillID;
        public string name;
        public string des;
        public string icon;




        public int CD;
        public List<int> effects = new List<int>();
    }
}

