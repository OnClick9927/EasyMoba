/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.146
 *UnityVersion:   2018.4.17f1
 *Date:           2020-04-02
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System;

namespace IFramework.Tweens
{
    public class ArrayTween<T> : Tween, IArrayTween<T> where T: struct 
    {
        private TweenValue<T> value;

        private T _current;
        private T _end;
        private T _start;
        private ITweenCurve _converter = defaultConverter;
        private Action<T> setter;
        private Func<T> getter;
        private int _loop = 1;
        private T[] _array;
        private int _index;
        private int current_loop = 0;




        public T end { get { return _end; } set { _end = value; } }
        public T start { get { return _start; } set { _start = value; } }

        public T current
        {
            get { return _current; }
            set
            {
                _current = value;
                if (setter != null)
                {
                    setter(value);
                }
            }
        }
        public override int loop
        {
            get
            {
                return _loop;
            }
            set
            {
                _loop = value;
            }
        }
        public override ITweenCurve converter
        {
            get { return _converter; }
            set
            {
                _converter = value;
                if (this.value != null)
                {
                    this.value.converter = value;
                }
            }
        }

        public void Config(T[] array, float duration, Func<T> getter, Action<T> setter,bool snap)
        {
            if (array.Length <= 1) throw new Exception("array.lenght  must  >= 2");
            this.snap = snap;
            start = array[0];
            current = start;
            end = array[array.Length - 1];
            this.duration = duration;
            this.getter = getter;
            this.setter = setter;
            this._array = array;
            _index = 0;
        }
        protected override void Reset()
        {
            base.Reset();
            direction = TweenDirection.Forward;
            UnbindTweenValue();
            _array = null;
            _current = _start = _end = default(T);
            duration = 0;
            _index = 0;

            _loop = 1;
            autoRecyle = true;
            if (_converter != defaultConverter)
            {
                _converter.Recyle();
                _converter = defaultConverter;
            }
            loopType = LoopType.ReStart;
            setter = null;
            getter = null;
        }

        private void OnLoopBegin()
        {
            UnbindTweenValue();
            value = TweenValue.Get<T>(env.envType);
            value.converter = converter;
            var plugin = new TweenPlugin<T>();

            switch (direction)
            {
                case TweenDirection.Forward:
                    {
                        T _start = _array[_index];
                        T _end = _array[_index + 1];
                        plugin.Config(_start, _end, duration / (_array.Length - 1), getter, (value) => { current = value; }, snap);
                    }
                    break;
                case TweenDirection.Back:
                    {
                        T _end = _array[_index - 1];
                        T _start = _array[_index];
                        plugin.Config(_start, _end, duration / (_array.Length - 1), getter, (value) => { current = value; }, snap);
                    }
                    break;
                default:
                    break;
            }
            value.Config(plugin, OnLoopEnd);
            value.Run();
        }
        private void OnLoopEnd()
        {
            switch (loopType)
            {
                case LoopType.ReStart:
                    _index++;
                    if (_index >= _array.Length - 1 || _index <= 0)
                    {
                        current_loop--;
                    }
                    _index = (_index) % (_array.Length - 1);
                    direction = TweenDirection.Forward;
                    break;
                case LoopType.PingPong:
                    switch (direction)
                    {
                        case TweenDirection.Forward:
                            _index++;
                            if (_index >= _array.Length - 1)
                            {
                                direction = TweenDirection.Back;
                                current_loop--;
                            }
                            break;
                        case TweenDirection.Back:
                            _index--;
                            if (_index <= 0)
                            {
                                direction = TweenDirection.Forward;
                                current_loop--;
                            }
                            break;
                    }
                    break;
            }
            if (loop != -1 && current_loop <= 0)
            {
                InvokeCompelete();
                RecyleSelf();
            }
            else
            {

                OnLoopBegin();
            }
           
        }

        public override void Run()
        {
            current_loop = loop;
            direction = TweenDirection.Forward;
            OnLoopBegin();
        }



        public override void ReStart()
        {
            _index = 0;
            direction = TweenDirection.Forward;
            UnbindTweenValue();
            Run();
        }

        public override void Rewind(float duration,bool snap=false)
        {
            direction = TweenDirection.Forward;

            UnbindTweenValue();

            value = TweenValue.Get<T>(env.envType);
            value.converter = converter;
            var plugin = new TweenPlugin<T>();
            plugin.Config(current, start, duration, getter,(value) => { current = value; },snap);
            value.Config(plugin, RecyleSelf);
            value.Run();
        }
        public override void Complete(bool invoke)
        {
            direction = TweenDirection.Forward;
            if (invoke) InvokeCompelete();
            RecyleSelf();
        }

        private void RecyleSelf()
        {
            UnbindTweenValue();
            if (autoRecyle)
            {
                Recyle();
            }
        }
        private void UnbindTweenValue()
        {
            if (value != null)
            {
                value.ResetPlugin();
                value = null;
            }

        }

    }
}
