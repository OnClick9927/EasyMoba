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
    class QuaternionTweenValue : TweenValue<Quaternion>
    {
        protected override void MoveNext()
        {
            Quaternion dest = Quaternion.Lerp(start, end, convertPercent);
            SetCurrent(Quaternion.Lerp(pluginValue, dest, deltaPercent));
        }
        protected override Quaternion Snap(Quaternion value)
        {
            value.x = Mathf.RoundToInt(value.x);
            value.y = Mathf.RoundToInt(value.y);
            value.z = Mathf.RoundToInt(value.z);
            value.z = Mathf.RoundToInt(value.z);
            return value;
        }
    }

}
