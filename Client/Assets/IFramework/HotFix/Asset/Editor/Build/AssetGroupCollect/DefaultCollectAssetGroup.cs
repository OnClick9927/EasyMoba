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
    public class DefaultCollectAssetGroup : ICollectAssetGroup
    {
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

        public static void SizeBundle(string baseName, List<AssetInfo> assets, Dictionary<AssetInfo, List<AssetInfo>> dpdic, List<AssetGroup> result)
        {
            var find = assets.FindAll(x => dpdic[x].Count >= 2);
            assets.RemoveAll(x => dpdic[x].Count >= 2);
            OneFileBundle(find, result);
            if (find.Count == assets.Count) return;

            long size = AssetBuildSetting.Load().bundleSize;
            var tmp = assets.ConvertAll(x => { return new { info = x, length = new FileInfo(x.path).Length }; });
            var _find = tmp.FindAll(x => x.length >= size);
            OneFileBundle(_find.ConvertAll(x => x.info), result);
            tmp.RemoveAll(x => x.length >= size);


            tmp.Sort((a, b) =>
            {
                return a.length < b.length ? 1 : -1;
            });
            Dictionary<int, List<string>> dic = new Dictionary<int, List<string>>();
            int index = 0;
            long len = 0;
            for (int i = 0; i < tmp.Count; i++)
            {
                len += tmp[i].length;
                if (len >= size)
                {
                    len = 0;
                    index++;
                }
                if (!dic.ContainsKey(index)) dic[index] = new List<string>();
                dic[index].Add(tmp[i].info.path);
            }

            foreach (var _index in dic)
            {
                AssetGroup lastBundle = new AssetGroup(baseName.Append($"_{_index.Key}"));
                foreach (var path in _index.Value)
                {
                    lastBundle.AddAsset(path);
                }
                result.Add(lastBundle);
            }
        }
        public static void SizeAndDirBundle(List<AssetInfo> assets, Dictionary<AssetInfo, List<AssetInfo>> dpdic, List<AssetGroup> result)
        {
            var path_dic = MakeDirDic(assets);
            foreach (var item in path_dic)
            {
                SizeBundle(item.Key, item.Value, dpdic, result);
            }
        }
        public static void OneFileBundle(List<AssetInfo> assets, AssetType type, List<AssetGroup> result)
        {
            List<AssetInfo> spriteAtlas = assets.FindAll(x => x.type == type);
            assets.RemoveAll(x => x.type == type);
            OneFileBundle(spriteAtlas, result);
        }
        public static void OneDirTopBundle(List<AssetInfo> assets, AssetType type, Dictionary<AssetInfo, List<AssetInfo>> dic, List<AssetGroup> result)
        {
            List<AssetInfo> spriteAtlas = assets.FindAll(x => x.type == type);
            assets.RemoveAll(x => x.type == type);
            SizeAndDirBundle(spriteAtlas, dic, result);
        }
        public static void TypeSizeBundle(List<AssetInfo> assets, AssetType type, Dictionary<AssetInfo, List<AssetInfo>> dic, List<AssetGroup> result)
        {
            List<AssetInfo> spriteAtlas = assets.FindAll(x => x.type == type);
            assets.RemoveAll(x => x.type == type);
            SizeBundle(type.ToString(), spriteAtlas, dic, result);
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
            TypeSizeBundle(assets, AssetType.TextAsset, dic, result);
            OneDirTopBundle(assets, AssetType.Texture, dic, result);
            OneFileBundle(assets, AssetType.Font, result);
            OneFileBundle(assets, AssetType.Scene, result);
            OneFileBundle(assets, AssetType.SpriteAtlas, result);
            OneFileBundle(assets, AssetType.AudioClip, result);
            OneFileBundle(assets, AssetType.VideoClip, result);
            OneFileBundle(assets, AssetType.Prefab, result);
            OneFileBundle(assets, AssetType.Model, result);
            OneFileBundle(assets, AssetType.Animation, result);
            OneFileBundle(assets, AssetType.ScriptObject, result);
            OneDirTopBundle(assets, AssetType.Material, dic, result);
            SizeAndDirBundle(assets, dic, result);
        }
    }

}
