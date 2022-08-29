/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.146
 *UnityVersion:   2018.4.17f1
 *Date:           2020-04-02
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

namespace IFramework.Tweens
{
    class BoolTweenValue : TweenValue<bool>
    {
        protected override void MoveNext()
        {
            if (percent == 1)
            {
                SetCurrent(end);
            }
        }
    }
}
