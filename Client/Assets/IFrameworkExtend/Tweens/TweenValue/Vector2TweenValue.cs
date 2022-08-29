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
    class Vector2TweenValue : TweenValue<Vector2>
    {
        protected override void MoveNext()
        {
            Vector2 dest = Vector2.Lerp(start, end, convertPercent);
            SetCurrent(Vector2.Lerp(pluginValue, dest, deltaPercent));
        }
        protected override Vector2 Snap(Vector2 value)
        {
            value.x = Mathf.RoundToInt(value.x);
            value.y = Mathf.RoundToInt(value.y);
            return value;
        }
    }

}
