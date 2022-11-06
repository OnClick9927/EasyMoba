using LockStep.LCollision2D;
using LockStep.Math;

namespace EasyMoba.GameLogic
{
    public class MobaLogicWord : LogicWorld
    {
        public MobaLogicWord(CollisionLayerConfig layer) : base(layer, new LFloat(MobaGame.udpGap))
        {
        }


    }
}

