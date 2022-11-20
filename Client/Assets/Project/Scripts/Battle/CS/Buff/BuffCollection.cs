using System.Collections.Generic;

namespace EasyMoba.GameLogic
{
    public class BuffCollection
    {
        public Battle battle;
        private List<Buff> bufs = new List<Buff>();

        public void AddBuff(BuffData data, MobaUnit target)
        {
            Buff buff = Buff.Create(data);
            buff.battle = battle;
            buff.target = target;
            bufs.Add(buff);
            buff.OnAdd();
        }
        public BuffCollection(Battle battle)
        {
            this.battle = battle;
        }
        public void FixedUpdate(int curFrame)
        {
            bufs.RemoveAll(x => x.need_remove);
            for (int i = 0; i < bufs.Count; i++)
                bufs[i].FixedUpdate(curFrame);
        }
    }
}

