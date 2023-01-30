using IFramework;
using IFramework.Hotfix.Asset;
using IFramework.Singleton;
using LockStep.LCollision2D;
using LockStep.Math;
using System;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace EasyMoba.GameLogic.Mono
{
    public class MonoBattle : MonoSingleton<MonoBattle>
    {
        private BattleInput input;
        private BattleModePlayer mode_server;
        private bool gameing;
        private Battle battle;
        public long Role_id { get => battle.Role_id; }
        public string Room_id { get => battle.Room_id; }
        public void SPFrame(SPBattleFrame obj) => battle.ReadFrame(obj);
        public void SPAllRealy(SPBattleAllReady obj) {
            battle.StartPlayLogic(obj);
            gameing = true;

        }
        public int CurFrame => battle.GetCurFrame();
        public async void StartGame(BattlePlayMode mode, long role_id, string room_id, MatchRoomType type, List<BattlePlayer> players)
        {
            var asset = await Assets.LoadAssetAsync("Assets/Project/Configs/CollisonLayer.json");
            TextAsset txt = asset.GetAsset<TextAsset>();
            Assets.Release(asset);

            battle = new Battle(new BattleView(), JsonUtility.FromJson<CollisionLayerConfig>(txt.text),null);
            battle.StartGame(role_id, room_id, type, players);

            mode_server = BattleModePlayer.Create(mode, type, players);
            input = new BattleInput(mode_server);
        }
        public void OnLoadSceneFinish()
        {
            MapInitCollection collection = FindObjectOfType<MapInitCollection>();
            mode_server.CallServerReady(Role_id, Room_id);
            battle.SetMapData(collection.data);
        }
        public void CloseGame()
        {
            if (battle!=null)
            {
                gameing = false;
                battle.CloseGame();
                mode_server.Dispose();
                mode_server = null;
                battle = null;
            }

        }
        private void Update()
        {
            if (!gameing) return;
            input.Update();
        }

        protected override void OnSingletonInit()
        {
            Launcher.env.BindDispose(CloseGame);
        }

        
    }
}

