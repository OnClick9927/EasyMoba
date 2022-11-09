using System.Collections.Generic;

namespace EasyMoba.GameLogic.Mono
{
    public class RecordModePlayer : BattleModePlayer
    {
        public RecordModePlayer(MatchRoomType type, List<long> roles) : base(type,roles) { }

        public override void CallServerReady(long role_id, string room_id)
        {
           
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        protected override void SendBattleFrameToServer(string roomid, long roleid, int frame, FrameData op)
        {
            return;
        }
    }
}

