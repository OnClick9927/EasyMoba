/*********************************************************************************
 *Author:         OnClick
 *Version:        1.0
 *UnityVersion:   2020.3.3f1c1
 *Date:           2022-09-03
 *Description:    Description
 *History:        2022-09-03--
*********************************************************************************/
using IFramework;
using IFramework.Hotfix.Asset;
using IFramework.Hotfix.Lua;
using IFramework.UI;
using System.Collections.Generic;
using UnityEngine;

namespace EasyMoba
{
    public class MobaGame : Game
    {
        public new MobaModules modules;
        public static MobaGame Instance { get { return Launcher.Instance.game as MobaGame; } }
        public Canvas canvas;
        public bool AssetCheck;
        public string playerPrefsKey = "4654623498";

        public override void Init()
        {
            MobaPerfs.SetKey(playerPrefsKey);
            Application.targetFrameRate = 60;
            modules = new MobaModules();
            modules.UpdateUI.SetAsset(new UpdateUIAsset());
            modules.UpdateUI.CreateCanvas();
            modules.UpdateUI.SetGroups(new IFramework.UI.MVC.MvcGroups(new Dictionary<string, System.Type>[]
            {
                MVCMap.map,
            }));
            modules.UpdateUI.Show(MVCMap.UpdatePanel);
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
            modules.UpdateUI.Close(MVCMap.UpdatePanel);
            var asset = await Assets.LoadAsset("Assets/Project/Configs/UICollect.json");
            TextAsset txt = asset.GetAsset<TextAsset>();
            PanelPathCollect _collect = JsonUtility.FromJson<PanelPathCollect>(txt.text);
            modules.UI.SetAsset(new NormalUIAsset(_collect, canvas));
            Assets.Release(asset);
            modules.UI.CreateCanvas();
            asset = await Assets.LoadAsset("Assets/Project/Configs/UILayer.json");
            txt = asset.GetAsset<TextAsset>();
            UILayerConfig _configs = JsonUtility.FromJson<UILayerConfig>(txt.text);
            modules.UI.SetLayerConfig(_configs);
            Assets.Release(asset);
            modules.UI.canvas.transform.SetParent(this.transform, true);
            StartLua();
        }
        private void StartLua()
        {
            //modules.Lua.AddLoader(new AssetsLoader());
            //new XluaMain(modules.Lua);
        }
    }
}
