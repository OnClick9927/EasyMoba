/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2017.2.3p3
 *Date:           2021-06-27
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System;
using System.Collections.Generic;

namespace IFramework.UI
{
    public class MixedGroups : IGroups
    {
        private readonly IGroups[] _groups;
        private Dictionary<string, IGroups> _nameMap;
        public MixedGroups(IGroups[] groups)
        {
            this._groups = groups;
            _nameMap = new Dictionary<string, IGroups>();
        }

        void IDisposable.Dispose()
        {
            for (int i = 0; i < _groups.Length; i++)
            {
                _groups[i].Dispose();
            }
        }


        void IGroups.OnClose(string name)
        {
            if (_nameMap.ContainsKey(name))
            {
                _nameMap[name].OnClose(name);
            }
            else
            {
                Log.E("the panel have not subscribe  panel name :" + name);
            }
        }

        void IGroups.OnHide(string name)
        {
            if (_nameMap.ContainsKey(name))
            {
                _nameMap[name].OnHide(name);
            }
            else
            {
                Log.E("the panel have not subscribe  panel name :" + name);
            }
        }

        void IGroups.OnShow(string name)
        {
            if (_nameMap.ContainsKey(name))
            {
                _nameMap[name].OnShow(name);
            }
            else
            {
                Log.E("the panel have not subscribe  panel name :" + name);
            }
        }

        public void OnLoad(string name)
        {
            if (_nameMap.ContainsKey(name))
            {
                _nameMap[name].OnLoad(name);
            }
            else
            {
                Log.E("the panel have not subscribe  panel name :" + name);
            }
        }

        bool IGroups.Subscribe(UIPanel panel)
        {
            bool sucess = false;
            for (int i = 0; i < _groups.Length; i++)
            {
                sucess |= _groups[i].Subscribe(panel);
                if (sucess)
                {
                    if (_nameMap.ContainsKey(panel.name))
                    {
                        Log.E("Same name, can't Subscribe the panel with name " + panel.name);
                        return false;
                    }
                    _nameMap[panel.name] = _groups[i];
                    break;
                }
            }
            if (!sucess)
            {
                Log.E("can't Subscribe the panel with name " + panel.name);
            }
            return sucess;
        }

        bool IGroups.UnSubscribe(UIPanel panel)
        {
            string name = panel.name;
            if (_nameMap.ContainsKey(name))
            {
                return _nameMap[name].UnSubscribe(panel);
            }
            else
            {
                Log.E("the panel have not subscribe  panel name :" + name);
                return false;
            }
        }

    }
}
