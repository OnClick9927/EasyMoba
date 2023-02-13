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
        private abstract class NameMap<T, V> where T : Asset<V>, IAsset
        {
            protected RefenceMap<T> refs = new RefenceMap<T>();

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
            protected abstract T CreateNew(string name, IEventArgs args);

            protected T LoadAsync(string name, IEventArgs args)
            {
                T result = null;
                if (!map.TryGetValue(name, out result))
                {
                    result = CreateNew(name, args);
                    map.Add(name, result);
                    (result as IAsset).LoadAsync();
                }
                refs.Retain(result);
                return result;
            }
            public abstract void Release(string name);
        }
    }
}
