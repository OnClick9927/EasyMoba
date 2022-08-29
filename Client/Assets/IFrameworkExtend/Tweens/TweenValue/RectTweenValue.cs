/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.146
 *UnityVersion:   2018.4.17f1
 *Date:           2020-04-02
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using UnityEngine;

namespace IFramework.Tweens
{
    class RectTweenValue : TweenValue<Rect>
    {
        private static Rect Lerp(Rect r, Rect a, Rect b, float t)
        {
            r.x = Mathf.Lerp(a.x, b.x, t);
            r.y = Mathf.Lerp(a.y, b.y, t);
            r.width = Mathf.Lerp(a.width, b.width, t);
            r.height = Mathf.Lerp(a.height, b.height, t);
            return r;
        }
        protected override void MoveNext()
        {
            Rect dest = Lerp(start,start, end, convertPercent);
            SetCurrent(Lerp(start, pluginValue, dest, deltaPercent));
        }

        protected override Rect Snap(Rect value)
        {
            value.x = Mathf.RoundToInt(value.x);
            value.y = Mathf.RoundToInt(value.y);
            value.width = Mathf.RoundToInt(value.width);
            value.height = Mathf.RoundToInt(value.height);
            return value;
        }
    }

}
