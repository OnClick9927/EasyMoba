using LockStep.LCollision2D;
using System;

namespace EasyMoba.GameLogic
{
    public abstract class MobaUnit : LogicUnit
    {
        public TeamType teamType;
        public readonly string uid = Guid.NewGuid().ToString();

        public abstract MobaUnitType type { get; }
        public Battle battle;
        private BattleAttributeCollection attributes { get { return battle.attributes; } } 
        private FrameCollection frames { get { return battle.frames; } }
        protected T GetAttribute<T>(BattleAttributeType type)
        {
            return attributes.GetAttribute<T>(uid, type);
        }
        protected SPBattleFrame GetFrame(int frame)
        {
            return frames.GetFrame(frame);
        }
        protected FrameData GetFrame(int frame, long role_id)
        {
            return frames.GetFrame(frame, role_id);
        }
    }
}

