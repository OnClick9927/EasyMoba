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
using UnityEditor;
namespace IFramework.Hotfix.Asset
{
    [System.Serializable]
    public class AssetInfo
    {
        public string path;
        public string parentPath;
        public List<string> dps = new List<string>();

        public bool IsDirectory()
        {
            return path.IsDirectory();
        }
        public Texture2D GetMiniThumbnail()
        {
            return GetMiniThumbnail(path);
        }
        public bool IsTexture()
        {
            AssetImporter importer = AssetImporter.GetAtPath(path);
            return importer is TextureImporter;
        }
        public bool IsShader()
        {
            AssetImporter importer = AssetImporter.GetAtPath(path);
            return importer is ShaderImporter;
        }
        public bool IsVideoClip()
        {
            AssetImporter importer = AssetImporter.GetAtPath(path);
            return importer is VideoClipImporter;
        }
        public bool IsAudioClip()
        {
            AssetImporter importer = AssetImporter.GetAtPath(path);
            return importer is AudioImporter;
        }
        public bool IsScene()
        {
            return path.EndsWith(".unity");
        }
        public bool IsMaterial()
        {
            return path.EndsWith(".prefab");
        }
        public bool IsPrefab()
        {
            return path.EndsWith(".mat");
        }
        public bool IsSpriteAtlas()
        {
            return path.EndsWith(".spriteatlas");
        }

        public bool IsModel()
        {
            AssetImporter importer = AssetImporter.GetAtPath(path);
            return importer is ModelImporter;
        }
        public bool IsFont()
        {
            AssetImporter importer = AssetImporter.GetAtPath(path);
            return importer is TrueTypeFontImporter;
        }
        public bool IsAnimation()
        {
            return path.EndsWith(".ani");
        }
        public bool IsScriptObject()
        {
            return path.EndsWith(".asset");
        }
        public long Length()
        {
            FileInfo fi = new FileInfo(path);
            return fi.Length;
        }

        public static Texture2D GetMiniThumbnail(string path)
        {
            return AssetPreview.GetMiniThumbnail(AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(path));
        }
    }
}
