﻿/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.179
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-07
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace IFramework.Hotfix.Asset
{
    public class SceneAsset : Asset
    {
        private SceneAssetLoadArgs loadArgs;

        public SceneAsset(bool async, Bundle bundle, List<Asset> dps, SceneAssetLoadArgs loadArgs) : base(async, bundle, dps, default)
        {
            this.loadArgs = loadArgs;
        }
        public override string path { get { return loadArgs.path; } }
        public override float progress
        {
            get
            {
                float sum = bundle.progress;
                if (dps == null) return sum;
                float dpSum = 0;
                for (int i = 0; i < dps.Count; i++)
                    dpSum += dps[i].progress / dps.Count;
                return (dpSum + sum) * 0.5f;
            }
        }
        protected async override void OnLoad(bool async)
        {
            await bundle;
            SetResult(null);
        }

        protected override void OnUnLoad()
        {
            Resources.UnloadUnusedAssets();
        }

        protected string sceneName { get { return Path.GetFileNameWithoutExtension(path); } }
        public virtual void LoadScene(LoadSceneMode mode)
        {
            SceneManager.LoadScene(sceneName, mode);
        }
        public virtual Scene LoadScene(LoadSceneParameters parameters)
        {
            return SceneManager.LoadScene(sceneName, parameters);
        }
        public virtual AsyncOperation LoadSceneAsync(LoadSceneParameters parameters)
        {
            return SceneManager.LoadSceneAsync(sceneName, parameters);
        }
        public virtual AsyncOperation LoadSceneAsync(LoadSceneMode mode)
        {
            return SceneManager.LoadSceneAsync(sceneName, mode);
        }
    }
}
