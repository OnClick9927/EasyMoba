/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2017.2.3p3
 *Date:           2019-07-02
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System;
using System.Collections.Generic;
using IFramework.MVVM;

namespace IFramework.UI.MVVM
{
    /// <summary>
    /// ui MVVM 组容器
    /// </summary>
    public class MvvmGroups : IGroups
    {
        private MVVMGroups _moudule;
        private Dictionary<string, Tuple<Type, Type, Type>> _map;

        public MvvmGroups(Dictionary<string, Tuple<Type, Type, Type>>[] maps)
        {
            _moudule = new MVVMGroups();
            this._map = new Dictionary<string, Tuple<Type, Type, Type>>();
            foreach (var item in maps)
            {
                foreach (var _item in item)
                {
                    this._map.Add(_item.Key, _item.Value);
                }
            }
        }

        private MVVMGroup FindGroup(string name)
        {
            return _moudule.FindGroup(name);
        }

        bool IGroups.Subscribe(UIPanel panel)
        {
            var _group = FindGroup(panel.name);
            if (_group != null)
            {
                Log.E(string.Format("Have Subscribe Panel Name: {0} ready", panel.name));
                return false;
            }

            Tuple<Type, Type, Type> tuple;
            _map.TryGetValue(panel.name, out tuple);
            if (tuple == null)
            {
                return false;
            }
            var model = Activator.CreateInstance(tuple.Item1) as IModel;

            var view = Activator.CreateInstance(tuple.Item2) as UIView;
            var vm = Activator.CreateInstance(tuple.Item3) as UIViewModel;
            view.panel = panel;

            var group = new MVVMGroup(panel.name, view, vm, model);
            _moudule.AddGroup(group);
            return true;
        }
        bool IGroups.UnSubscribe(UIPanel panel)
        {
            var group = FindGroup(panel.name);
            if (group != null)
            {
                group.Dispose();
                return true;
            }
            return false;
        }
        void IDisposable.Dispose()
        {
            _moudule.Dispose();
        }


        void IGroups.OnShow(string panel)
        {
            (FindGroup(panel).view as IViewEventHandler).OnShow();
        }
        void IGroups.OnHide(string panel)
        {
            (FindGroup(panel).view as IViewEventHandler).OnHide();
        }
        void IGroups.OnClose(string panel)
        {
            (FindGroup(panel).view as IViewEventHandler).OnClose();
        }
        void IGroups.OnLoad(string panel)
        {
            (FindGroup(panel).view as IViewEventHandler).OnLoad();
        }
    }
}
