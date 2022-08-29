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
    class ColorTweenValue : TweenValue<Color>
    {
        protected override void MoveNext()
        {
            Color dest = Color.Lerp(start, end, convertPercent);
            SetCurrent(Color.Lerp(pluginValue, dest, deltaPercent));
        }
        protected override Color Snap(Color value)
        {
            value.a = Mathf.RoundToInt(value.a);
            value.r = Mathf.RoundToInt(value.r);
            value.g = Mathf.RoundToInt(value.g);
            value.b = Mathf.RoundToInt(value.b);
            return value;
        }
    }

}
