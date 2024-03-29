﻿using IFramework;
using System;
using System.Collections.Generic;

namespace EasyMoba.GameLogic.Mono
{
    public abstract class BattleModePlayer : IDisposable
    {


        public MatchRoomType type;
        public List<BattlePlayer> roles;
        public BattleModePlayer(MatchRoomType type, List<BattlePlayer> roles)
        {
            this.type = type;
            this.roles = roles;
            Launcher.env.SubscribeWaitEnvironmentFrameHandler<SPBattleAllReady>(MonoBattle.Instance.SPAllRealy);
            //Launcher.env.SubscribeWaitEnvironmentFrameHandler<SPBattleFrame>(MonoBattle.Instance.SPFrame);

        }
        public virtual void Dispose()
        {
            Launcher.env.UnSubscribeWaitEnvironmentFrameHandler<SPBattleAllReady>(MonoBattle.Instance.SPAllRealy);
            //Launcher.env.UnSubscribeWaitEnvironmentFrameHandler<SPBattleFrame>(MonoBattle.Instance.SPFrame);

        }


        public static BattleModePlayer Create(BattlePlayMode mode, MatchRoomType type, List<BattlePlayer> roles)
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

        public abstract void CallServerReady(long role_id, long room_id);
        public void SendFrameToServer(int frame, FrameData data)
        {
            SendBattleFrameToServer(MonoBattle.Instance.Room_id,
                MonoBattle.Instance.Role_id,
                frame, data);
        }





        protected CSBattleFrame CreateFrame(long roomid, long roleid, int frame, FrameData op)
        {
            op.roleID = roleid;
            return new CSBattleFrame()
            {
                data = op,
                frameID = frame,
                roomID = roomid,
            };
        }
        protected abstract void SendBattleFrameToServer(long roomid, long roleid, int frame, FrameData op);
        protected void CallLuaFrame(SPBattleFrame obj) => MonoBattle.Instance.SPFrame(obj);
        protected void CallLuaAllReady(SPBattleAllReady response) => MobaGame.Instance.env.WaitEnvironmentFrame(response);
      

    }
}

