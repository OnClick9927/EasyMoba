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
    public interface ISingleTween<T>:ITween<T> where T : struct
    {
        void Config(T start, T end, float duration, Func<T> getter, Action<T> setter,bool snap);
    }
}
