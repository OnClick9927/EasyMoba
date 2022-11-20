using LockStep.LCollision2D;
using LockStep.Math;
using System.Collections.Generic;

namespace EasyMoba.GameLogic
{
    public class Battle
    {
        private IBattleView view;
        private CollisionLayerConfig collision;
        private BattleLogic logic;
        private FrameCollection frames;
        private MobaLogicWord word;


        private long role_id;
        private string room_id;
        private MatchRoomType room_type;
        private List<BattlePlayer> players;

        public Random random;

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
            uint u = 0;
            foreach (var item in players)
            {

            }
            random = new Random();
            this.role_id = role_id;
            this.room_id = room_id;
            this.room_type = type;
            this.players = players;
            word = new MobaLogicWord(collision);
            frames = new FrameCollection(word);
            logic = new BattleLogic(view, word);
            word.frames = frames;
        }

        public void CloseGame()
        {
            frames = null;
            logic = null;
        }

        public void ReadFrame(SPBattleFrame obj) => frames.OnBattleFrame(obj);
        public void StartPlayLogic(SPBattleAllReady obj) => logic.StartPlayLogic();
    }
}

