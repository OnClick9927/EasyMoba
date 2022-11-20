using LockStep.LCollision2D;
using LockStep.Math;
using System.Collections.Generic;

namespace EasyMoba.GameLogic
{


    public class BattleLogic
    {
        private IBattleView view;
        private MobaLogicWord word;

        public BattleLogic(IBattleView view, MobaLogicWord word)
        {
            this.view = view;
            this.word = word;
        }

        public void LoadBaseUnit(MapInitData map_data, List<BattlePlayer> players)
        {
            var data = map_data;

            foreach (var item in data.cs)
            {
                var unit = word.CreateUnit<WallUnit>("WallUnit");
                unit.position = item.position;
                unit.scale = item.scale;
                unit.angle = item.angle;
                unit.CreateCollision(item.shape);
            }
            foreach (var item in data.ps)
            {
                var unit = word.CreateUnit<WallUnit>("WallUnit");
                unit.position = item.position;
                unit.scale = item.scale;
                unit.angle = item.angle;
                unit.CreateCollision(item.shape);
            }
            var bs = data.bornPos;
            for (int i = 0; i < players.Count; i++)
            {
                long id = players[i].role_id;
                var unit = word.CreateUnit<PlayerUnit>($"PlayerUnit {id}");
                unit.role_id = id;
                unit.position = bs[i];
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
        public void StartPlayLogic()
        {

        }
    }
}

