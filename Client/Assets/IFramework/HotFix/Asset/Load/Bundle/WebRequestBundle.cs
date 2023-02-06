/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.179
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-07
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

using UnityEngine;
using static IFramework.Hotfix.Asset.AssetsInternal;

namespace IFramework.Hotfix.Asset
{
    public class WebRequestBundle : Bundle
    {
        public WebRequestBundle(BundleLoadArgs loadArgs) : base(loadArgs)
        {
        }
        public override float progress
        {
            get
            {
                if (isDone) return 1;
                if (loadOp == null) return downloader.progress * 0.5f;
                return downloader.progress * 0.5f + loadOp.progress * 0.5f;
            }
        }

        private Downloader downloader;
        private AssetBundleCreateRequest loadOp;

        protected async override void OnLoad()
        {
            downloader = new Downloader(loadArgs.path);
            await downloader.Start();
            if (!downloader.isError)
            {
                loadOp = await AssetBundle.LoadFromMemoryAsync(downloader.data, loadArgs.crc);
                SetResult(loadOp.assetBundle);
            }
            else
            {
                SetResult(null);
            }
        }
        protected override void OnUnLoad()
        {
            value.Unload(true);
            Resources.UnloadUnusedAssets();
        }
    }
}
