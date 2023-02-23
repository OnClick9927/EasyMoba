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
    class AssetsBuildSetting : AssetsScriptableObject
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
        public string version = "0.0.1";
        public long bundleSize = 8 * 1024 * 1024;
        public bool forceRebuild = false;
        public bool IgnoreTypeTreeChanges = true;

        public List<string> ignoreFileEtend = new List<string>() {
            ".cs",
            ".meta"
        };
        [SerializeField] private List<string> buildPaths = new List<string>();
        [SerializeField] private List<string> tags = new List<string>();
        private void OnEnable()
        {
            encrypt.baseType = typeof(IAssetStraemEncrypt);
            buildGroup.baseType = typeof(ICollectBundle);
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
      

  


        public BuildAssetBundleOptions GetOption()
        {
            BuildAssetBundleOptions opt = BuildAssetBundleOptions.None;
            opt |= BuildAssetBundleOptions.StrictMode;
            if (forceRebuild)
                opt |= BuildAssetBundleOptions.ForceRebuildAssetBundle;
            if (IgnoreTypeTreeChanges)
                opt |= BuildAssetBundleOptions.IgnoreTypeTreeChanges;
            opt |= BuildAssetBundleOptions.DisableLoadAssetByFileName;
            opt |= BuildAssetBundleOptions.DisableLoadAssetByFileNameWithExtension;
            return opt;
        }
        public List<string> GetTags()
        {
            return tags;
        }
        public List<string> GetBuildPaths()
        {
            return buildPaths;
        }
    }
}
