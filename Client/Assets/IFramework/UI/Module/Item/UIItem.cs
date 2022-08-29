/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2017.2.3p3
 *Date:           2019-07-02
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System;
using UnityEngine;
namespace IFramework.UI
{
    public class UIItem
    {
        public UIModule.ItemPool pool;
        private GameObject _gameObject;
        public Action completed;
        public GameObject gameObject { get { return _gameObject; } }
        public bool isDone
        {
            get
            {
                if (!pool.isDone) return false;
                if (_gameObject == null)
                {
                    _gameObject = UnityEngine.GameObject.Instantiate(pool.prefab);
                    completed?.Invoke();
                }
                return true;
            }
        }
        public UIItem(UIModule.ItemPool pool)
        {
            this.pool = pool;
        }
    }


}
