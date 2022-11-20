using System.Collections.Generic;

namespace EasyMoba.GameLogic
{
    public class AttributeCalc
    {
        private Battle battle;

        public AttributeCalc(Battle battle)
        {
            this.battle = battle;
        }

        private BattleAttributeCollection attribute { get { return battle.attributes; } }
    }
    public class BattleAttributeCollection
    {
        public Dictionary<string, Dictionary<BattleAttributeType, IBattleAttribute>> map = new Dictionary<string, Dictionary<BattleAttributeType, IBattleAttribute>>();
        public void SetAttribute<T>(string guid, BattleAttributeType type,T value)
        {
            if (!map.ContainsKey(guid))
            {
                map.Add(guid, new Dictionary<BattleAttributeType, IBattleAttribute>());
            }
            if (!map[guid].ContainsKey(type))
            {
                map[guid].Add(type, new BattleAttribute<T>()
                {
                    value = value
                });
            }
            else
            {
                BattleAttribute<T> attr = map[guid][type] as BattleAttribute<T>;
                attr.value = value;
            }
        }
        public T GetAttribute<T>(string guid, BattleAttributeType type)
        {
            IBattleAttribute t = GetAttribute(guid, type);
            if (t==null)
            {
                return default;
            }
            return (t as BattleAttribute<T>).value;
        }
        public IBattleAttribute GetAttribute(string guid, BattleAttributeType type)
        {
            if (!map.ContainsKey(guid))
                return null;
            if (!map[guid].ContainsKey(type))
                return null;
            return map[guid][type];
        }

    }
}

