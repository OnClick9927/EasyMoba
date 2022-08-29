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
        private bool async;
        protected BundleLoadArgs loadArgs;
        private AssetBundleCreateRequest loadOp;
        public Bundle(BundleLoadArgs loadArgs, bool async)
        {
            this.loadArgs = loadArgs;
            this.async = async;
        }

        public override float progress
        {
            get
            {
                if (async)
                    return isDone ? 1 : (loadOp == null) ? 0 : loadOp.progress;
                return isDone ? 1 : 0;
            }
        }

        protected override async void OnLoad(bool async)
        {
            if (async)
            {
                loadOp = AssetBundle.LoadFromFileAsync(loadArgs.path, loadArgs.crc, loadArgs.offset);
                await this.loadOp;
                SetResult(loadOp.assetBundle);
            }
            else
            {
                AssetBundle value = null;
                value = AssetBundle.LoadFromFile(loadArgs.path, loadArgs.crc, loadArgs.offset);
                SetResult(value);
            }
        }

        protected override void OnUnLoad()
        {
            value.Unload(true);
            Resources.UnloadUnusedAssets();
        }

        public Object LoadAsset(string name, Type type)
        {
            return value.LoadAsset(name, type);
        }
        public AssetBundleRequest LoadAssetAsync(string name, Type type)
        {
            return value.LoadAssetAsync(name, type);
        }
    }
}
