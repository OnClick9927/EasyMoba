/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.241
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-14
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;

namespace IFramework.Hotfix.Asset
{
    public class LocalSetting : AssetsSetting
    {
        private string root = Application.dataPath.CombinePath("../DLCDownLoad/Windows");

        public override string GetUrlByBundleName(string buildTarget, string bundleName)
        {
            return root.CombinePath(bundleName).ToRegularPath();
        }

        public override string GetVersionUrl(string buildTarget)
        {
            return root.CombinePath("version").ToRegularPath();
        }
    }
    public class AssetExample : UnityEngine.MonoBehaviour
    {
        public Image image;
        public Image image2;
        private async void Start()
        {
            //Assets.SetAssetsSetting(new LocalSetting());
            //var op = await Assets.VersionCheck();
            //for (int i = 0; i < op.downLoadOnes.Count; i++)
            //{
            //    await Assets.DownLoadBundle(op.downLoadOnes[i].bundleName);
            //}
            await Assets.InitAsync();
            await Assets.InstantiateAsync("Assets/IFramework/HotFix/Asset/__Example/New Folder/Cube.prefab", null);
            var sceneAsset = await Assets.LoadSceneAssetAsync("Assets/IFramework/HotFix/Asset/__Example/New Scene2.unity");
            await sceneAsset.LoadSceneAsync(LoadSceneMode.Additive);
        }
        int index = 0;
        private async void Update()
        {
            if (!Assets.Initialized()) return;
            index = (int)Mathf.Repeat(++index, 3);
            //string path = "Assets/IFramework/HotFix/Asset/__Example/px.spriteatlas";
            //var asset = await Assets.LoadAssetAsync(path);
            //var prefab = asset.GetAsset<SpriteAtlas>();
            //image.sprite = prefab.GetSprite((index + 1).ToString());
            //index = (int)Mathf.Repeat(++index, 3);
            //image2.sprite = prefab.GetSprite((index + 1).ToString());


            string path = $"Assets/IFramework/HotFix/Asset/__Example/px/{index + 1}.png";
            var asset = await Assets.LoadAssetAsync(path);
            var prefab = asset.GetAsset<Sprite>();
            image.sprite = prefab;
            index = (int)Mathf.Repeat(++index, 3);
            path = $"Assets/IFramework/HotFix/Asset/__Example/px/{index + 1}.png";
            asset = await Assets.LoadAssetAsync(path);
            prefab = asset.GetAsset<Sprite>();
            image2.sprite = prefab;
        }
    }
}
