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

