using IFramework.Net.Udp;
using IFramework.Net;
using System;
using System.Text;
using UnityEngine;
using IFramework;

namespace EasyMoba
{
    public partial class NormalModePlayer : BattleModePlayer
    {

        private UdpClient udp;
        public NormalModePlayer():base()
        {
            udp = new UdpClient(MobaGame.Instance.UdpPort, MobaGame.udpbufSize, MobaGame.Instance.ip,this);
            udp.CreateClient();
        }

        public override void Dispose()
        {
            udp.CloseUdp();
        }

        protected override void SendBattleFrameToServer(string roomid, long roleid, int frame, FrameData op)
        {
            udp.SendBattleFrame(roomid, roleid, frame, op);
        }
    }
}

