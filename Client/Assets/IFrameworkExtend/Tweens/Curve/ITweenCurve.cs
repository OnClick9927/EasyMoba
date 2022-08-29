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
    public interface ITweenCurve:IRecyclable
    {
        float Evaluate(float percent, float time, float duration);
    }
    public interface ITweenCurve<T> : ITweenCurve
    {
        ITweenCurve Config(T value);
    }
}
