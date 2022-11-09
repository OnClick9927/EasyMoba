using System.Collections.Generic;

namespace EasyMoba.GameLogic.Mono
{
    public class LocalModePlayer : BattleModePlayer, ICanCallClientBattleMsg
    {
        Room room;
        public LocalModePlayer(MatchRoomType type, List<long> roles) : base(type, roles)
        {
            room = new Room(type, roles, MobaGame.udpGap, this);

        }

        public override void CallServerReady(long role_id, string room_id)
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

        protected override void SendBattleFrameToServer(string roomid, long roleid, int frame, FrameData op)
        {
            room.ReadBattleFrame(CreateFrame(roomid, roleid, frame, op));

        }
    }
}

