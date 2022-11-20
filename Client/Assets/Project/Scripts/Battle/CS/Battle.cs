using LockStep.LCollision2D;
using LockStep.Math;
using System.Collections.Generic;

namespace EasyMoba.GameLogic
{

    public class Battle
    {
        public IBattleView view;
        private CollisionLayerConfig collision;
        private BattleLogic logic;
        public FrameCollection frames;
        public MobaLogicWord word;
        public BattleFactory factory;
        public BattleAttributeCollection attributes;
        public AttributeCalc calc;
        public BuffCollection buff;
        public Random random;


        private long role_id;
        private string room_id;
        private MatchRoomType room_type;
        private List<BattlePlayer> players;

        public int GetCurFrame()
        {
            return frames.curFrame;
        }
        public Battle(IBattleView monoBattle, CollisionLayerConfig collision)
        {
            this.view = monoBattle;
            this.collision = collision;
        }

        public long Role_id { get => role_id; }
        public string Room_id { get => room_id; }
        public void SetMapData(MapInitData map_data)
        {
            logic.LoadBaseUnit(map_data, players);

        }

        public void StartGame(long role_id, string room_id, MatchRoomType type, List<BattlePlayer> players)
        {
            long u = 0;
            foreach (var item in players)
            {
                u += item.role_id;
            }
            random = new Random((uint)(u >> 10));
            this.role_id = role_id;
            this.room_id = room_id;
            this.room_type = type;
            this.players = players;
            word = new MobaLogicWord(collision, this);
            frames = new FrameCollection(this);
            logic = new BattleLogic(this);
            factory = new BattleFactory(this);
            attributes = new BattleAttributeCollection();
            calc = new AttributeCalc(this);
            buff = new BuffCollection(this);
        }

        public void CloseGame()
        {
            frames = null;
            logic = null;
        }

        public void ReadFrame(SPBattleFrame obj) => frames.OnBattleFrame(obj);
        public void StartPlayLogic(SPBattleAllReady obj) => logic.StartPlayLogic();

        public void FixedUpdate(int curFrame)
        {
            buff.FixedUpdate(curFrame);
            word.FixedUpdate(curFrame);
        }
    }
}

