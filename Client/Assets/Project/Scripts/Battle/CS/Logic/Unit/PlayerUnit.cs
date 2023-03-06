using LockStep.LCollision2D;
using LockStep.Math;
using System.Diagnostics;

namespace EasyMoba.GameLogic
{
    public class PlayerUnit : MobaUnit
    {
        public long role_id;

        public override MobaUnitType type => MobaUnitType.Player;

        public LFloat MaxEnergy { get { return this.GetAttribute<LFloat>(BattleAttributeType.MaxEnergy); } set { this.SetAttribute(BattleAttributeType.MaxEnergy, value); } }
        public LFloat MaxRotateAngle { get { return this.GetAttribute<LFloat>(BattleAttributeType.MaxRotateAngle); } set { this.SetAttribute(BattleAttributeType.MaxRotateAngle, value); } }
        public LFloat AddSpeedPerTrick { get { return this.GetAttribute<LFloat>(BattleAttributeType.AddSpeedPerTrick); } set { this.SetAttribute(BattleAttributeType.AddSpeedPerTrick, value); } }

        public LFloat RotateAngle { get { return this.GetAttribute<LFloat>(BattleAttributeType.RotateAngle); } set { this.SetAttribute(BattleAttributeType.RotateAngle, value); } }
        public LFloat Energy { get { return this.GetAttribute<LFloat>(BattleAttributeType.Energy); } set { this.SetAttribute(BattleAttributeType.Energy, value); } }
        public LFloat Speed { get { return this.GetAttribute<LFloat>(BattleAttributeType.Speed); } set { this.SetAttribute(BattleAttributeType.Speed, value); } }
        public LFloat Damage { get { return this.GetAttribute<LFloat>(BattleAttributeType.Damage); } set { this.SetAttribute(BattleAttributeType.Damage, value); } }
        public LFloat Size { get { return this.GetAttribute<LFloat>(BattleAttributeType.Size); } set { this.SetAttribute(BattleAttributeType.Size, value); } }
        private LVector2 last_position;
        public override void OnMobaCreate()
        {
            this.MaxEnergy = new LFloat(10);
            this.MaxRotateAngle = new LFloat(10);
            this.AddSpeedPerTrick = new LFloat(0.001f);

            this.RotateAngle = LFloat.zero;
            this.Speed = LFloat.zero;
            this.Energy = this.MaxEnergy;
            this.Damage = this.Speed;
            this.Size = LFloat.one;
        }

        public override void OnDestory()
        {

        }

        protected override void OnFixedUpdate(int trick, LFloat delta)
        {
            this.last_position = this.position;
            this.Speed = this.Speed + delta * this.AddSpeedPerTrick;

            this.position += this.forward * this.Speed;

            //var data = GetFrame(trick, role_id);
            //if (data != null)
            //{
            //    this.RotateAngle+=
            //    LVector2 stick = new LVector2(data.stick_x, data.stick_y);
            //    this.position += stick;
            //}
        }

        protected override void OnTriggerEnter(Shape other)
        {
            if (other.unit is WallUnit)
            {
                var dir = CollisionHelper.PositionCorrection(this.last_position, this.collision.shape, other);
                this.position += dir * 10;
                this.Speed = LFloat.zero;
                //this.collision.SyncData(this);
            }
        }

        protected override void OnTriggerExit(Shape other)
        {

        }

        protected override void OnTriggerStay(Shape other)
        {

        }
    }
}

