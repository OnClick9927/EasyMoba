/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.179
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-07
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
namespace IFramework.Hotfix.Asset
{
    public class Asset : RefenceAsset<Object>
    {
        protected bool async;
        public Bundle bundle;
        private AssetBundleRequest loadOp;
        protected List<Asset> dps;
        public virtual string path { get { return loadArgs.path; } }
        private AssetLoadArgs loadArgs;
        public Asset(bool async, Bundle bundle, List<Asset> dps, AssetLoadArgs loadArgs)
        {
            this.async = async;
            this.bundle = bundle;
            this.dps = dps;
            this.loadArgs = loadArgs;
        }
        public override float progress
        {
            get
            {
                float sum = 0;
                if (bundle.isDone)
                {
                    if (async)
                        sum = isDone ? 1 : (loadOp == null) ? 0 : loadOp.progress;
                    else
                        sum = isDone ? 1 : 0;
                }
                if (dps == null) return sum;
                float dpSum = 0;
                for (int i = 0; i < dps.Count; i++)
                    dpSum += dps[i].progress / dps.Count;
                return (dpSum + sum) * 0.5f;
            }
        }

        private Sprite sp;
        public T GetAsset<T>() where T : Object
        {
            if (value is Texture2D)
            {
                if (typeof(T) == typeof(Sprite))
                {
                    if (sp == null)
                    {
                        var tx = value as Texture2D;
                        sp = Sprite.Create(tx, new Rect(0, 0, tx.width, tx.height), Vector2.one * 0.5f);
                    }
                    return sp as T;
                }
            }
            return value as T;
        }
        protected async override void OnLoad(bool async)
        {
            await bundle;
            if (async)
            {
                loadOp = bundle.LoadAssetAsync(loadArgs.path, typeof(UnityEngine.Object));
                await loadOp;
                SetResult(loadOp.asset);
            }
            else
            {
                Object obj = bundle.LoadAsset(loadArgs.path, typeof(UnityEngine.Object));
                SetResult(obj);
            }
        }
        protected override void OnUnLoad()
        {
            Resources.UnloadAsset(value);
        }
    }

}
