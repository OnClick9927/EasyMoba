using IFramework.Hotfix.Asset;
using LockStep.LCollision2D;
using LockStep.Math;
using UnityEngine;
using static Room;

namespace EasyMoba.GameLogic
{
    public enum MobaUnitType
    {
        G,
        Wall,
        Player,
    }
    public class BattleCallLua
    {
        private static GameObject player;
        public static void SetPosition(MobaUnit unit)
        {
            player.transform.position = unit.position.ToVector3XZ();

        }
        public static async void OnUnitCreate(MobaUnit unit)
        {
            var asset = await Assets.LoadAssetAsync("Assets/Project/Prefabs/Battle/Character/char_001.prefab");
            var prefab = asset.GetAsset<GameObject>();
            player = GameObject.Instantiate(prefab);
            player.transform.position = unit.position.ToVector3XZ();
        }
    }

    public abstract class MobaUnit : LogicUnit
    {
        public abstract MobaUnitType type { get; }
        private FrameCollection collection { get { return Battle.Instance.frames; } }
        public SPBattleFrame GetFrame(int frame)
        {
            return collection.GetFrame(frame);
        }
        public FrameData GetFrame(int frame, long role_id)
        {
            return collection.GetFrame(frame, role_id);
        }
    }
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
    public class GUnit : MobaUnit
    {
        public override MobaUnitType type => MobaUnitType.G;

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
                LVector2 stick = data.stick;
                this.position += stick;
                BattleCallLua.SetPosition(this);

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


    public class BattleLogic
    {
        private MobaLogicWord word;

        public BattleLogic(MobaLogicWord word)
        {
            this.word = word;
        }

        public void LoadBaseUnit()
        {
            word.CreateUnit<GUnit>("Gunit");
            MapInitCollection collection = UnityEngine.Object.FindObjectOfType<MapInitCollection>();
            var data = collection.data;
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
            var players = Battle.Instance.players;
            for (int i = 0; i < players.Count; i++)
            {
                long id = players[i];
                var unit = word.CreateUnit<PlayerUnit>($"PlayerUnit {id}");
                unit.role_id = id;
                unit.position = bs[i];
                unit.CreateCollision(new CircleShape() {
                    layer = CollisionLayer._2,


                    radius = new LFloat(0.5f), logic = true, rigidbody = true

                }); ;
                BattleCallLua.OnUnitCreate(unit);
            }
        }
        public void StartPlayLogic()
        {

        }
    }
}

