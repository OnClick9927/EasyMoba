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
    public abstract class RefenceAsset<T> : AssetOperation, IRefenceAsset
    {
        private int _count;
        int IRefenceAsset.count => _count;
        public T value { get; private set; }
        void IRefenceAsset.Load()
        {
            OnLoad(false);
        }
        void IRefenceAsset.LoadAsync()
        {
            OnLoad(true);
        }
        void IRefenceAsset.UnLoad()
        {
            OnUnLoad();
        }
        void IRefenceAsset.Retain()
        {
            _count++;
        }
        void IRefenceAsset.Release()
        {
            _count--;
        }


        protected abstract void OnUnLoad();
        protected abstract void OnLoad(bool async);

        protected void SetResult(T value)
        {
            this.value = value;
            InvokeComplete();
        }

    }
}
