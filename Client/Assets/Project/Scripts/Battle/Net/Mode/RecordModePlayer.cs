namespace EasyMoba
{
    public class RecordModePlayer : BattleModePlayer
    {
        public RecordModePlayer() : base() { }
        public override void Dispose()
        {

        }

        protected override void SendBattleFrameToServer(string roomid, long roleid, int frame, FrameData op)
        {
            return;
        }
    }
}

