using LockStep.LCollision2D;
using System;

namespace EasyMoba.GameLogic
{
    public abstract class MobaUnit : LogicUnit
    {
        public string uid = Guid.NewGuid().ToString();
        public abstract MobaUnitType type { get; }
        public FrameCollection frames;
        public SPBattleFrame GetFrame(int frame)
        {
            return frames.GetFrame(frame);
        }
        public FrameData GetFrame(int frame, long role_id)
        {
            return frames.GetFrame(frame, role_id);
        }
    }
}

