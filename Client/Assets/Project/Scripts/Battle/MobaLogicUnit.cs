using LockStep.LCollision2D;
using LockStep.Math;
using System;
using XLua;

namespace EasyMoba
{
    public class MobaLogicWord : LogicWorld
    {
        Action<MobaLogicUnit, int, LFloat> call_1;
        Action<MobaLogicUnit, Shape> call_2;
        Action<MobaLogicUnit, Shape> call_3;
        Action<MobaLogicUnit, Shape> call_4;
        Action<MobaLogicUnit> call_5;


        public MobaLogicWord(CollisionLayerConfig layer) : base(layer, new LFloat(MobaGame.udpGap))
        {
            var lua = MobaGame.Instance.modules.Lua;
            var tab0 = lua.gtable.Get<LuaTable>("Battle");
            var for_cs = tab0.Get<LuaTable>("for_cs_call");

            call_1 = for_cs.Get<Action<MobaLogicUnit, int, LFloat>>("OnUnitFixedUpdate");
            call_2 = for_cs.Get<Action<MobaLogicUnit, Shape>>("OnUnitTriggerEnter");
            call_3 = for_cs.Get<Action<MobaLogicUnit, Shape>>("OnUnitTriggerStay");
            call_4 = for_cs.Get<Action<MobaLogicUnit, Shape>>("OnUnitTriggerExit");
            call_5 = for_cs.Get<Action<MobaLogicUnit>>("OnUnitDestory");

        }
        public MobaLogicUnit CreateMobaUnit(string name)
        {
            MobaLogicUnit unit = this.CreateUnit<MobaLogicUnit>(name) as MobaLogicUnit;
            unit.call_3 = call_3;
            unit.call_4 = call_4;
            unit.call_5 = call_5;
            unit.call_2 = call_2;
            unit.call_1 = call_1;
            return unit;
        }

    }
    public class MobaLogicUnit : LogicUnit
    {
        public Action<MobaLogicUnit, int, LFloat> call_1;
        public Action<MobaLogicUnit, Shape> call_2;
        public Action<MobaLogicUnit, Shape> call_3;
        public Action<MobaLogicUnit, Shape> call_4;
        public Action<MobaLogicUnit> call_5;
        protected override void OnFixedUpdate(int trick, LFloat delta)
        {
            call_1?.Invoke(this, trick, delta);
        }
        protected override void OnTriggerEnter(Shape other)
        {
            call_2?.Invoke(this, other);

        }
        protected override void OnTriggerStay(Shape other)
        {
            call_3?.Invoke(this, other);

        }
        protected override void OnTriggerExit(Shape other)
        {
            call_4?.Invoke(this, other);

        }
        public override void OnDestory()
        {
            call_5?.Invoke(this);

        }
    }
}

