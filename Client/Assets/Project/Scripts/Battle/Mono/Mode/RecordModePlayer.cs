using System.Collections.Generic;

namespace EasyMoba.GameLogic.Mono
{
    public class RecordModePlayer : BattleModePlayer
    {
        public RecordModePlayer(MatchRoomType type, List<BattlePlayer> roles) : base(type,roles) { }

        public override void CallServerReady(long role_id, long room_id)
        {
           
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        protected override void SendBattleFrameToServer(long roomid, long roleid, int frame, FrameData op)
        {
            return;
        }
    }
}

