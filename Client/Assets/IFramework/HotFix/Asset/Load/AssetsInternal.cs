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
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace IFramework.Hotfix.Asset
{
    public partial class AssetsInternal
    {
        private static BundleMap bundles;
        private static AssetMap assets;
        private static AssetsSetting setting;
        private static string buildTarget;
        private static AssetManifest manifest;
        public static bool isNormalMode { get { return mode == null; } }
        public static string downloadDirectory;
        private static IAssetMode _defaultMode = new NomalAssetMode();
        public static IAssetMode mode;

        static AssetsInternal()
        {
            switch (Application.platform)
            {
                case RuntimePlatform.Android: buildTarget = "Android"; break;
                case RuntimePlatform.WindowsPlayer: buildTarget = "Windows"; break;
                case RuntimePlatform.IPhonePlayer: buildTarget = "iOS"; break;
                case RuntimePlatform.WebGLPlayer: buildTarget = "WebGL"; break;
            }
            downloadDirectory = Application.persistentDataPath.CombinePath("DLC");
            Ex.MakeDirectoryExist(downloadDirectory);
            bundles = new BundleMap();
            assets = new AssetMap();
        }

        private static IAssetMode GetAssetMode()
        {
            if (mode == null)
                return _defaultMode;
            return mode;
        }
        private static Asset CreateAsset(string assetPath, List<Asset> dps, AssetLoadArgs arg)
        {
            return GetAssetMode().CreateAsset(assetPath, dps, arg);
        }
        private static SceneAsset CreateSceneAsset(string assetPath, List<Asset> dps, SceneAssetLoadArgs arg)
        {
            return GetAssetMode().CreateSceneAsset(assetPath, dps, arg);
        }
        private static FileCheckType GetFileCheckType()
        {
            return setting.GetFileCheckType();
        }
        public static int GetWebRequestTimeout()
        {
            return setting.GetWebRequestTimeout();
        }
        private static void CheckSetting()
        {
            if (setting == null)
                LogError("setting is null");
        }
        private static string GetUrlFromBundleName(string bundleName)
        {
            CheckSetting();
            return setting.GetUrlByBundleName(buildTarget, bundleName);
        }
        private static string GetVersionUrl()
        {
            CheckSetting();
            return setting.GetVersionUrl();
        }
        private static string GetBundleLocalPath(string bundleName)
        {
            return downloadDirectory.CombinePath(bundleName);
        }
        private static string[] GetLocalBundles()
        {
            var files = Directory.GetFiles(downloadDirectory);
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = files[i].ToRegularPath();
            }
            return files;
        }


        private static bool IsManifestNull()
        {
            return manifest == null;
        }
        private static List<string> GetAssetDps(string assetpath)
        {
            return IsManifestNull() ? null : manifest.GetAssetDependences(assetpath);
        }
        private static string GetBundleNameByAssetPath(string assetPath)
        {

            string bundleName = manifest.GetBundle(assetPath);
            return bundleName;
        }
        public static IReadOnlyList<string> GetAllAssetPaths()
        {
            return GetAssetMode().GetAllAssetPaths();
        }




        private static Bundle LoadBundleAsync(string bundleName, uint crc = 0u, ulong offset = 0uL)
        {
            string filePath = GetBundleLocalPath(bundleName);
            if (!File.Exists(filePath))
                return LoadBundleFromWebRequest(GetUrlFromBundleName(bundleName), crc);
            Bundle bundle = bundles.LoadAsync(filePath, crc, offset);
            return bundle;
        }
        private static Bundle LoadBundleFromWebRequest(string url, uint crc = 0u)
        {
            Bundle bundle = bundles.RequestLoadAsync(url, crc);
            return bundle;
        }
        private static Bundle LoadTargetBundle(string assetPath)
        {
            string bundleName = GetBundleNameByAssetPath(assetPath);
            return LoadBundleAsync(bundleName);
        }
        private static void ReleseBundleByAssetPath(string assetpath)
        {
            if (IsManifestNull()) return;
            string bundle = GetBundleNameByAssetPath(assetpath);
            bundles.Release(bundle);
        }

        private static void LoadDps(string path)
        {
            List<string> dps = GetAssetDps(path);
            if (dps != null)
            {
                foreach (var item in dps)
                {
                    LoadAssetAsync(item);
                }
            }
        }



        public static void SetAssetsSetting(AssetsSetting setting)
        {
            AssetsInternal.setting = setting;
        }


        public static Asset LoadAssetAsync(string path)
        {
            LoadDps(path);
            Asset asset = assets.LoadAssetAyync(path);
            return asset;
        }
        public static SceneAsset LoadSceneAssetAsync(string path)
        {
            LoadDps(path);
            SceneAsset asset = assets.LoadSceneAssetAsync(path);
            return asset;
        }

        public static void Release(Asset asset)
        {
            assets.Release(asset.path);
        }


        public static void LogError(string err)
        {
            Debug.LogError("Assets : " + err);
        }
        public static string GetMd5(string str)
        {
            MD5CryptoServiceProvider md5CSP = new MD5CryptoServiceProvider();
            byte[] retVal = md5CSP.ComputeHash(Encoding.Default.GetBytes(str));
            string retStr = "";

            for (int i = 0; i < retVal.Length; i++)
            {
                retStr += retVal[i].ToString("x2");
            }

            return retStr;
        }
        public static string GetFileMD5(string path)
        {
            if (!File.Exists(path))
                return "";

            MD5CryptoServiceProvider md5CSP = new MD5CryptoServiceProvider();
            FileStream file = new FileStream(path, FileMode.Open);
            byte[] retVal = md5CSP.ComputeHash(file);
            file.Close();
            string result = "";

            for (int i = 0; i < retVal.Length; i++)
            {
                result += retVal[i].ToString("x2");
            }

            return result;
        }
    }
}
