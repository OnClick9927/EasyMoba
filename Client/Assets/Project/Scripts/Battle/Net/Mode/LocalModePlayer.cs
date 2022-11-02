namespace EasyMoba
{
    public class LocalModePlayer : BattleModePlayer
    {
        public LocalModePlayer() : base() { }
        public override void Dispose()
        {

        }

        protected override void SendBattleFrameToServer(string roomid, long roleid, int frame, FrameData op)
        {

        }
    }
}

