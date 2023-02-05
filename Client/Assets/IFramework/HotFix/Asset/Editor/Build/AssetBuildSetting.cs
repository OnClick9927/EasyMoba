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
using System.Linq;
using UnityEngine;
using UnityEditor;
using System;

namespace IFramework.Hotfix.Asset
{
    class AssetBuildSetting : ScriptableObject
    {
        public bool fastMode = true;
        private static string buildTarget
        {
            get
            {
                switch (EditorUserBuildSettings.activeBuildTarget)
                {
                    case BuildTarget.Android:
                        return "Android";
                    case BuildTarget.StandaloneWindows:
                    case BuildTarget.StandaloneWindows64:
                        return "Windows";
                    case BuildTarget.iOS:
                        return "iOS";
                    case BuildTarget.WebGL:
                        return "WebGL";
                    default:
                        return "";
                }
            }
        }

        public static string outputPath
        {
            get
            {
                string path = "Assets/../DLC/";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path = path.CombinePath(buildTarget);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return path;
            }
        }
        private static string stoPath { get { return EditorEnvPath.projectMemoryPath.CombinePath("AssetBuildSetting.asset"); } }

        public BuildAssetBundleOptions option;
        public static AssetBuildSetting Load()
        {
            if (File.Exists(stoPath))
                return EditorTools.AssetTool.Load<AssetBuildSetting>(stoPath);
            return EditorTools.AssetTool.CreateScriptableObject<AssetBuildSetting>(stoPath);
        }

        public List<string> ignoreFileEtend = new List<string>() {
            ".cs",
            ".meta"
        };
        [SerializeField] private List<string> atlasPaths = new List<string>();
        [SerializeField] private List<string> buildPaths = new List<string>();
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


        public List<string> GetAtlasPaths()
        {
            return atlasPaths;
        }
        public static string[] GetDirectories(string path)
        {
            return Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly)
                .Where(path => { return !IsIgnorePath(path); }).ToArray();
        }
        public static bool IsIgnorePath(string path)
        {
            var list = path.ToRegularPath().Split('/').ToList();
            if (!list.Contains("Assets") || list.Contains("Editor") || list.Contains("Resources")) return true;
            AssetBuildSetting setting = Load();
            for (int i = 0; i < setting.ignoreFileEtend.Count; i++)
            {
                if (path.EndsWith(setting.ignoreFileEtend[i]))
                {
                    return true;
                }
            }
            return false;
        }
        public static string[] GetFiles(string path)
        {
            var paths = Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly);
            var list = paths.ToList();
            list.RemoveAll(s =>
            {
                return IsIgnorePath(s);
            });
            return list.ToArray();
        }




        public void Colllect()
        {
            //AssetDatabase.ForceReserializeAssets();
            tree.Clear();
            for (int i = 0; i < buildPaths.Count; i++)
            {
                tree.AddPath(buildPaths[i]);
            }
            tree.CollectDps();
            tree.RemoveUselessInfos();
        }
        public void Save()
        {
            EditorTools.AssetTool.Update(this);
        }
    }
}
