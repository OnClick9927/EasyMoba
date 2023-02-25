﻿/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.204
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-09
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System;
using System.Collections.Generic;
using UnityEngine;

namespace IFramework.Hotfix.Asset
{
    partial class AssetsEditorCache : AssetsScriptableObject
    {

        [SerializeField] private AssetsTree tree = new AssetsTree();

        public List<AssetInfo> GetRootDirPaths()
        {
            return tree.GetRootDirPaths();
        }
        public List<AssetInfo> GetSubFloders(AssetInfo info)
        {
            return tree.GetSubFloders(info);
        }
        public List<AssetInfo> GetSubFiles(AssetInfo info)
        {
            return tree.GetSubFiles(info);
        }
        public List<AssetInfo> GetSingleFiles()
        {
            return tree.GetSingleFiles();
        }
        public List<AssetInfo> GetAssets()
        {
            return tree.GetAssets();
        }
        public Dictionary<AssetInfo, List<AssetInfo>> GetDpDic()
        {
            return tree.GetDpDic();
        }
        public List<string> GetDps(string path)
        {
            return tree.GetDps(path);
        }
        public AssetInfo GetAssetInfo(string path)
        {
            return tree.GetAssetInfo(path);
        }





        public void Colllect(List<string> paths)
        {
            //AssetDatabase.ForceReserializeAssets();
            tree.Clear();
            for (int i = 0; i < paths.Count; i++)
            {
                tree.AddPath(paths[i]);
            }
            tree.CollectDps();
            tree.RemoveUselessInfos();
            List<AssetInfo> assets = new List<AssetInfo>(GetAssets());
            assets.AddRange(tree.GetSingleFiles());
            assets.RemoveAll(x => x.type == AssetInfo.AssetType.Directory);
            tags.ComparePaths(assets.ConvertAll(x => x.path));
        }

 
       [SerializeField] private List<BundleGroup> previewBundles = new List<BundleGroup>();
        public List<BundleGroup> GetPreviewBundles()
        {
            return previewBundles;
        }
        public void SetPreviewBundles(List<BundleGroup> result)
        {
            previewBundles = result;
        }

        public BundleGroup GetBundleGroupByAssetPath(string assetPath)
        {
            return previewBundles.Find(x => x.assets.Contains(assetPath));
        }
        public BundleGroup GetBundleGroupByBundleName(string bundleName)
        {
            return previewBundles.Find(x => x.name == bundleName);
        }

        [SerializeField] private AssetTagCollection tags = new AssetTagCollection();

        public string GetAssetTag(string assetPath)
        {
            return tags.GetTag(assetPath);
        }
        public void AddAssetTag(string tag, List<string> assetPaths)
        {
            foreach (var item in assetPaths)
            {
                tags.AddAsset(tag, item);
            }
        }
        public void RemoveTagAssets(List<string> assetPaths)
        {
            foreach (var item in assetPaths)
            {
                tags.RemoveAsset(item);
            }
        }
        public Dictionary<string, string> GetTagDic()
        {
            return tags.GetTagDic();
        }
        public void RemoveUseLessTagAssets(List<string> tag_new)
        {
            tags.CompareTags(tag_new);
        }
        public List<string> GetTagAssetPaths(string tag)
        {
            return tags.GetTagAssetPaths(tag);
        }





    }
}
