﻿using System.Collections.Generic;

namespace EasyMoba.GameLogic.Mono
{
    public class LocalModePlayer : BattleModePlayer, ICanCallClientBattleMsg
    {
        Room room;
        public LocalModePlayer(MatchRoomType type, List<BattlePlayer> roles) : base(type, roles)
        {
            room = new Room(type, roles.ToArray(), Battle.delta, this);
        }

        public override void CallServerReady(long role_id, long room_id)
        {
            room.Ready(role_id);
        }

        public override void Dispose()
        {
            base.Dispose();
            room.GameEnd();
        }

        void ICanCallClientBattleMsg.SendBattleFrame(long roleID, SPBattleFrame frame)
        {
            CallLuaFrame(frame);
        }

        void ICanCallClientBattleMsg.SendResponse(long role_id, SPBattleAllReady response)
        {

            CallLuaAllReady(response);
        }

        protected override void SendBattleFrameToServer(long roomid, long roleid, int frame, FrameData op)
        {
            room.ReadBattleFrame(CreateFrame(roomid, roleid, frame, op));

        }
    }
}

