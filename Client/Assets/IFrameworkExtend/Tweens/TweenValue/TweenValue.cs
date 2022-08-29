/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.146
 *UnityVersion:   2018.4.17f1
 *Date:           2020-04-02
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System;
using UnityEngine;

namespace IFramework.Tweens
{
    public abstract class TweenValue : TweenObject
    {
        public static TweenValue<T> Get<T>(EnvironmentType envType) where T : struct
        {
            Type type = typeof(T);
            if (type == typeof(bool)) return Allocate<BoolTweenValue>(envType) as TweenValue<T>;
            if (type == typeof(int)) return Allocate<IntTweenValue>(envType) as TweenValue<T>;
            if (type == typeof(float)) return Allocate<FloatTweenValue>(envType) as TweenValue<T>;
            if (type == typeof(Vector2)) return Allocate<Vector2TweenValue>(envType) as TweenValue<T>;
            if (type == typeof(Vector3)) return Allocate<Vector3TweenValue>(envType) as TweenValue<T>;
            if (type == typeof(Vector4)) return Allocate<Vector4TweenValue>(envType) as TweenValue<T>;
            if (type == typeof(Color)) return Allocate<ColorTweenValue>(envType) as TweenValue<T>;
            if (type == typeof(Rect)) return Allocate<RectTweenValue>(envType) as TweenValue<T>;
            if (type == typeof(Quaternion)) return Allocate<QuaternionTweenValue>(envType) as TweenValue<T>;
            throw new Exception(string.Format("Do not Have TweenValue<{0}>  with Type {0}", typeof(T)));
        }

        public bool compelete { get { return _compelete; } }
        private ITweenCurve _converter = EaseCurve.Default;
        private float _time;
        protected event Action onCompelete;
        protected float percent { get { return (Mathf.Clamp01((_time) / duration)); } }
        protected float convertPercent { get { return _converter.Evaluate(percent, _time, duration); } }
        protected float deltaPercent { get { return delta + (1 - delta) * percent; } }

        public ITweenCurve converter { get { return _converter; } set { _converter = value; } }
        public abstract float duration { get; }

        public static float delta = 0.618f;
        public static float deltaTime = 0.02f;
        public static float timeScale = 1;
        protected bool _compelete;

        protected abstract void MoveNext();
        protected override void Reset()
        {
            _compelete = false;
            onCompelete = null;
            _time = 0;
            _converter = EaseCurve.Default;
        }

        public void Run()
        {
            TweenDrive container = env.modules.GetModule<TweenDrive>();
            container.Subscribe(this);
        }

        public void Update()
        {
            if (recyled ||_compelete) return;
            _time += deltaTime * timeScale;

            if (_time >= duration)
            {
                OnCompelete();
            }
            else
            {
                MoveNext();
            }
        }
        protected virtual void OnCompelete()
        {
            if (onCompelete != null)
                onCompelete();
            _compelete = true;
        }

    }

    public abstract class TweenValue<T> : TweenValue where T : struct
    {
        private IPlugin<T> _plugin;
        private T _current;

        protected T pluginValue { get { return _plugin.getter.Invoke(); } }

        protected void SetCurrent(T value)
        {
            if (_plugin != null)
            {
                if (_plugin.snap)
                    _current = Snap(value);
                else
                    _current = value;
                if (_plugin.setter != null)
                {
                    _plugin.setter(_current);
                }
            }
        }
        public T end { get { return _plugin.end; } }
        public T start { get { return _plugin.start; } }
        public override float duration { get { return _plugin != null ? _plugin.duration : 0; } }

        protected virtual T Snap(T value) { return value; }
        protected override void Reset()
        {
            base.Reset();
            _plugin = null;
            _current = default(T);
        }

        public void Config(IPlugin<T> plugin, Action onCompelete)
        {
            this._plugin = plugin;
            this._current = plugin.start;
            this.onCompelete += onCompelete;
        }
        public void ResetPlugin()
        {
            _plugin = null;
            _compelete = true;
        }
        protected override void OnCompelete()
        {
            SetCurrent(end);
            base.OnCompelete();
        }

       
    }
}
