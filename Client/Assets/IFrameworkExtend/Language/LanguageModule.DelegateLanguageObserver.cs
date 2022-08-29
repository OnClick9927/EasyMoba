/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.11f1
 *Date:           2019-09-01
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System;
using UnityEngine;

namespace IFramework.Language
{
    public partial class LanguageModule
    {
        class DelegateLanguageObserver : IDelegateLanguageObserver, ILanguageObserver
        {
            public string languageKey { get; private set; }
            public ILanguageModule module { get { return _module; } }

            private bool _disposed;
            private bool _paused;
            private string value;
            private Action<string> _onValueChange;
            private ILanguageModule _module;

            public void Listen(SystemLanguage languageType, string value)
            {
                this.value = value;
                if (_disposed || _paused) return;
                InvokeListen();
            }
            private void InvokeListen()
            {
                if (_onValueChange != null)
                {
                    _onValueChange.Invoke(value);
                }
            }
            void ILanguageObserver.SetValue(ILanguageModule module, string key)
            {
                this._module = module;
                this.languageKey = key;
                _disposed = false;
                UnPause();
            }
            public IDelegateLanguageObserver Listen(Action<string> listen)
            {
                _onValueChange += listen;
                InvokeListen();
                return this;
            }

            public void Pause()
            {
                _paused = true;
            }
            public void UnPause()
            {
                _paused = false;
                InvokeListen();
            }
            public void Dispose()
            {
                Pause();
                _disposed = true;
                _onValueChange = null;
                _module.UnSubscribe(this);
            }


        }
    }
}
