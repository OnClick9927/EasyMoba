/*********************************************************************************
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
using UnityEngine.U2D;
using UnityEditor.U2D;
using System.Linq;
namespace IFramework.Hotfix.Asset
{
    class AssetsBuild
    {
        public static AssetBundleManifest Build(Type collectType)
        {
            var list = ColectAssetBundleBuild(collectType);
            CollectMain(list);
            AssetBuildSetting setting = AssetBuildSetting.Load();
            AssetBundleManifest main = BuildPipeline.BuildAssetBundles(AssetBuildSetting.outputPath, list.ToArray(), setting.option, EditorUserBuildSettings.activeBuildTarget);

            var bundles = main.GetAllAssetBundles();
            AssetsVersion version = new AssetsVersion();
            foreach (var bundle in bundles)
            {
                string path = AssetBuildSetting.outputPath.CombinePath(bundle);
                FileInfo fileInfo = new FileInfo(path);
                AssetsVersion.VersionData data = new AssetsVersion.VersionData();
                data.length = fileInfo.Length;
                data.bundleName = bundle;
                data.md5 = AssetsInternal.GetFileMD5(path);
                version.versions.Add(data);
            }
            version.version = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            var v = JsonUtility.ToJson(version, true);
            File.WriteAllText(AssetBuildSetting.outputPath.CombinePath("version"), v);
            return main;
        }
        static List<AssetBundleBuild> ColectAssetBundleBuild(Type collectType)
        {
            AssetBuildSetting setting = AssetBuildSetting.Load();
            Dictionary<AssetInfo, List<AssetInfo>> dic = setting.GetDpDic();
            List<AssetInfo> all = new List<AssetInfo>(setting.GetAssets());
            List<string> singles = setting.GetSingleFiles();
            all.RemoveAll(x => x.IsDirectory());
            var creater = Activator.CreateInstance(collectType) as ICollectAssetBundleBuild;
            var builds = new List<AssetBundleBuild>();
            creater.Create(all, singles, dic, builds);
            return builds;
        }

        static void CollectMain(List<AssetBundleBuild> builds)
        {
            for (int i = 0; i < builds.Count; i++)
            {
                AssetBundleBuild build = builds[i];
                build.assetBundleName = AssetsInternal.GetMd5(build.assetBundleName);
                builds[i] = build;
            }
            Dictionary<string, string> allAssets = new Dictionary<string, string>();
            Dictionary<string, List<string>> assetdps = new Dictionary<string, List<string>>();

            foreach (var build in builds)
            {
                foreach (var assetPath in build.assetNames)
                {
                    allAssets.Add(assetPath, build.assetBundleName);
                }
            }
            AssetBuildSetting setting = AssetBuildSetting.Load();
            foreach (var item in allAssets)
            {
                var path = item.Key;
                var dps = setting.GetDps(path);
                if (dps != null)
                    assetdps.Add(path, dps);
            }
            if (!File.Exists(AssetManifest.Path))
                EditorTools.AssetTool.CreateScriptableObject<AssetManifest>(AssetManifest.Path);
            AssetManifest main = EditorTools.AssetTool.Load<AssetManifest>(AssetManifest.Path);
            main.Read(allAssets, assetdps);
            EditorTools.AssetTool.Update(main);
            AssetBundleBuild mainbuild = new AssetBundleBuild();
            mainbuild.assetNames = new string[] { AssetManifest.Path };
            mainbuild.assetBundleName = AssetsInternal.GetMd5(AssetManifest.Path);
            builds.Add(mainbuild);
        }

        public static void BuildAtlas()
        {
            AssetBuildSetting setting = AssetBuildSetting.Load();
            var _paths = setting.GetAtlasPaths();
            List<string> paths = new List<string>();
            foreach (var path in _paths)
            {
                paths.Add(path);
                var sub = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
                paths.AddRange(sub);
            }
            paths = paths.Distinct().ToList();
            foreach (var path in paths)
            {
                BuildAtlas(path);
            }
        }
        static List<string> CollectTextures(string directory)
        {
            var png = Directory.GetFiles(directory,"*.png");
            var jpg = Directory.GetFiles(directory,"*.jpg");
            var files = new List<string>(png);
            files.AddRange(jpg);
            return files;
        }
        static void BuildAtlas(string directory)
        {
            var texfiles = CollectTextures(directory);
            if (texfiles.Count <= 0) return;
            SpriteAtlas atlas = new SpriteAtlas();
            // 设置参数 可根据项目具体情况进行设置
            SpriteAtlasPackingSettings packSetting = new SpriteAtlasPackingSettings()
            {
                blockOffset = 1,
                enableRotation = false,
                enableTightPacking = false,
                padding = 2,
            };
            atlas.SetPackingSettings(packSetting);

            SpriteAtlasTextureSettings textureSetting = new SpriteAtlasTextureSettings()
            {
                readable = false,
                generateMipMaps = false,
                sRGB = true,
                filterMode = FilterMode.Bilinear,
            };
            atlas.SetTextureSettings(textureSetting);

            TextureImporterPlatformSettings platformSetting = new TextureImporterPlatformSettings()
            {
                maxTextureSize = 2048,
                format = TextureImporterFormat.Automatic,
                crunchedCompression = true,
                textureCompression = TextureImporterCompression.Compressed,
                compressionQuality = 50,
            };
            atlas.SetPlatformSettings(platformSetting);
            AssetDatabase.CreateAsset(atlas, directory.Append(".spriteatlas"));

            List<Texture> texs = new List<Texture>();
            foreach (var item in texfiles)
            {
                var load = AssetDatabase.LoadAssetAtPath<Texture>(item);
                if (load)
                {
                    texs.Add(load);
                }
            }
            atlas.Add(texs.ToArray());
            EditorUtility.SetDirty(atlas);
            AssetDatabase.Refresh();
        }

    }
}
