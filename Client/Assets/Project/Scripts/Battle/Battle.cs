using IFramework.Hotfix.Asset;
using IFramework.Singleton;
using LockStep.LCollision2D;
using System.Collections.Generic;
using UnityEngine;

namespace EasyMoba.GameLogic
{
    public class Battle : MonoSingleton<Battle>
    {
        private BattleInput input;
        public BattleLogic logic;
        public FrameCollection frams;
        public MobaLogicWord word;
        private BattleModePlayer mode_server;
        private long role_id;
        private string room_id;
        private MatchRoomType room_type;
        private List<long> players;

        public long Role_id { get => role_id; set => role_id = value; }
        public string Room_id { get => room_id; set => room_id = value; }

        public void StartGame(BattlePlayMode mode, long role_id, string room_id, MatchRoomType type, List<long> players)
        {
            this.Role_id = role_id;
            this.Room_id = room_id;
            this.room_type = type;
            this.players = players;
            mode_server = BattleModePlayer.Create(mode, type, players);
            var asset = Assets.LoadAssetAsync("Assets/Project/Configs/CollisonLayer.json");
            TextAsset txt = asset.GetAsset<TextAsset>();
            Assets.Release(asset);
            word = new MobaLogicWord(JsonUtility.FromJson<CollisionLayerConfig>(txt.text));
            frams = new FrameCollection(word);
            input = new BattleInput(frams, mode_server);
            logic = new BattleLogic();
        }


        public void OnLoadSceneFinish()
        {
            logic.LoadBaseUnit();
            mode_server.CallServerReady(Role_id, Room_id);

        }



        public void CloseGame()
        {
            mode_server.Dispose();
            input = null;
            mode_server = null;
            frams = null;
            logic = null;
        }


    }
}

