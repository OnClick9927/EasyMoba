/*********************************************************************************
 *Author:         OnClick
 *Version:        1.0
 *UnityVersion:   2020.3.3f1c1
 *Date:           2022-10-12
 *Description:    Description
 *History:        2022-10-12--
*********************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using IFramework;
using IFramework.Net;
using IFramework.Net.Udp;
using UnityEngine;

namespace EasyMoba
{

    public class UdpClient
    {
        private int port = 9633;
        private readonly int bufsize;
        private string ip = "127.0.0.1";
        private IUdpClientProvider client;
        private Encoding en = Encoding.UTF8;
        public event Action<SPBattleFrame> onResponse;

        public UdpClient(int port, int bufsize, string ip)
        {
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
        public void SendBattleFrame(string roomid, long roleid, int frame, FrameData op)
        {
            CSBattleFrame cs = new CSBattleFrame()
            {
                data = op,
                frameID = frame,
                roleID = roleid,
                roomID = roomid,
            };
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
                onResponse?.Invoke(scfram);
            });

        }
        public void CloseUdp()
        {
            client?.Disconnect();
            client = null;
        }
    }
}
