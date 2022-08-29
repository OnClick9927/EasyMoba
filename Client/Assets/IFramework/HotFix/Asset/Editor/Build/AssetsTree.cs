/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.204
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-09
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
namespace IFramework.Hotfix.Asset
{
    [System.Serializable]
    public class AssetsTree
    {
        [SerializeField] private List<AssetInfo> rootAssets = new List<AssetInfo>();
        [SerializeField] private List<AssetInfo> assets = new List<AssetInfo>();
        [SerializeField] private List<string> fileassets = new List<string>();

        public void Clear()
        {
            rootAssets.Clear();
            assets.Clear();
            fileassets.Clear();
        }
        public Dictionary<AssetInfo, List<AssetInfo>> GetDpDic()
        {
            Dictionary<AssetInfo, List<AssetInfo>> dic = new Dictionary<AssetInfo, List<AssetInfo>>();
            foreach (var asset in assets)
            {
                if (asset.IsDirectory()) continue;
                var list = assets.FindAll(a => { return a.dps.Contains(asset.path); });
                dic.Add(asset, list);
            }
            return dic;
        }

        public List<AssetInfo> GetRootPaths()
        {
            return rootAssets;
        }
        public List<string> GetSingleFiles()
        {
            return fileassets;
        }
        public List<AssetInfo> GetSubFloders(AssetInfo info)
        {
            string path = info.path;
            return assets.FindAll(x => x.parentPath == path && x.IsDirectory());
        }
        public List<AssetInfo> GetSubFiles(AssetInfo info)
        {
            string path = info.path;
            return assets.FindAll(x => x.parentPath == path && !x.IsDirectory());
        }

        public void AddPath(string path)
        {
            path = path.ToRegularPath();
            for (int i = 0; i < assets.Count; i++)
            {
                if (assets[i].path == path)
                {
                    return;
                }
            }
            if (path.IsDirectory())
            {
                LoopAdd(path, "");
            }
            else
            {
                if (fileassets.Contains(path) || AssetBuildSetting.IsIgnorePath(path)) return;
                fileassets.Add(path);
            }
            for (int i = fileassets.Count - 1; i >= 0; i--)
            {
                var _path = fileassets[i];
                var dir = Path.GetDirectoryName(_path).ToRegularPath();
                var finds = assets.Find(s => s.path == _path);
                if (finds != null)
                {
                    fileassets.RemoveAt(i);
                    continue;
                }
                finds = assets.Find(s => dir == s.path);
                if (finds != null)
                {
                    assets.Add(new AssetInfo() { path = _path, parentPath = dir });
                    fileassets.RemoveAt(i);
                    continue;
                }

            }

        }
        private void LoopAdd(string path, string parrent)
        {
            AssetInfo info = new AssetInfo();
            info.path = path;
            info.parentPath = parrent;
            if (string.IsNullOrEmpty(parrent))
                rootAssets.Add(info);
            assets.Add(info);
            string[] dirs = AssetBuildSetting.GetDirectories(path);
            foreach (var item in dirs)
            {
                LoopAdd(item.ToRegularPath(), path);
            }
            string[] files = AssetBuildSetting.GetFiles(path);
            foreach (var item in files)
            {
                AddPath(item);
            }
        }

        public void Remove(string path)
        {
            path = path.ToRegularPath();
            rootAssets.RemoveAll(x => x.path == path);
            assets.RemoveAll(x => x.path == path);
            assets.RemoveAll(x =>
            {
                if (x.parentPath == path)
                {
                    Remove(x.path);
                }
                return false;
            });

        }

        public void CollectDps()
        {
            for (int i = 0; i < assets.Count; i++)
            {
                var asset = assets[i];
                if (!asset.path.IsDirectory())
                {
                    string[] paths = AssetDatabase.GetDependencies(asset.path, true);

                    for (int j = 0; j < paths.Length; j++)
                    {
                        var path = paths[j].ToRegularPath();
                        if (path != asset.path)
                        {
                            path = path.ToRegularPath();
                            if (!AssetBuildSetting.IsIgnorePath(path))
                            {
                                if (!asset.dps.Contains(path) && !path.IsDirectory())
                                    asset.dps.Add(path);
                                AddPath(path.ToRegularPath());
                            }
                        }
                    }

                }
            }
        }

        public List<AssetInfo> GetAssets()
        {
            return assets;
        }
        public List<string> GetDps(string path)
        {
            var asset = assets.Find(x => x.path == path);
            if (asset != null) return asset.dps;
            return null;
        }
    }
}
