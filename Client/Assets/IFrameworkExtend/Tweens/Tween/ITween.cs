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
    public interface ITween
    {
        bool recyled { get; }
        ITweenCurve converter { get; set; }
        int loop { get; set; }
        bool autoRecyle { get; set; }
        LoopType loopType { get; set; }
        bool snap { get; set; }
        void Complete(bool invoke);
        void ReStart();
        void Rewind(float duration, bool snap = false);
        ITween SetConverter(ITweenCurve converter);
    }
    public interface ITween<T> : ITween where T : struct
    {
        T end { get; set; }
        T start { get; set; }
    }
}
