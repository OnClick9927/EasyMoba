using LockStep.LCollision2D;
using LockStep.Math;
using static EasyMoba.GameLogic.MapInitData;

namespace EasyMoba.GameLogic
{
    public class BattleFactory
    {
        public Battle battle;
        private IBattleView view { get { return battle.view; } }
        private MobaLogicWord word { get { return battle.word; } }
        public BattleFactory(Battle battle)
        {
            this.battle = battle;
        }

        public void CreateWall<T>(UnitShapeData<T> item) where T : Shape
        {
            var unit = word.CreateUnit<WallUnit>("WallUnit");
            unit.position = item.position;
            unit.scale = item.scale;
            unit.angle = item.angle;
            unit.teamType = TeamType.Mid;
            unit.CreateCollision(item.shape);
        }
        public void CreatePlayer(BattlePlayer player, LVector2 pos)
        {
            long id = player.role_id;
            var unit = word.CreateUnit<PlayerUnit>($"PlayerUnit {id}");
            unit.role_id = id;
            unit.position = pos;
            unit.teamType = player.team_type;

            unit.CreateCollision(new CircleShape()
            {
                layer = CollisionLayer._2,
                radius = new LFloat(0.5f),
                logic = true,
                rigidbody = true
            }); ;
            view.OnUnitCreate(unit);

        }

    }
}

