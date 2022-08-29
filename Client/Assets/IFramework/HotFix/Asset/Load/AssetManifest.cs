/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.179
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-07
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
namespace IFramework.Hotfix.Asset
{
    public class AssetManifest : ScriptableObject
    {
        public const string Path = "Assets/" + Name + ".asset";
        public const string Name = "manifest";
        [Serializable]
        public class AssetData
        {
            public string path;
            public string bundleName;
            public List<string> dps;
        }
        [SerializeField] private List<AssetData> assets = new List<AssetData>();

        public void Read(Dictionary<string, string> allAssets, Dictionary<string, List<string>> assetdps)
        {
            if (Application.isEditor)
            {
                assets.Clear();
                foreach (var item in allAssets)
                {
                    AssetData data = new AssetData();
                    data.path = item.Key;
                    data.bundleName = item.Value;
                    if (assetdps.ContainsKey(item.Key))
                    {
                        data.dps = assetdps[item.Key];
                    }
                    assets.Add(data);
                }
            }
        }

        private Dictionary<string, List<string>> assetdps;
        private Dictionary<string, string> allAssets;
        private List<string> allPaths;

        private void Check()
        {
            if (assetdps == null)
            {
                assetdps = new Dictionary<string, List<string>>();
                allAssets = new Dictionary<string, string>();
                allPaths = new List<string>();
                for (int i = 0; i < assets.Count; i++)
                {
                    assetdps.Add(assets[i].path, assets[i].dps);
                    allAssets.Add(assets[i].path, assets[i].bundleName);
                    allPaths.Add(assets[i].path);
                }
            }
        }
        public List<string> GetAssetDependences(string assetPath)
        {
            try
            {
                Check();
                if (assetdps.ContainsKey(assetPath))
                    return assetdps[assetPath];
            }
            catch (Exception e)
            {
                AssetsInternal.LogError(e.Message);
            }
            return null;
        }
        public string GetBundle(string assetPath)
        {
            try
            {
                Check();
                if (allAssets.ContainsKey(assetPath))
                    return allAssets[assetPath];
            }
            catch (Exception e)
            {
                AssetsInternal.LogError(e.Message);
            }
            return null;
        }

        public IReadOnlyList<string> GetAssets()
        {
            Check();
            return allPaths;
        }
    }
}
