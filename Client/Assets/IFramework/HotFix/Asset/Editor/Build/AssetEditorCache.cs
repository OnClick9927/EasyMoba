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
using static IFramework.Hotfix.Asset.AssetsBuild;

namespace IFramework.Hotfix.Asset
{
    class AssetEditorCache : ScriptableObject
    {
        private static string stoPath { get { return EditorEnvPath.projectMemoryPath.CombinePath("AssetEditorCache.asset"); } }
        public static AssetEditorCache Load()
        {
            if (File.Exists(stoPath))
                return EditorTools.AssetTool.Load<AssetEditorCache>(stoPath);
            return EditorTools.AssetTool.CreateScriptableObject<AssetEditorCache>(stoPath);
        }
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
        }
        public void Save()
        {
            EditorTools.AssetTool.Update(this);
        }

        public List<AssetGroup> previewBundles = new List<AssetGroup>();

    }
}
