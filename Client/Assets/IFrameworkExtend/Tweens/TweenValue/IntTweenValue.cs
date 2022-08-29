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
    class IntTweenValue : TweenValue<int>
    {
        protected override void MoveNext()
        {
            float dest = Mathf.Lerp(start, end, convertPercent);
            SetCurrent((int)Mathf.Lerp(pluginValue, dest, deltaPercent));
        }
    }
}
