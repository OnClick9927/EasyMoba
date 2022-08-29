/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2017.2.3p3
 *Date:           2019-07-02
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

using System;

namespace IFramework.UI
{
    public class UIAsyncOperation<T>
    {
        public Action<T> callback;
        public T value;
        public bool _isDone = false;

        public bool isDone { get { return _isDone; } }

        protected void SetToDefault()
        {
            callback = null;
            value = default(T);
            _isDone = false;
        }
        public void SetValue(T value)
        {
            this.value = value;
            _isDone = true;
        }
    }
}
