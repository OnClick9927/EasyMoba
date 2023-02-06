/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.179
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-07
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

using System;
using UnityEngine;
using Object = UnityEngine.Object;
namespace IFramework.Hotfix.Asset
{
    public class Bundle : RefenceAsset<AssetBundle>
    {
        protected BundleLoadArgs loadArgs;
        private AssetBundleCreateRequest loadOp;
        public Bundle(BundleLoadArgs loadArgs)
        {
            this.loadArgs = loadArgs;
        }

        public override float progress
        {
            get
            {
                return isDone ? 1 : (loadOp == null) ? 0 : loadOp.progress;
            }
        }

        protected override async void OnLoad()
        {
            loadOp = AssetBundle.LoadFromFileAsync(loadArgs.path, loadArgs.crc, loadArgs.offset);
            await this.loadOp;
            SetResult(loadOp.assetBundle);
        }

        protected override void OnUnLoad()
        {
            value.Unload(true);
            Resources.UnloadUnusedAssets();
        }

        public AssetBundleRequest LoadAssetAsync(string name, Type type)
        {
            return value.LoadAssetAsync(name, type);
        }
    }
}
