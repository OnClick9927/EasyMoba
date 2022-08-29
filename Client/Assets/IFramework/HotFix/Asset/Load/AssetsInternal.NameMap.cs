/*********************************************************************************
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
        private abstract class NameMap<T, V> where T : RefenceAsset<V>, IRefenceAsset
        {
            protected Dictionary<string, T> map = new Dictionary<string, T>();
            public T Find(string name)
            {
                T result = null;
                if (!map.TryGetValue(name, out result))
                {
                    return null;
                }
                return result;
            }
            protected T Load(string name, IEventArgs args)
            {
                T result = null;
                if (!map.TryGetValue(name, out result))
                {
                    result = CreateNew(name, args, false);
                    map.Add(name, result);
                    (result as IRefenceAsset).Load();
                }
                result.Retain();
                return result;
            }
            protected abstract T CreateNew(string name, IEventArgs args, bool async);

            protected T LoadAsync(string name, IEventArgs args)
            {
                T result = null;
                if (!map.TryGetValue(name, out result))
                {
                    result = CreateNew(name, args, true);
                    map.Add(name, result);
                    (result as IRefenceAsset).LoadAsync();
                }
                result.Retain();
                return result;
            }

            public int GetCount(string name)
            {
                T result = null;
                if (!map.TryGetValue(name, out result))
                {
                    return 0;
                }
                return result.count;
            }

            public abstract void Release(string name);
        }
    }
}
