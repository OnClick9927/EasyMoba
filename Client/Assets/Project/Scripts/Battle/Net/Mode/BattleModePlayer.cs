using System;

namespace EasyMoba
{
    public abstract class BattleModePlayer : IDisposable
    {
        private Action<SPBattleFrame> call;
        public BattleModePlayer()
        {
            call = MobaGame.Instance.modules.Lua.gtable.Get<Action<SPBattleFrame>>("Battle.OnBattelFrame");
        }
        public static BattleModePlayer Create(BattlePlayMode mode)
        {
            switch (mode)
            {
                case BattlePlayMode.Nomal:
                    return new NormalModePlayer();
                case BattlePlayMode.Local:
                    return new LocalModePlayer();
                case BattlePlayMode.Record:
                    return new RecordModePlayer();
            }
            return null;
        }


        public void SendFrameToServer()
        {
            SendBattleFrameToServer(LocalInputRecorder.instance.roomid,
                LocalInputRecorder.instance.roleid,
                LocalInputRecorder.instance.curframe, LocalInputRecorder.instance.data);
            LocalInputRecorder.instance.RebuidData();
        }
        protected abstract void SendBattleFrameToServer(string roomid, long roleid, int frame, FrameData op);

        protected void call_lua(SPBattleFrame obj)
        {
            call?.Invoke(obj);
        }
        public abstract void Dispose();
    }
}

