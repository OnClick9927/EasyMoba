namespace EasyMoba.GameLogic
{
    public class BattleInput
    {
        private FrameCollection collection;
        private BattleModePlayer mode_server;
        public FrameData data = new FrameData();

        public BattleInput(FrameCollection collection, BattleModePlayer mode_server)
        {
            this.collection = collection;
            this.mode_server = mode_server;
        }
        public int curframe { get { return collection.curFrame; } }
        public void SendFrame()
        {
            mode_server.SendFrameToServer(this);
            data = new FrameData();
        }
    }
}

