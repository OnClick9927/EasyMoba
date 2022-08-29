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
    public abstract class TweenObject
    {
        private EnvironmentType envType;
        protected IEnvironment env;
        private bool _recyled = true;
        public bool recyled { get { return _recyled; } }
        public static T Allocate<T>(EnvironmentType envType) where T : TweenObject
        {
            T t = Framework.GlobalAllocate<T>();
            t.envType = envType;
            t.env = Framework.GetEnv(envType);
            t._recyled = false;
            return t;
        }
        protected abstract void Reset();
        public void Recyle()
        {
            if (recyled) return;
            Reset();
            _recyled = true;
            this.GlobalRecyle();
        }
    }
}