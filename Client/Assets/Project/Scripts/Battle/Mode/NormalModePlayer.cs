using System.Collections.Generic;

namespace EasyMoba.GameLogic
{
    public partial class NormalModePlayer : BattleModePlayer
    {

        private UdpClient udp;
        public NormalModePlayer(MatchRoomType type, List<long> roles) : base(type, roles)
        {
            udp = new UdpClient(MobaGame.Instance.UdpPort, MobaGame.udpbufSize, MobaGame.Instance.ip, this);
            udp.CreateClient();
        }

        public override void CallServerReady(long role_id, string room_id)
        {
            MobaGame.Instance.modules.tcp.SendRequest(new CSBattleReady()
            {
                roleID = role_id,
                roomID = room_id,
            });
        }

        public override void Dispose()
        {
            base.Dispose();
            udp.CloseUdp();
        }

        protected override void SendBattleFrameToServer(string roomid, long roleid, int frame, FrameData op)
        {
            udp.SendBattleFrame(CreateFrame(roomid, roleid, frame, op));
        }
    }
}

