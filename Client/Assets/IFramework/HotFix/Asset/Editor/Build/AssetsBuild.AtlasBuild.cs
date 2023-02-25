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
using UnityEngine.U2D;
using UnityEditor.U2D;
using System.Linq;

namespace IFramework.Hotfix.Asset
{

    public partial class AssetsBuild
    {
        public static class AtlasBuild
        {
            public static void Run()
            {
                var _paths = tool.atlasPaths;
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
            static void BuildAtlas(string directory)
            {
                var texfiles = AssetDatabase.FindAssets("t:texture", new[] { directory });
                if (texfiles.Length <= 0) return;
                SpriteAtlas atlas = new SpriteAtlas();
                atlas.SetPlatformSettings(tool.PlatformSetting);
                atlas.SetTextureSettings(tool.GetTextureSetting());
                atlas.SetPackingSettings(tool.GetPackingSetting());
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
}
