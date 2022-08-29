/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.146
 *UnityVersion:   2018.4.17f1
 *Date:           2020-04-02
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System;

namespace IFramework.Tweens
{
    public interface IPlugin<T> where T : struct
    {
        T start { get; set; }
        T end { get; set; }
        Action<T> setter { get; set; }
        Func<T> getter { get; set; }
        bool snap { get; set; }
        float duration { get; set; }
        void Config(T start, T end, float duration, Func<T> getter, Action<T> setter, bool snap);
    }
}
