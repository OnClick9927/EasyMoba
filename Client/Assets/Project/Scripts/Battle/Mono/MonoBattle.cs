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
    public class MonoBattle : MonoSingleton<MonoBattle>, IBattleView
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

            battle = new Battle(this, JsonUtility.FromJson<CollisionLayerConfig>(txt.text));
            battle.StartGame(role_id, room_id, type, players);

            mode_server = BattleModePlayer.Create(mode, type, players);
            input = new BattleInput(mode_server);
            start?.Invoke();
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
                colse?.Invoke();
                battle = null;
            }

        }
        private void Update()
        {
            if (!gameing) return;
            input.Update();
            update?.Invoke();
        }

        private Action start, update, colse;
        private Action<MobaUnit> create_unit;
        protected override void OnSingletonInit()
        {
            var G = MobaGame.Instance.modules.Lua.gtable;
            var battle = G.Get<LuaTable>("Battle");
            start = battle.Get<Action>("Start");
            update = battle.Get<Action>("Update");
            colse = battle.Get<Action>("Quit");
            create_unit = battle.Get<Action<MobaUnit>>("CreateUnit");
            Launcher.env.BindDispose(CloseGame);
        }

        public void OnUnitCreate(MobaUnit unit)
        {
            create_unit?.Invoke(unit);

        }
    }
}

