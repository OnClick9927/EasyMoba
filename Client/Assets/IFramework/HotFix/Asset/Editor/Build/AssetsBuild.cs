﻿/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.204
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-09
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;

namespace IFramework.Hotfix.Asset
{
    public partial class AssetsBuild
    {
        static string streamPath
        {
            get
            {

                string path = Application.streamingAssetsPath;
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

        static AssetsToolSetting tool { get { return AssetsToolSetting.Load<AssetsToolSetting>(); } }
        static AssetsBuildSetting setting { get { return AssetsBuildSetting.Load<AssetsBuildSetting>(); } }
        static AssetsEditorCache cache { get { return AssetsEditorCache.Load<AssetsEditorCache>(); } }
        static List<string> GetAllFilesIncludeList(string directory, List<string> exName, List<string> result)
        {
            DirectoryInfo root = new DirectoryInfo(directory);
            FileInfo[] files = root.GetFiles();
            for (int i = 0; i < exName.Count; i++) exName[i] = exName[i].ToLower();
            string ex;
            for (int i = 0; i < files.Length; i++)
            {
                ex = Path.GetExtension(files[i].FullName).ToLower();
                if (exName.IndexOf(ex) < 0) continue;
                result.Add(files[i].FullName.ToRegularPath());
            }
            DirectoryInfo[] dirs = root.GetDirectories();
            if (dirs.Length > 0)
            {
                for (int i = 0; i < dirs.Length; i++)
                {
                    GetAllFilesIncludeList(dirs[i].FullName, exName, result);
                }
            }

            return result;

        }
        static void RemoveMetaFiles(string outputPath)
        {
            List<string> file_paths = GetAllFilesIncludeList(outputPath, new List<string>() { ".meta", ".manifest" }, new List<string>());
            for (int i = 0; i < file_paths.Count; i++)
            {
                string file = file_paths[i];
                File.Delete(file);
            }
        }
        static void Encrypt(string outputPath, string[] bundles)
        {
            Type type = setting.GetStreamEncryptType();
            IAssetStraemEncrypt en = Activator.CreateInstance(type) as IAssetStraemEncrypt;
            foreach (var abPath in bundles)
            {
                string filepath = outputPath.CombinePath(abPath);
                var data = File.ReadAllBytes(filepath);
                File.WriteAllBytes(filepath, en.EnCode(abPath, data));
            }

        }
        static void BuildVersion(string outputPath, string version_txt, string[] bundles)
        {
            AssetsVersion version = new AssetsVersion();
            foreach (var bundle in bundles)
            {
                string path = outputPath.CombinePath(bundle);
                FileInfo fileInfo = new FileInfo(path);
                AssetsVersion.VersionData data = new AssetsVersion.VersionData();
                data.length = fileInfo.Length;
                data.bundleName = bundle;
                data.md5 = AssetsInternal.GetFileMD5(path);
                version.versions.Add(data);
            }
            version.version = version_txt;
            var v = JsonUtility.ToJson(version, true);
            File.WriteAllText(outputPath.CombinePath("version"), v);
        }
        public static void Build()
        {
            string outputPath = AssetsBuild.outputPath;
            BuildAssetBundleOptions option = setting.GetOption();
            string version_txt = setting.version;

            var list = CollectBundleGroup();
            CollectMain(list);
            AssetBundleManifest main = BuildPipeline.BuildAssetBundles(outputPath, list.ConvertAll(x =>
            {
                return new AssetBundleBuild()
                {
                    assetBundleName = x.name,
                    assetNames = x.assets.ToArray()
                };
            }).ToArray(), option, EditorUserBuildSettings.activeBuildTarget);

            var bundles = main.GetAllAssetBundles();
            RemoveMetaFiles(outputPath);
            Encrypt(outputPath, bundles);
            BuildVersion(outputPath, version_txt, bundles);
        }
        public static void CopyToStreamPath()
        {
            AssetsInternal.CopyDirectory(outputPath, streamPath);
            AssetDatabase.Refresh();
        }
        public static List<BundleGroup> CollectBundleGroup()
        {
            Type collectType = setting.GetBuildGroupType();
            Dictionary<AssetInfo, List<AssetInfo>> dic = cache.GetDpDic();
            List<AssetInfo> assets = new List<AssetInfo>(cache.GetAssets());
            assets.AddRange(cache.GetSingleFiles());
            assets.RemoveAll(x => x.type == AssetInfo.AssetType.Directory);
            assets.RemoveAll(x => x.path == AssetManifest.Path);
            var creater = Activator.CreateInstance(collectType) as ICollectBundle;
            var builds = new List<BundleGroup>();
            creater.Create(assets, dic, builds);
            builds.RemoveAll(x => x.assets.Count == 0);
            builds.Sort((a, b) =>
            {
                return a.length > b.length ? -1 : 1;
            });
            return builds;
        }
        public static List<BundleGroup> CollectMain(List<BundleGroup> builds)
        {
            for (int i = 0; i < builds.Count; i++)
            {
                BundleGroup build = builds[i];
                build.name = AssetsInternal.GetMd5(build.name);
            }
            Dictionary<string, string> allAssets = new Dictionary<string, string>();
            Dictionary<string, List<string>> assetdps = new Dictionary<string, List<string>>();

            foreach (var build in builds)
            {
                foreach (var assetPath in build.assets)
                {
                    allAssets.Add(assetPath, build.name);
                }
            }
            foreach (var item in allAssets)
            {
                var path = item.Key;
                var dps = cache.GetDps(path);
                if (dps != null)
                    assetdps.Add(path, dps);
            }
            if (!File.Exists(AssetManifest.Path))
                EditorTools.AssetTool.CreateScriptableObject<AssetManifest>(AssetManifest.Path);
            AssetManifest main = EditorTools.AssetTool.Load<AssetManifest>(AssetManifest.Path);
            main.Read(allAssets, assetdps, cache.GetTagDic());
            EditorTools.AssetTool.Update(main);
            BundleGroup mainbuild = new BundleGroup(AssetsInternal.GetMd5(AssetManifest.Path));
            mainbuild.AddAsset(AssetManifest.Path);
            builds.Add(mainbuild);
            return builds;
        }
        public static void OpenOutputFloder()
        {
            EditorTools.OpenFolder(outputPath);
        }
        public static void ClearOutputFloder()
        {
            Directory.Delete(outputPath, true);
        }


        public static string[] GetLegalDirectories(string path)
        {
            return Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly)
                .Where(path => { return !IsIgnorePath(path); }).ToArray();
        }
        public static bool IsIgnorePath(string path)
        {
            var list = path.ToRegularPath().Split('/').ToList();
            if (!list.Contains("Assets") || list.Contains("Editor") || list.Contains("Resources")) return true;
            for (int i = 0; i < setting.ignoreFileEtend.Count; i++)
            {
                if (path.EndsWith(setting.ignoreFileEtend[i]))
                {
                    return true;
                }
            }
            return false;
        }
        public static string[] GetLegalFiles(string path)
        {
            var paths = Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly);
            var list = paths.ToList();
            list.RemoveAll(s =>
            {
                return IsIgnorePath(s);
            });
            return list.ToArray();
        }
    }
}
