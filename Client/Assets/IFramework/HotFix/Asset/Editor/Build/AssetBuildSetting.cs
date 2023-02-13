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
using Application = UnityEngine.Application;

namespace IFramework.Hotfix.Asset
{

    class AssetBuildSetting : ScriptableObject
    {
        public class TypeSelect
        {
            public string[] types;
            public string[] shortTypes;
            public int typeIndex;
            public Type baseType;
            public void Enable()
            {
                types = baseType.GetSubTypesInAssemblys()
               .Where(type => !type.IsAbstract)
               .Select(type => type.FullName).ToArray();
                shortTypes = baseType.GetSubTypesInAssemblys()
                      .Where(type => !type.IsAbstract)
                      .Select(type => type.Name).ToArray();
            }
            public Type GetSelectType()
            {
                var type_str = types[typeIndex];
                Type type = baseType.GetSubTypesInAssemblys()
                   .Where(type => !type.IsAbstract)
                   .ToList()
                   .Find(x => x.FullName == type_str);

                return type;
            }
        }
        public TypeSelect buildGroup = new TypeSelect();
        public TypeSelect encrypt = new TypeSelect();

        private void OnEnable()
        {
            encrypt.baseType = typeof(IAssetStraemEncrypt);
            buildGroup.baseType = typeof(ICollectAssetGroup);
            buildGroup.Enable();
            encrypt.Enable();
        }
        public Type GetBuildGroupType()
        {
            return buildGroup.GetSelectType();
        }
        public Type GetStreamEncryptType()
        {
            return encrypt.GetSelectType();
        }
        public bool fastMode = true;
        public string version = "0.0.1";

        public string streamPath
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

        public string outputPath
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
        public List<string> GetBuildPaths()
        {
            return buildPaths;
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


        public void Save()
        {
            EditorTools.AssetTool.Update(this);
        }
    }
}
