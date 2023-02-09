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

        private static IAssetMode _defaultMode = new NomalAssetMode();
        private static IAssetMode _mode;
        public static bool isNormalMode => _mode == null;
        public static IAssetMode mode
        {
            get
            {
                return _mode;
            }
            set
            {
                if (_mode != value)
                {
                    _mode = value;
                    string dir = _mode.GetLocalBundleSaveDirectory();
                    Ex.MakeDirectoryExist(dir);
                }
            }
        }


        static AssetsInternal()
        {
            switch (Application.platform)
            {
                case RuntimePlatform.Android: buildTarget = "Android"; break;
                case RuntimePlatform.WindowsPlayer: buildTarget = "Windows"; break;
                case RuntimePlatform.IPhonePlayer: buildTarget = "iOS"; break;
                case RuntimePlatform.WebGLPlayer: buildTarget = "WebGL"; break;
            }
            mode = _defaultMode;
            bundles = new BundleMap();
            assets = new AssetMap();
        }



    }
    public partial class AssetsInternal
    {

        private static string GetlocalSaveDirectory() => _mode.GetLocalBundleSaveDirectory();
        private static Asset CreateAsset(string assetPath, List<Asset> dps, AssetLoadArgs arg) => mode.CreateAsset(assetPath, dps, arg);
        private static SceneAsset CreateSceneAsset(string assetPath, List<Asset> dps, SceneAssetLoadArgs arg) => mode.CreateSceneAsset(assetPath, dps, arg);
        public static IReadOnlyList<string> GetAllAssetPaths() => mode.GetAllAssetPaths();



        public static void SetAssetsSetting(AssetsSetting setting) => AssetsInternal.setting = setting;
        private static void CheckSetting()
        {
            if (setting == null)
                LogError("setting is null");
        }
        private static int GetWebRequestTimeout()
        {
            CheckSetting();
            return setting.GetWebRequestTimeout();
        }
        public static FileCheckType GetFileCheckType()
        {
            CheckSetting();
            return setting.GetFileCheckType();
        }
        public static string GetUrlFromBundleName(string bundleName)
        {
            CheckSetting();
            return setting.GetUrlByBundleName(buildTarget, bundleName);
        }
        public static string GetVersionUrl()
        {
            CheckSetting();
            return setting.GetVersionUrl();
        }





        public static string GetBundleLocalPath(string bundleName) => GetlocalSaveDirectory().CombinePath(bundleName);
        public static string[] GetLocalBundles()
        {
            var files = Directory.GetFiles(GetlocalSaveDirectory());
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = files[i].ToRegularPath();
            }
            return files;
        }


        private static bool IsManifestNull() => manifest == null;



        private static Bundle LoadBundleAsync(string bundleName, uint crc = 0u, ulong offset = 0uL)
        {
            string filePath = GetBundleLocalPath(bundleName);
            if (!File.Exists(filePath))
                return bundles.RequestLoadAsync(GetUrlFromBundleName(bundleName), crc, offset);
            return bundles.LoadAsync(filePath, crc, offset);
        }

        private static string GetBundleNameByAssetPath(string assetPath) => manifest.GetBundle(assetPath);
        private static Bundle LoadBundleByAssetPath(string assetPath)
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
        private static List<string> GetAssetDps(string assetpath)
        {
            return IsManifestNull() ? null : manifest.GetAssetDependences(assetpath);
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
