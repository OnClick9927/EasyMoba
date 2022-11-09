using LockStep.LCollision2D;
using LockStep.Math;

namespace EasyMoba.GameLogic
{
    public class WallUnit : MobaUnit
    {
        public override MobaUnitType type => MobaUnitType.Wall;

        public override void OnDestory()
        {

        }

        protected override void OnFixedUpdate(int trick, LFloat delta)
        {

        }

        protected override void OnTriggerEnter(Shape other)
        {

        }

        protected override void OnTriggerExit(Shape other)
        {

        }

        protected override void OnTriggerStay(Shape other)
        {

        }
    }
}

