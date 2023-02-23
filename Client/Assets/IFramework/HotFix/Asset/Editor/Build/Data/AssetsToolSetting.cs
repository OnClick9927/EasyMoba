/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.204
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-09
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEditor;
using UnityEngine;

namespace IFramework.Hotfix.Asset
{
    class AssetsToolSetting : AssetsScriptableObject
    {
        public bool fastMode = true;
        public string shaderVariantDirectory; 
        public List<string> atlasPaths = new List<string>();

        [System.Serializable]
        public class PackingSetting
        {
            public int blockOffset = 1;
            public bool enableRotation = false;
            public bool enableTightPacking = false;
            public int padding = 2;
        }
        [System.Serializable]
        public class TextureSetting
        {
            public bool readable = false;
            public bool generateMipMaps = false;
            public bool sRGB = true;
            public FilterMode filterMode = FilterMode.Bilinear;
            public int anisoLevel = 1;
        }
        public SpriteAtlasPackingSettings GetPackingSetting()
        {
            return new SpriteAtlasPackingSettings()
            {
                blockOffset = packSetting.blockOffset,
                enableRotation = packSetting.enableRotation,
                enableTightPacking = packSetting.enableTightPacking,
                padding = packSetting.padding,
            };
        }
        public SpriteAtlasTextureSettings GetTextureSetting()
        {
            return new SpriteAtlasTextureSettings()
            {
                readable = textureSetting.readable,
                generateMipMaps = textureSetting.generateMipMaps,
                filterMode = textureSetting.filterMode,
                anisoLevel = textureSetting.anisoLevel,
                sRGB = textureSetting.sRGB,
            };
        }
        public PackingSetting packSetting = new PackingSetting();


        public TextureSetting textureSetting = new TextureSetting();


        public TextureImporterPlatformSettings PlatformSetting = new TextureImporterPlatformSettings()
        {
            maxTextureSize = 2048,
            format = TextureImporterFormat.Automatic,
            crunchedCompression = true,
            textureCompression = TextureImporterCompression.Compressed,
            compressionQuality = 50,
        };


    }
}
