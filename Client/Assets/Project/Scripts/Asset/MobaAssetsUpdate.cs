/*********************************************************************************
 *Author:         OnClick
 *Version:        1.0
 *UnityVersion:   2020.3.3f1c1
 *Date:           2022-09-03
 *Description:    Description
 *History:        2022-09-03--
*********************************************************************************/
using System;
using System.Collections;
using System.Linq;
using IFramework;
using IFramework.Hotfix.Asset;
using static IFramework.Hotfix.Asset.AssetsInternal;

namespace EasyMoba
{
    public class MobaAssetsUpdate
    {
        public event Action<float> downLoadProgress;
        public event Action beginDownLoad;
        public event Action endDownLoad;
        public event Action beginPrepare, endPrepare;
        public event Action<float> prepareProgress;
        public async void Check()
        {
            MobaGame game = MobaGame.Instance;
            if (game.AssetCheck)
            {
                Assets.SetAssetsSetting(new MobaAssetsSetting());
                var op = await Assets.VersionCheck();
                int count = op.downLoadOnes.Count;
                if (count > 0)
                {
                    beginDownLoad?.Invoke();
                    for (int i = 0; i < count; i++)
                    {
                        await Assets.DownLoadBundle(op.downLoadOnes[i].bundleName);
                        downLoadProgress?.Invoke(i / (float)count);
                    }
                    endDownLoad?.Invoke();
                }
                Init();

            }
            else
            {
                await System.Threading.Tasks.Task.Delay(1000);
                Init();


            }

        }
        private async void Init()
        {
            beginPrepare?.Invoke();
            await Assets.InitAsync();
            var paths = AssetsInternal.GetAllAssetPaths();
            var prepareOP = Assets.PrepareAssets(paths.ToArray());
            Launcher.Instance.StartCoroutine(CallProgress(prepareOP));
        }
        private IEnumerator CallProgress(AssetsGroupOperation prepareOP)
        {
            while (!prepareOP.isDone)
            {
                prepareProgress?.Invoke(prepareOP.progress);
                yield return null;
            }
            endPrepare?.Invoke();
        }
    }
}
