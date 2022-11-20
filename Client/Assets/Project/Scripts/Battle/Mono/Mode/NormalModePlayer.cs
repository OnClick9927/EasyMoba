using System;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditor.PackageManager;
using static Room;
using static System.Collections.Specialized.BitVector32;
using UnityEngine;
using System.Text;
using IFramework.Net;
using System.Net;
using System.Drawing;

namespace EasyMoba.GameLogic.Mono
{
    public class NormalModePlayer : BattleModePlayer
    {
        private Encoding en = Encoding.UTF8;

        private UdpClient udp;
        private IPEndPoint point;
        public NormalModePlayer(MatchRoomType type, List<BattlePlayer> roles) : base(type, roles)
        {
            udp = new UdpClient();
            point = new IPEndPoint(IPAddress.Parse(MobaGame.Instance.ip), MobaGame.Instance.UdpPort);
            Go();
        }

        async void Go()
        {
            UdpReceiveResult result = await udp.ReceiveAsync();
            var bytes = result.Buffer;
            var str = en.GetString(bytes);
            Debug.Log(string.Format("<color=#209DBF>收到服务器战斗帧\n{0}</color>", str));
            SPBattleFrame scfram = JsonUtility.FromJson<SPBattleFrame>(str);
            CallLuaFrame(scfram);
            Go();
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
            udp.Dispose();
        }

        protected override void SendBattleFrameToServer(string roomid, long roleid, int frame, FrameData op)
        {
            CSBattleFrame cs = CreateFrame(roomid, roleid, frame, op);
            var json = JsonUtility.ToJson(cs);
            Debug.Log(string.Format("<color=#209DBF>发送战斗帧到服务器\n{0}</color>", json));
            var bytes = en.GetBytes(json);
            udp.SendAsync(bytes,bytes.Length, point);
        }
    }
}

