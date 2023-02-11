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
using static IFramework.Hotfix.Asset.AssetsBuild;
using static IFramework.Hotfix.Asset.AssetInfo;

namespace IFramework.Hotfix.Asset
{
    public class DefaultCollectAssetBundleBuild : ICollectAssetBundleBuild
    {
        private const int size = 1024 * 1024 * 8;

        private static Dictionary<string, List<AssetInfo>> MakeDirDic(List<AssetInfo> list)
        {
            Dictionary<string, List<AssetInfo>> dic = new Dictionary<string, List<AssetInfo>>();
            foreach (AssetInfo asset in list)
            {
                var dir = asset.parentPath;
                if (!dic.ContainsKey(dir))
                {
                    dic.Add(dir, new List<AssetInfo>());
                }
                dic[dir].Add(asset);
            }
            return dic;
        }
        public static void OneFileBundle(List<AssetInfo> assets, List<AssetGroup> result)
        {
            foreach (var atlas in assets)
            {
                var file_name = Path.GetFileNameWithoutExtension(atlas.path);
                AssetGroup atlasBundle = new AssetGroup(atlas.parentPath.CombinePath(file_name).ToAssetsPath());
                atlasBundle.AddAsset(atlas.path);
                result.Add(atlasBundle);
            }

        }
        public static void AllInOneBundle(List<AssetInfo> assets, string bundleName, List<AssetGroup> result)
        {
            AssetGroup shaderBundle = new AssetGroup(bundleName);
            for (int i = 0; i < assets.Count; i++)
                shaderBundle.AddAsset(assets[i].path);
            result.Add(shaderBundle);
        }

        public static void SizeAndDirBundle(List<AssetInfo> assets, Dictionary<AssetInfo, List<AssetInfo>> dpdic, List<AssetGroup> result)
        {
            var path_dic = MakeDirDic(assets);

            foreach (var item in path_dic)
            {
                string dir = item.Key;
                List<AssetInfo> list = item.Value;
                var find = list.FindAll(x => dpdic[x].Count >= 2);
                foreach (var _find in find) list.Remove(_find);
                OneFileBundle(find, result);
                if (find.Count == list.Count) continue;
                long len = 0;
                List<int> index_list = new List<int>();
                for (int i = 0; i < list.Count; i++)
                {
                    FileInfo fi = new FileInfo(list[i].path);
                    len += fi.Length;
                    if (len > size)
                    {
                        index_list.Add(i);
                        len = 0;
                    }
                }
                if (!index_list.Contains(list.Count - 1)) index_list.Add(list.Count - 1);
                int start = 0;
                for (int i = 0; i < index_list.Count; i++)
                {
                    int end = index_list[i];
                    AssetGroup lastBundle = new AssetGroup(dir.Append($"_{i}"));
                    for (int j = start; j <= end; j++)
                        lastBundle.AddAsset(list[j].path);
                    result.Add(lastBundle);
                    start = end + 1;
                }
            }
        }
        public static void OneFileBundle(List<AssetInfo> assets, AssetType type, List<AssetGroup> result)
        {
            List<AssetInfo> spriteAtlas = assets.FindAll(x => x.type == type);
            assets.RemoveAll(x => x.type == type);
            OneFileBundle(spriteAtlas, result);
        }
        public static void OneDirBundle(List<AssetInfo> assets, AssetType type, Dictionary<AssetInfo, List<AssetInfo>> dic, List<AssetGroup> result)
        {
            List<AssetInfo> spriteAtlas = assets.FindAll(x => x.type == type);
            assets.RemoveAll(x => x.type == type);
            SizeAndDirBundle(spriteAtlas, dic, result);
        }

        public static void TypeAllTFileBundle(List<AssetInfo> assets, AssetType type, List<AssetGroup> result)
        {
            List<AssetInfo> shaders = assets.FindAll(x => x.type == type);
            assets.RemoveAll(x => x.type == type);
            AllInOneBundle(shaders, type.ToString(), result);
        }

        public void Create(List<AssetInfo> assets, List<AssetInfo> singles, Dictionary<AssetInfo, List<AssetInfo>> dic, List<AssetGroup> result)
        {
            OneFileBundle(singles, result);

            TypeAllTFileBundle(assets, AssetType.Shader, result);
            OneDirBundle(assets, AssetType.TextAsset, dic, result);
            OneDirBundle(assets, AssetType.Texture, dic, result);
            OneFileBundle(assets, AssetType.Font, result);
            OneFileBundle(assets, AssetType.Scene, result);
            OneFileBundle(assets, AssetType.SpriteAtlas, result);
            OneFileBundle(assets, AssetType.AudioClip, result);
            OneFileBundle(assets, AssetType.VideoClip, result);
            OneFileBundle(assets, AssetType.Prefab, result);
            OneFileBundle(assets, AssetType.Model, result);
            OneFileBundle(assets, AssetType.Animation, result);
            OneFileBundle(assets, AssetType.ScriptObject, result);
            OneFileBundle(assets, AssetType.Material, result);
            SizeAndDirBundle(assets, dic, result);
        }
    }

}
