/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.179
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-07
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

using System;

namespace IFramework.Hotfix.Asset
{
    public abstract class AssetOperation 
    {
        public bool isDone { get; private set; }

        public abstract float progress { get; }

        private string _err;
        public string error { get { return _err; } }

        public event Action completed;

        protected void InvokeComplete()
        {
            isDone = true;
            completed?.Invoke();
        }
        protected void SetErr(string err)
        {
            _err = err;
            AssetsInternal.LogError(err);
        }

        public void WaitForComplete()
        {
            while (!isDone)
            {

            }
        }
    }
}
