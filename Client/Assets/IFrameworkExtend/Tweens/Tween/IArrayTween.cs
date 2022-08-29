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
    public interface IArrayTween<T> : ITween<T> where T : struct
    {
        void Config(T[] array, float duration, Func<T> getter, Action<T> setter,bool snap);
    }
}
