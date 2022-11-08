using System.Collections.Generic;

namespace EasyMoba.GameLogic
{
    public class FrameCollection
    {
        public int curFrame = 0;
        private Dictionary<int, SPBattleFrame> frames = new Dictionary<int, SPBattleFrame>();
        private MobaLogicWord word;

        public FrameCollection(MobaLogicWord word)
        {
            this.word = word;
        }
        public SPBattleFrame GetFrame(int frame)
        {
            return frames[frame];
        }
        public FrameData GetFrame(int frame,long role_id)
        {
            return frames[frame].datas.Find(x=>x.roleID==role_id);
        }
        public void OnBattleFrame(SPBattleFrame data)
        {
            var frame = data.frameID;
            if (frame >= curFrame)
            {
                frames[frame] = data;
            }
            while (frames.ContainsKey(curFrame))
            {
                word.FixedUpdate(curFrame);
                curFrame++;
            }
        }
    }
}

