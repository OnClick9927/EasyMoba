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
using static IFramework.Hotfix.Asset.AssetsInternal;

namespace IFramework.Hotfix.Asset
{

    public partial class AssetsBuild
    {
        static AssetBuildSetting setting { get { return AssetBuildSetting.Load(); } }
        static AssetEditorCache cache { get { return AssetEditorCache.Load(); } }
        private static List<string> GetAllFilesIncludeList(string directory, List<string> exName, List<string> result)
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

        private static void RemoveMetaFiles(string outputPath)
        {
            List<string> file_paths = GetAllFilesIncludeList(outputPath, new List<string>() { ".meta", ".manifest" }, new List<string>());
            for (int i = 0; i < file_paths.Count; i++)
            {
                string file = file_paths[i];
                File.Delete(file);
            }
        }


        private static void Encrypt(string outputPath, string[] bundles)
        {
            if (!setting.encrypt) return;
            foreach (var abPath in bundles)
            {
                string filepath = outputPath.CombinePath(abPath);
                var data = File.ReadAllBytes(filepath);

                using (var myStream = new EncryptStream(abPath,filepath, FileMode.Create))
                {
                    myStream.Write(data, 0, data.Length);
                }
            }

        }

        private static void BuildVersion(string outputPath, string version_txt, string[] bundles)
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
            string outputPath = setting.outputPath;
            BuildAssetBundleOptions option = setting.option;
            string version_txt = setting.version;

            var list = ColectAssetGroup();
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
            string outputPath = setting.outputPath;
            string streamPath = setting.streamPath;
            AssetsInternal.CopyDirectory(outputPath, streamPath);
            AssetDatabase.Refresh();
        }
        public static List<AssetGroup> ColectAssetGroup()
        {
            Type collectType = setting.GetBuildGroupType();
            Dictionary<AssetInfo, List<AssetInfo>> dic = cache.GetDpDic();
            List<AssetInfo> all = new List<AssetInfo>(cache.GetAssets());
            List<AssetInfo> singles = cache.GetSingleFiles();
            all.RemoveAll(x => x.type == AssetInfo.AssetType.Directory);
            var creater = Activator.CreateInstance(collectType) as ICollectAssetGroup;
            var builds = new List<AssetGroup>();
            creater.Create(all, singles, dic, builds);
            builds.RemoveAll(x => x.assets.Count == 0);
            builds.Sort((a, b) =>
            {
                return a.length > b.length ? -1 : 1;
            });
            return builds;
        }

        static void CollectMain(List<AssetGroup> builds)
        {
            for (int i = 0; i < builds.Count; i++)
            {
                AssetGroup build = builds[i];
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
            main.Read(allAssets, assetdps);
            EditorTools.AssetTool.Update(main);
            AssetGroup mainbuild = new AssetGroup(AssetsInternal.GetMd5(AssetManifest.Path));
            mainbuild.AddAsset(AssetManifest.Path);
            builds.Add(mainbuild);
        }

        public static void BuildAtlas()
        {
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
            var png = Directory.GetFiles(directory, "*.png");
            var jpg = Directory.GetFiles(directory, "*.jpg");
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
        public static void OpenOutputFloder()
        {
            EditorTools.OpenFolder(setting.outputPath);
        }
        public static void ClearOutputFloder()
        {
            Directory.Delete(setting.outputPath, true);
        }
    }
}
