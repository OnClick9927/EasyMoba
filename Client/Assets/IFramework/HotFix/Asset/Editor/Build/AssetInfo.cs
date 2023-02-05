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
        [System.Serializable]
        public enum AssetType
        {
            None,
            Directory,
            Texture,
            Shader,
            VideoClip,
            AudioClip,
            Scene,
            Material,
            Prefab,
            Font,
            Animation,
            SpriteAtlas,
            ScriptObject,
            Model,
            TextAsset,
        }
        [SerializeField] private string _path;
        [SerializeField] private string _parentPath;
        [SerializeField] private AssetType _type;
        public long FileLength
        {
            get
            {
                FileInfo fi = new FileInfo(path);
                return fi.Length;
            }
        }

        public AssetType type { get { return _type; } }
        public string path { get { return _path; } }
        public string parentPath { get { return _parentPath; } }
        public AssetInfo(string path, string parentPath)
        {
            this._path = path;
            this._parentPath = parentPath;
            if (path.IsDirectory())
            {
                _type = AssetType.Directory;
            }
            else
            {
                AssetImporter importer = AssetImporter.GetAtPath(path);
                if (importer is TextureImporter) _type = AssetType.Texture;
                else if (importer is ShaderImporter) _type = AssetType.Shader;
                else if (importer is VideoClipImporter) _type = AssetType.VideoClip;
                else if (importer is AudioImporter) _type = AssetType.AudioClip;
                else if (importer is ModelImporter) _type = AssetType.Model;
                else if (importer is TrueTypeFontImporter) _type = AssetType.Font;
                else if (AssetDatabase.LoadAssetAtPath<TextAsset>(path) != null) _type = AssetType.TextAsset;
                else if (path.EndsWith(".unity")) _type = AssetType.Scene;
                else if (path.EndsWith(".mat")) _type = AssetType.Material;
                else if (path.EndsWith(".prefab")) _type = AssetType.Prefab;
                else if (path.EndsWith(".spriteatlas")) _type = AssetType.SpriteAtlas;
                else if (path.EndsWith(".ani")) _type = AssetType.Animation;
                else if (path.EndsWith(".asset")) _type = AssetType.ScriptObject;



            }
        }
        public List<string> dps = new List<string>();


    }
}
