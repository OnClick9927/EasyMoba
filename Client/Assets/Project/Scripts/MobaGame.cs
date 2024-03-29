﻿/*********************************************************************************
 *Author:         OnClick
 *Version:        1.0
 *UnityVersion:   2020.3.3f1c1
 *Date:           2022-09-03
 *Description:    Description
 *History:        2022-09-03--
*********************************************************************************/
using IFramework;
using IFramework.Hotfix.Lua;
using IFramework.UI;
using System.Collections.Generic;
using UnityEngine;
using WooAsset;

namespace EasyMoba
{
    public class MobaGame : Game
    {
        public new MobaModules modules;
        public static MobaGame Instance { get { return Launcher.Instance.game as MobaGame; } }
        public Canvas canvas;
        public bool AssetCheck;
        public string playerPrefsKey = "4654623498";
        public string ip = "127.0.0.1";
        private int tcpPort = 9633;
        [HideInInspector]
        public int UdpPort = 9634;

        public static int udpbufSize = 1024 * 128;
        public static int tcpBufSize = 1024 * 1024;

        public override void Init()
        {
            MobaPerfs.SetKey(playerPrefsKey);
            Application.targetFrameRate = 60;
            modules = new MobaModules();
            modules.UpdateUI.SetAsset(new UpdateUIAsset());
            modules.UpdateUI.CreateCanvas();
            modules.UpdateUI.SetGroups(new IFramework.UI.MVC.MvcGroups(MVCMap.map));
            modules.UpdateUI.Show(PanelNames.UpdatePanel);
            modules.UpdateUI.canvas.transform.SetParent(this.transform, true);

            env.BindDispose(OnDispose);
        }
        private void OnDispose()
        {

        }
        public override void Startup()
        {
            modules.update.Check();

        }

        public async void StartGame()
        {
            await System.Threading.Tasks.Task.Delay(100);
            modules.UpdateUI.Close(PanelNames.UpdatePanel);
            var asset = await Assets.LoadAssetAsync("Assets/Project/Configs/UICollect.json");
            TextAsset txt = asset.GetAsset<TextAsset>();
            PanelPathCollect _collect = JsonUtility.FromJson<PanelPathCollect>(txt.text);
            modules.UI.SetAsset(new NormalUIAsset(_collect, canvas));
            Assets.Release(asset);
            modules.UI.CreateCanvas();
            Assets.Release(asset);
            modules.UI.canvas.transform.SetParent(this.transform, true);
            modules.tcp = new TcpClient(ip, tcpPort, tcpBufSize);
            StartLua();
        }
        private void StartLua()
        {
            modules.Lua.AddLoader(new AssetsLoader());
            new XluaMain(modules.Lua);
        }
    }
}
