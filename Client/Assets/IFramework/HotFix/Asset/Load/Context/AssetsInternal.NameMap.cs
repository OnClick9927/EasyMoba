﻿/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.179
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-07
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

using System.Collections.Generic;

namespace IFramework.Hotfix.Asset
{
    partial class AssetsInternal
    {
        private abstract class NameMap<T, V> where T : Asset<V>, IAsset
        {
            private IAssetLife<T> listen;

            public void SetListen(IAssetLife<T> listen)
            {
                this.listen = listen;
            }
            

            private RefenceMap<T> refs = new RefenceMap<T>();

            private Dictionary<string, T> map = new Dictionary<string, T>();
            public T Find(string name)
            {
                T result = null;
                map.TryGetValue(name, out result);
                return result;
            }
            protected abstract T CreateNew(string name, IEventArgs args);

            protected T LoadAsync(string name, IEventArgs args)
            {
                T result = Find(name);
                if (result == null)
                {
                    result = CreateNew(name, args);
                    listen?.OnAssetCreate(name, result);
                    map.Add(name, result);
                    (result as IAsset).LoadAsync();
                }
                refs.Retain(result);
                listen?.OnAssetRetain(result, GetRefCount(result));
                return result;
            }
            public abstract void Release(string name);

            protected int GetRefCount(T t)
            {
                return refs.GetCount(t);
            }
            protected int ReleaseRef(T t)
            {
                var count = refs.Release(t);
                listen?.OnAssetRelease(t, count);
                return count;
            }

            protected List<string> GetZeroRefKeys(List<string> result)
            {
                result.Clear();
                foreach (var item in map)
                    if (GetRefCount(item.Value) == 0) result.Add(item.Key);
                return result;
            }
            protected void TryRealUnlod(string path)
            {
                T asset = Find(path);
                if (GetRefCount(asset) != 0) return;
                (asset as IAsset).UnLoad();
                map.Remove(path);
                listen?.OnAssetUnload(path, asset);
            }
        }
    }
}
