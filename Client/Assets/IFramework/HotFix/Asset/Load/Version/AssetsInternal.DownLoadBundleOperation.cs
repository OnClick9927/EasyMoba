/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.179
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-07
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/


namespace IFramework.Hotfix.Asset
{
    partial class AssetsInternal
    {
        public class DownLoadBundleOperation : AssetOperation
        {
            public override float progress
            {
                get
                {
                    if (isDone) return 1;
                    return downloader.progress * 0.9f;
                }
            }
            public string bundleName { get; private set; }
            private Downloader downloader;

            public DownLoadBundleOperation(string bundleName)
            {
                this.bundleName = bundleName;
                Done();
            }
            private async void Done()
            {
                string url = AssetsInternal.GetUrlFromBundleName(bundleName);
                string writePath = AssetsInternal.GetBundleLocalPath(bundleName);
                downloader = new Downloader(url, writePath);
                await downloader.Start();
                if (downloader.isError)
                {
                    SetErr(downloader.error);
                }
                InvokeComplete();
            }

        }
    }
}
