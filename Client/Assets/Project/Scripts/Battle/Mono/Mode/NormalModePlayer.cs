using System.Collections.Generic;
using System.Text;
using IFramework.Net;
using System.Net;
using IFramework.Net.Udp;

namespace EasyMoba.GameLogic.Mono
{
    public class NormalModePlayer : BattleModePlayer
    {
        private Encoding en = Encoding.UTF8;

        //private UdpClient udp;
        private IPEndPoint point;
        private IUdpClientProvider p_udp;
        public NormalModePlayer(MatchRoomType type, List<BattlePlayer> roles) : base(type, roles)
        {
            p_udp = NetTool.CreateUdpClient(4096, 8);
            p_udp.Connect(MobaGame.Instance.UdpPort, MobaGame.Instance.ip);
            p_udp.ReceivedOffsetHandler += ReceivedOffsetHandler;
            //udp = new UdpClient();
            //point = new IPEndPoint(IPAddress.Parse(MobaGame.Instance.ip), MobaGame.Instance.UdpPort);
            //Go();
        }

        private void ReceivedOffsetHandler(SegmentToken session)
        {
            var bytes = session.Data.buffer;
            //Debug.Log(string.Format("<color=#209DBF>收到服务器战斗帧\n{0}</color>", str));
            SPBattleFrame scfram = BattleFrameConvert.ReadSC(bytes);
            CallLuaFrame(scfram);
        }

        //async void Go()
        //{
        //    UdpReceiveResult result = await udp.ReceiveAsync();
        //    var bytes = result.Buffer;
        //    var str = en.GetString(bytes);
        //    //Debug.Log(string.Format("<color=#209DBF>收到服务器战斗帧\n{0}</color>", str));
        //    SPBattleFrame scfram = JsonUtility.FromJson<SPBattleFrame>(str);
        //    CallLuaFrame(scfram);
        //    Go();
        //}


        public override void CallServerReady(long role_id, long room_id)
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
            //udp.Dispose();
            p_udp.Dispose();
        }

        protected override void SendBattleFrameToServer(long roomid, long roleid, int frame, FrameData op)
        {
            CSBattleFrame cs = CreateFrame(roomid, roleid, frame, op);
            //Debug.Log(string.Format("<color=#209DBF>发送战斗帧到服务器\n{0}</color>", json));
            var bytes = BattleFrameConvert.Tobytes(cs);
            SegmentOffset seg = new SegmentOffset(bytes);
            p_udp.Send(seg);
            //udp.SendAsync(bytes, bytes.Length, point);
        }
    }
}

