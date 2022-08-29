/*********************************************************************************
 *Author:         OnClick
 *Version:        1.0
 *UnityVersion:   2020.3.3f1c1
 *Date:           2022-08-03
 *Description:    Description
 *History:        2022-08-03--
*********************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using IFramework;

namespace IFramework.UI.MVC
{
    public class MvcGroups : IGroups
    {
        private Dictionary<string, UIView> _views = new Dictionary<string, UIView>();

        private Dictionary<string, Type> _typemap;

        public MvcGroups(Dictionary<string, Type>[] maps)
        {
            _typemap = new Dictionary<string, Type>();
            foreach (var item in maps)
            {
                foreach (var _item in item)
                {
                    this._typemap.Add(_item.Key, _item.Value);
                }
            }
        }

        public void Dispose()
        {
        }
        private UIView FindView(string name)
        {
            if (!_views.ContainsKey(name))
                return null;
            return _views[name];
        }

        void IGroups.OnClose(string name)
        {
            (FindView(name) as IViewEventHandler).OnClose();
        }

        void IGroups.OnHide(string name)
        {
            (FindView(name) as IViewEventHandler).OnHide();
        }

        void IGroups.OnLoad(string name)
        {
            (FindView(name) as IViewEventHandler).OnLoad();

        }

        void IGroups.OnShow(string name)
        {
            (FindView(name) as IViewEventHandler).OnShow();

        }

        public bool Subscribe(UIPanel panel)
        {
            var _view = FindView(panel.name);
            if (_view != null)
            {
                Log.E(string.Format("Have Subscribe Panel Name: {0} ready", panel.name));
                return false;
            }
            Type viewType;
            if (!_typemap.TryGetValue(panel.name, out viewType))
            {
                return false;
            }
            _view = Activator.CreateInstance(viewType) as UIView;
            _view.panel = panel;
            _views.Add(panel.name, _view);
            return true;
        }

        public bool UnSubscribe(UIPanel panel)
        {
            var group = FindView(panel.name);
            if (group != null)
            {
                _views.Remove(panel.name);
                return true;
            }
            return false;
        }
    }
}
