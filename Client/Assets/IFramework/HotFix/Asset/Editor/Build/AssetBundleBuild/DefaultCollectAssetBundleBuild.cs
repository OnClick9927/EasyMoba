/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.204
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-09
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

namespace IFramework.Hotfix.Asset
{
    public class DefaultCollectAssetBundleBuild : ICollectAssetBundleBuild
    {
        private Dictionary<string, List<AssetInfo>> Collect(List<AssetInfo> list)
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
        public void Create(List<AssetInfo> assets, List<AssetInfo> singles, Dictionary<AssetInfo, List<AssetInfo>> dic, List<AssetBundleBuild> result)
        {
            List<AssetInfo> shaders = assets.FindAll(x => x.type==  AssetInfo.AssetType.Shader);
            List<AssetInfo> textures = assets.FindAll(x => x.type == AssetInfo.AssetType.Texture);
            List<AssetInfo> audioClips = assets.FindAll(x => x.type== AssetInfo.AssetType.AudioClip);
            List<AssetInfo> videos = assets.FindAll(x => x.type== AssetInfo.AssetType.VideoClip);
            List<AssetInfo> scenes = assets.FindAll(x => x.type == AssetInfo.AssetType.Scene);
            List<AssetInfo> mats = assets.FindAll(x => x.type == AssetInfo.AssetType.Material);
            List<AssetInfo> prefabs = assets.FindAll(x => x.type == AssetInfo.AssetType.Prefab);
            List<AssetInfo> models = assets.FindAll(x => x.type == AssetInfo.AssetType.Model);
            List<AssetInfo> fonts = assets.FindAll(x => x.type == AssetInfo.AssetType.Font);
            List<AssetInfo> animations = assets.FindAll(x => x.type == AssetInfo.AssetType.Animation);
            List<AssetInfo> stos = assets.FindAll(x => x.type == AssetInfo.AssetType.ScriptObject);
            List<AssetInfo> spriteAtlas = assets.FindAll(x => x.type == AssetInfo.AssetType.SpriteAtlas);
            List<AssetInfo> txts = assets.FindAll(x => x.type == AssetInfo.AssetType.TextAsset);


            foreach (var item in txts) assets.Remove(item);
            foreach (var item in shaders) assets.Remove(item);
            foreach (var item in textures) assets.Remove(item);
            foreach (var item in audioClips) assets.Remove(item);
            foreach (var item in videos) assets.Remove(item);
            foreach (var item in scenes) assets.Remove(item);
            foreach (var item in mats) assets.Remove(item);
            foreach (var item in prefabs) assets.Remove(item);
            foreach (var item in models) assets.Remove(item);
            foreach (var item in fonts) assets.Remove(item);
            foreach (var item in animations) assets.Remove(item);
            foreach (var item in stos) assets.Remove(item);
            foreach (var item in spriteAtlas) assets.Remove(item);


            var txtDic = Collect(txts);
            var textureDic = Collect(textures);
            var lastDic = Collect(assets);
            var matDic = Collect(mats);


            AssetBundleBuild shaderBundle = new AssetBundleBuild();
            shaderBundle.assetBundleName = "shaders";
            shaderBundle.assetNames = new string[shaders.Count];
            for (int i = 0; i < shaders.Count; i++)
                shaderBundle.assetNames[i] = shaders[i].path;
            result.Add(shaderBundle);

        
            foreach (var item in textureDic)
            {
                string dir = item.Key;
                List<AssetInfo> list = item.Value;
                AssetBundleBuild textureBundle = new AssetBundleBuild();
                textureBundle.assetBundleName = dir;
                textureBundle.assetNames = new string[list.Count];
                for (int i = 0; i < list.Count; i++) textureBundle.assetNames[i] = list[i].path;
                result.Add(textureBundle);
            }
            foreach (var item in txtDic)
            {
                string dir = item.Key;
                List<AssetInfo> list = item.Value;
                AssetBundleBuild txtBundle = new AssetBundleBuild();
                txtBundle.assetBundleName = dir;
                txtBundle.assetNames = new string[list.Count];
                for (int i = 0; i < list.Count; i++) txtBundle.assetNames[i] = list[i].path;
                result.Add(txtBundle);
            }
            foreach (var item in matDic)
            {
                string dir = item.Key;
                List<AssetInfo> list = item.Value;
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    var asset = list[i];
                    int count = dic[asset].Count;
                    if (count >= 2)
                    {
                        AssetBundleBuild matBundle = new AssetBundleBuild();
                        matBundle.assetBundleName = asset.path;
                        matBundle.assetNames = new string[] { asset.path };
                        result.Add(matBundle);
                        list.RemoveAt(i);
                    }
                }
                if (list.Count > 0)
                {
                    AssetBundleBuild matBundle = new AssetBundleBuild();
                    matBundle.assetBundleName = dir;
                    matBundle.assetNames = new string[list.Count];
                    for (int i = 0; i < list.Count; i++) matBundle.assetNames[i] = list[i].path;
                    result.Add(matBundle);
                }
            }


            foreach (var atlas in spriteAtlas)
            {
                AssetBundleBuild atlasBundle = new AssetBundleBuild();
                atlasBundle.assetBundleName = atlas.path;
                atlasBundle.assetNames = new string[] { atlas.path };
                result.Add(atlasBundle);
            }
            foreach (var scene in scenes)
            {
                AssetBundleBuild sceneBundle = new AssetBundleBuild();
                sceneBundle.assetBundleName = scene.path;
                sceneBundle.assetNames = new string[] { scene.path };
                result.Add(sceneBundle);
            }
            foreach (var audio in audioClips)
            {
                AssetBundleBuild audioBundle = new AssetBundleBuild();
                audioBundle.assetBundleName = audio.path;
                audioBundle.assetNames = new string[] { audio.path };
                result.Add(audioBundle);
            }
            foreach (var video in videos)
            {
                AssetBundleBuild videoBundle = new AssetBundleBuild();
                videoBundle.assetBundleName = video.path;
                videoBundle.assetNames = new string[] { video.path };
                result.Add(videoBundle);
            }
            foreach (var prefab in prefabs)
            {
                AssetBundleBuild prefabBundle = new AssetBundleBuild();
                prefabBundle.assetBundleName = prefab.path;
                prefabBundle.assetNames = new string[] { prefab.path };
                result.Add(prefabBundle);
            }
            foreach (var model in models)
            {
                AssetBundleBuild modelBundle = new AssetBundleBuild();
                modelBundle.assetBundleName = model.path;
                modelBundle.assetNames = new string[] { model.path };
                result.Add(modelBundle);
            }
            foreach (var animation in animations)
            {
                AssetBundleBuild animationBundle = new AssetBundleBuild();
                animationBundle.assetBundleName = animation.path;
                animationBundle.assetNames = new string[] { animation.path };
                result.Add(animationBundle);
            }
            foreach (var sto in stos)
            {
                AssetBundleBuild stoBundle = new AssetBundleBuild();
                stoBundle.assetBundleName = sto.path;
                stoBundle.assetNames = new string[] { sto.path };
                result.Add(stoBundle);
            }

       

           
            foreach (var item in lastDic)
            {
                string dir = item.Key;
                List<AssetInfo> list = item.Value;
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    var asset = list[i];
                    int count = dic[asset].Count;
                    if (count >= 2)
                    {
                        AssetBundleBuild lastBundle = new AssetBundleBuild();
                        lastBundle.assetBundleName = asset.path;
                        lastBundle.assetNames = new string[] { asset.path };
                        result.Add(lastBundle);
                        list.RemoveAt(i);
                    }
                }
                if (list.Count > 0)
                {
                    long len = 0;
                    AssetBundleBuild lastBundle = new AssetBundleBuild();
                    lastBundle.assetBundleName = dir.Append("_0");
                    List<string> paths = new List<string>();
                    for (int i = 0; i < list.Count; i++)
                    {
                        lastBundle.assetBundleName = dir;
                        len += list[i].fileLength;
                        if (len > 1024 * 1024 * 8)
                        {
                            lastBundle.assetNames = paths.ToArray();
                            result.Add(lastBundle);
                            lastBundle = new AssetBundleBuild();
                            lastBundle.assetBundleName = dir.Append($"_{i}");
                            len = 0;
                            paths.Clear();
                        }
                        else
                        {
                            paths.Add(list[i].path);
                        }
                    }
                    lastBundle.assetNames = paths.ToArray();
                    result.Add(lastBundle);
                }
            }
            foreach (var single in singles)
            {
                var path = single.path.ToRegularPath();
                AssetBundleBuild singleBundle = new AssetBundleBuild();
                singleBundle.assetBundleName = path;
                singleBundle.assetNames = new string[] { path };
                result.Add(singleBundle);
            }
        }
    }

}
