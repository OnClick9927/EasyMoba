/*********************************************************************************
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
    class AssetsEditorCache : AssetsScriptableObject
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
            List<AssetInfo> assets = new List<AssetInfo>(tree.GetAssets());
            assets.AddRange(tree.GetSingleFiles());
            assets.RemoveAll(x => x.type == AssetInfo.AssetType.Directory);
            tags.ComparePaths(assets.ConvertAll(x => x.path));
        }


        public List<BundleGroup> previewBundles = new List<BundleGroup>();


        public BundleGroup GetGroupByAssetPath(string assetPath)
        {
            return previewBundles.Find(x => x.assets.Contains(assetPath));
        }
        public BundleGroup GetGroupByBundleName(string bundleName)
        {
            return previewBundles.Find(x => x.name == bundleName);
        }
        public string GetTag(string assetPath)
        {
            return tags.GetTag(assetPath);
        }
        public void AddAsset(string tag, List<string> assetPaths)
        {
            foreach (var item in assetPaths)
            {
                tags.AddAsset(tag, item);
            }
            Save();

        }
        public void RemoveAsset(List<string> assetPaths)
        {
            foreach (var item in assetPaths)
            {
                tags.RemoveAsset(item);
            }
            Save();

        }
        public Dictionary<string, string> GetTagDic()
        {
            return tags.GetTagDic();
        }
        public void CompareTags(List<string> tag_new)
        {
            tags.CompareTags(tag_new);
            Save();
        }

        public List<string> GetTagAssetPaths(string tag)
        {
            return tags.GetTagAssetPaths(tag);
        }

        public string GetAssetTag(string assetPath)
        {
            return tags.GetTag(assetPath);
        }

        [SerializeField] private AssetTagCollection tags = new AssetTagCollection();
        [System.Serializable]
        public class AssetTagCollection
        {
            [System.Serializable]
            public class AssetTag
            {
                public string path;
                public string tag;
            }
            public List<AssetTag> assets = new List<AssetTag>();
            public Dictionary<string, string> GetTagDic()
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                foreach (var item in assets)
                {
                    dic.Add(item.path, item.tag);
                }
                return dic;
            }
            public List<string> GetTagAssetPaths(string tag)
            {
                return assets.FindAll(x => x.tag == tag).ConvertAll(x => x.path);
            }
            public void AddAsset(string tag, string assetPath)
            {
                var find = assets.Find(x => x.path == assetPath);
                if (find != null)
                {
                    find.tag = tag;
                }
                else
                {
                    assets.Add(new AssetTag()
                    {
                        path = assetPath,
                        tag = tag
                    });
                }
            }
            public void RemoveAsset(string assetPath)
            {
                assets.RemoveAll(x => x.path == assetPath);
            }
            public void ComparePaths(List<string> paths)
            {
                List<string> remove = new List<string>();
                foreach (var item in assets)
                {
                    if (!paths.Contains(item.path))
                    {
                        remove.Add(item.path);
                    }
                }
                foreach (var item in remove)
                {
                    RemoveAsset(item);
                }
            }

            public void CompareTags(List<string> tag_new)
            {
                assets.RemoveAll(x => !tag_new.Contains(x.tag));
            }


            public string GetTag(string assetPath)
            {
                var find = assets.Find(x => x.path == assetPath);
                if (find == null)
                {
                    return null;
                }
                return find.tag;
            }


        }


    }
}
