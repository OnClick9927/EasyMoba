/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.318
 *UnityVersion:   2018.4.17f1
 *Date:           2020-06-01
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

using System;
using IFramework.UI;

namespace IFramework.Hotfix.Lua
{
    public class LuaGroups : IGroups
    {
        public event Action onDispose;
        public event Func<UIPanel, bool> onSubscribe;
        public event Func<UIPanel, bool> onUnSubscribe;
        public event Action<string> onLoad;
        public event Action<string> onShow;
        public event Action<string> onHide;
        public event Action<string> onClose;

        void IDisposable.Dispose()
        {
            if (onDispose != null)
            {
                onDispose();
            }
            onDispose = null;
            onSubscribe = null;
            onUnSubscribe = null;
        }

        void IGroups.OnLoad(string panel) => onLoad?.Invoke(panel);
        void IGroups.OnClose(string name) => onClose?.Invoke(name);
        void IGroups.OnHide(string name)=> onHide?.Invoke(name);
        void IGroups.OnShow(string name) => onShow?.Invoke(name);
        bool IGroups.Subscribe(UIPanel panel) => onSubscribe != null ? onSubscribe(panel) : false;
        bool IGroups.UnSubscribe(UIPanel panel) => onUnSubscribe != null ? onUnSubscribe(panel) : false;
    }

}
