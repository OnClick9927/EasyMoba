using LockStep.LCollision2D;
using LockStep.Math;

namespace EasyMoba.GameLogic
{
    public class PlayerUnit : MobaUnit
    {
        public long role_id;

        public override MobaUnitType type => MobaUnitType.Player;


        public override void OnDestory()
        {

        }

        protected override void OnFixedUpdate(int trick, LFloat delta)
        {
            var data = GetFrame(trick, role_id);
            if (data != null)
            {
                LVector2 stick = new LVector2(data.stick_x, data.stick_y); 
                this.position += stick;
            }
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

