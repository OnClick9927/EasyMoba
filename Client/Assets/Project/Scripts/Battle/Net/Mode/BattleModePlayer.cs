using IFramework;
using IFramework.Packets;
using System;
using System.Collections.Generic;
using XLua;

namespace EasyMoba
{
    public abstract class BattleModePlayer : IDisposable
    {
        private Action<SPBattleFrame> call;
        private Action call_2;

        public MatchRoomType type;
        public List<long> roles;
        public BattleModePlayer(MatchRoomType type, List<long> roles)
        {
            var lua = MobaGame.Instance.modules.Lua;
            var battle = lua.gtable.Get<LuaTable>("Battle");
            var for_cs = battle.Get<LuaTable>("for_cs_call");
            call = for_cs.Get<Action<SPBattleFrame>>("OnBattleFrame");
            call_2 = for_cs.Get<Action>("OnBattleAllReady");

            this.type = type;
            this.roles = roles;
            Launcher.env.SubscribeWaitEnvironmentFrameHandler<SPBattleAllReady>(SPAllRealy);
            Launcher.env.SubscribeWaitEnvironmentFrameHandler<SPBattleFrame>(SPFrame);

        }
        public virtual void Dispose()
        {
            Launcher.env.UnSubscribeWaitEnvironmentFrameHandler<SPBattleAllReady>(SPAllRealy);
            Launcher.env.UnSubscribeWaitEnvironmentFrameHandler<SPBattleFrame>(SPFrame);

        }


        public static BattleModePlayer Create(BattlePlayMode mode, MatchRoomType type, List<long> roles)
        {
            switch (mode)
            {
                case BattlePlayMode.Nomal:
                    return new NormalModePlayer(type, roles);
                case BattlePlayMode.Local:
                    return new LocalModePlayer(type, roles);
                case BattlePlayMode.Record:
                    return new RecordModePlayer(type, roles);
            }
            return null;
        }

        public abstract void CallServerReady(long role_id, string room_id);
        public void SendFrameToServer()
        {
            SendBattleFrameToServer(LocalInputRecorder.instance.roomid,
                LocalInputRecorder.instance.roleid,
                LocalInputRecorder.instance.curframe, LocalInputRecorder.instance.data);
            LocalInputRecorder.instance.RebuidData();
        }





        protected CSBattleFrame CreateFrame(string roomid, long roleid, int frame, FrameData op)
        {
            return new CSBattleFrame()
            {
                data = op,
                frameID = frame,
                roleID = roleid,
                roomID = roomid,
            };
        }
        protected abstract void SendBattleFrameToServer(string roomid, long roleid, int frame, FrameData op);
        protected void CallLuaFrame(SPBattleFrame obj) => MobaGame.Instance.env.WaitEnvironmentFrame(obj);
        protected void CallLuaAllReady(SPBattleAllReady response) => MobaGame.Instance.env.WaitEnvironmentFrame(response);
        private void SPFrame(SPBattleFrame obj) => call?.Invoke(obj);
        private void SPAllRealy(SPBattleAllReady obj) => call_2?.Invoke();

    }
}

