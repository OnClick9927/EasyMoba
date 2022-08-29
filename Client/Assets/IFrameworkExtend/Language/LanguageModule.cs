/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.11f1
 *Date:           2019-09-01
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace IFramework.Language
{
    public partial class LanguageModule : Module, ILanguageModule
    {
        private class LanguageObserverPool : BaseTypePool<ILanguageObserver> { }
        private List<LanPair> _pairs;
        private Dictionary<string, List<LanPair>> _keyDic;
        private List<ILanguageObserver> _observers;
        private LanguageObserverPool _pool;
        private SystemLanguage _lan = SystemLanguage.Unknown;

        public SystemLanguage language
        {
            get { return _lan; }
            set
            {
                if (_lan == value) return;
                _lan = value;
                Publish(value);
            }
        }

        public void Subscribe(ILanguageObserver observer)
        {
            _observers.Add(observer);
            var value = GetValue(observer.languageKey, language);
            observer.Listen(_lan, value);
        }
        public void UnSubscribe(ILanguageObserver observer)
        {
            _observers.Remove(observer);
            _pool.Set(observer);
        }
        public T CreateObserver<T>(string key, bool autoStart = true) where T: class,ILanguageObserver,new ()
        {
            var o = _pool.Get<T>();
            o.SetValue(this, key);
            Subscribe(o);
            return o;
        }
        public IDelegateLanguageObserver CreateDelegateObserver(string key)
        {
           return CreateObserver<DelegateLanguageObserver>(key);
        }

        public void Load(List<LanPair> pairs, bool rewrite = true)
        {
            pairs.ForEach((tmpPair) => {
                LanPair pair = _pairs.Find((p) => { return p.lan == tmpPair.lan && p.key == tmpPair.key; });
                if (pair != null && rewrite && pair.value != tmpPair.value)
                    pair.value = tmpPair.value;
                else
                    _pairs.Add(tmpPair);
            });
            //pairs.Clear();
            _keyDic = _pairs.GroupBy(lanPair => { return lanPair.key; }, (key, list) => { return new { key, list }; })
                     .ToDictionary((v) => { return v.key; }, (v) => { return v.list.ToList(); });
        }

        public string GetValue(string key, SystemLanguage language)
        {
            List<LanPair> pairs;
            if (!_keyDic.TryGetValue(key, out pairs))
            {
                return null;
            }
            for (int j = 0; j < pairs.Count; j++)
            {
                var pair = pairs[j];
                if (pair.lan == language)
                {
                    return pair.value;
                }
            }
            return key;
        }
        private void Publish(ILanguageObserver o, SystemLanguage value)
        {
            var _value = GetValue(o.languageKey, value);
            o.Listen(value, _value);
        }
        public void Publish(SystemLanguage value)
        {
            for (int i = 0; i < _observers.Count; i++)
            {
                Publish(_observers[i], value);
            }
        }

        protected override void Awake()
        {
            _pool = new LanguageObserverPool();
            _pairs = new List<LanPair>();
            _observers = new List<ILanguageObserver>();
        }
        protected override void OnDispose()
        {
            _pairs.Clear();
            _observers.Clear();
            _pool.Dispose();
        }
    }
}
