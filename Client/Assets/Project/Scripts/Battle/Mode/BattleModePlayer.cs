using IFramework;
using IFramework.Packets;
using System;
using System.Collections.Generic;
using XLua;

namespace EasyMoba.GameLogic
{
    public abstract class BattleModePlayer : IDisposable
    {


        public MatchRoomType type;
        public List<long> roles;
        public BattleModePlayer(MatchRoomType type, List<long> roles)
        {
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
                case BattlePlayMode.Normal:
                    return new NormalModePlayer(type, roles);
                case BattlePlayMode.Local:
                    return new LocalModePlayer(type, roles);
                case BattlePlayMode.Record:
                    return new RecordModePlayer(type, roles);
            }
            return null;
        }

        public abstract void CallServerReady(long role_id, string room_id);
        public void SendFrameToServer(BattleInput recorder)
        {
            SendBattleFrameToServer(Battle.Instance.Room_id,
                Battle.Instance.Role_id,
                recorder.curframe, recorder.data);
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
        private void SPFrame(SPBattleFrame obj) {

            Battle.Instance.frams.OnBattleFrame(obj);
        }
        private void SPAllRealy(SPBattleAllReady obj) {

            Battle.Instance.logic.StartPlayLogic();
        }

    }
}

