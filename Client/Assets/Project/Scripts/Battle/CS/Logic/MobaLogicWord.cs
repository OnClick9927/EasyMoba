using LockStep.LCollision2D;
using LockStep.Math;

namespace EasyMoba.GameLogic
{
    public class MobaLogicWord : LogicWorld
    {
        public FrameCollection frames;

        public MobaLogicWord(CollisionLayerConfig layer) : base(layer, new LFloat(MobaGame.udpGap))
        {
        }
        public new T CreateUnit<T>(string name) where T : MobaUnit, new()
        {
            T t = base.CreateUnit<T>(name);
            t.frames = frames;
            return t;
        }

    }
}

