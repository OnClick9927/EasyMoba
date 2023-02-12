using LockStep.LCollision2D;
using LockStep.Math;

namespace EasyMoba.GameLogic
{
    public class MobaLogicWord : LogicWorld
    {
        private Battle battle;
        public FrameCollection frames { get { return battle.frames; } }

        public MobaLogicWord(CollisionLayerConfig layer, Battle battle) : base(layer, new LFloat(Battle.delta))
        {
            this.battle = battle;
        }


        public new T CreateUnit<T>(string name) where T : MobaUnit, new()
        {
            T t = base.CreateUnit<T>(name);
            t.battle = battle;
            t.OnMobaCreate();
            return t;
        }

    }
}

