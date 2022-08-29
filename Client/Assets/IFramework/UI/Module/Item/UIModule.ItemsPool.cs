/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2017.2.3p3
 *Date:           2019-07-02
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System;
using System.Collections.Generic;
using UnityEngine;
namespace IFramework.UI
{
    public partial class UIModule
    {
        public class ItemsPool
        {
            private Dictionary<string, ItemPool> pools = new Dictionary<string, ItemPool>();
            private UIModule module;
            private Dictionary<string, List<UIItem>> works = new Dictionary<string, List<UIItem>>();
            public ItemsPool(UIModule module)
            {
                this.module = module;
            }
            public UIItem Get(string path)
            {
                UIItem item;
                if (pools.ContainsKey(path))
                    item = pools[path].Get();
                else
                    item = LoadPrefab(path);
                if (!works.ContainsKey(path))
                    works.Add(path, new List<UIItem>());
                if (!works[path].Contains(item))
                    works[path].Add(item);
                return item;
            }
            private UIItem LoadPrefab(string path)
            {
                var _loader = module._asset;
                LoadItemAsyncOperation op = new LoadItemAsyncOperation();
                op.path = path;
                ItemPool pool = new ItemPool(op, module);
                pools.Add(path, pool);
                if (_loader.LoadItemAsync(path, op))
                {
                    return pool.Get();
                }
                throw new Exception($"can not load {path}");
            }
            public void Set(string path, UIItem item)
            {
                if (works.ContainsKey(path))
                {
                    works[path].Remove(item);
                }
                pools[path].Set(item);
            }
            public void Set(string path, GameObject go)
            {
                if (works.ContainsKey(path))
                {
                    var item = works[path].Find((_item) => { return _item.gameObject == go; });
                    Set(path, item);
                }
            }
            public void Clear()
            {
                foreach (var item in pools.Values)
                {
                    item.Dispose();
                }
                works.Clear();
                foreach (var item in pools.Keys)
                {
                    module._asset.ReleaseItemAsset(item);
                }
            }


            Queue<ItemPool> clear = new Queue<ItemPool>();
            public void ClearUseless()
            {
                foreach (var item in pools.Keys)
                {
                    if (!works.ContainsKey(item))
                    {
                        clear.Enqueue(pools[item]);
                    }
                }
                while (clear.Count != 0)
                {
                    var pool = clear.Dequeue();
                    pools.Remove(pool.path);
                    pool.Dispose();
                    module._asset.ReleaseItemAsset(pool.path);
                }
            }
        }

    }


}
