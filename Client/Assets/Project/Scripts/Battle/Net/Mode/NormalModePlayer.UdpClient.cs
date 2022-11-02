using IFramework.Net.Udp;
using IFramework.Net;
using System.Text;
using UnityEngine;
using IFramework;

namespace EasyMoba
{
    public partial class NormalModePlayer
    {
        public class UdpClient
        {
            private int port = 9633;
            private readonly int bufsize;
            private string ip = "127.0.0.1";
            private IUdpClientProvider client;
            private Encoding en = Encoding.UTF8;
            private NormalModePlayer player;
            public UdpClient(int port, int bufsize, string ip, NormalModePlayer player)
            {
                this.player = player;
                this.port = port;
                this.bufsize = bufsize;
                this.ip = ip;
            }

            public void CreateClient()
            {
                client = NetTool.CreateUdpClient(bufsize);
                client.Connect(port, ip);
                client.StartReceive();
                client.ReceivedOffsetHandler += Recieve;
            }
            public void SendBattleFrame(CSBattleFrame cs)
            {
                var json = JsonUtility.ToJson(cs);
                Debug.Log(string.Format("<color=#209DBF>发送战斗帧到服务器\n{0}</color>", json));

                client.Send(new SegmentOffset(en.GetBytes(json)));
            }
            private void Recieve(SegmentToken session)
            {
                var bytes = session.Data.buffer;
                var str = en.GetString(bytes);
                Debug.Log(string.Format("<color=#209DBF>收到服务器战斗帧\n{0}</color>", str));
                SPBattleFrame scfram = JsonUtility.FromJson<SPBattleFrame>(str);
                if (scfram == null) return;
                Launcher.env.WaitEnvironmentFrame(() =>
                {
                    player.CallLuaFrame(scfram);
                });

            }
            public void CloseUdp()
            {
                client?.Disconnect();
                client = null;
            }
        }
    }
}

