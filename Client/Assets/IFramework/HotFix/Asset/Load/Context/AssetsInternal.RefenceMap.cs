/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.179
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-07
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

using System.Collections.Generic;
using System.IO;

namespace IFramework.Hotfix.Asset
{
    partial class AssetsInternal
    {
        public class RefenceMap<T>
        {
            private Dictionary<T, int> map = new Dictionary<T, int>();
            public void Retain(T t)
            {
                if (!map.ContainsKey(t))
                {
                    map.Add(t, 0);
                }
                map[t] = map[t] + 1;
            }

            public int Release(T t)
            {
                if (!map.ContainsKey(t))
                {
                    map.Add(t, 0);
                }
                var count = map[t] - 1;
                if (count <= 0)
                    map.Remove(t);
                else
                    map[t] = count;
                return count;
            }
            public int GetCount(T t)
            {
                int count = 0;
                map.TryGetValue(t, out count);
                return count;
            }
        }
    }
}
