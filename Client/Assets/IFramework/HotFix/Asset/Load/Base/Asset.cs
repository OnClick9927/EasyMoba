/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.179
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-07
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

namespace IFramework.Hotfix.Asset
{
    public abstract class Asset<T> : AssetOperation, IAsset
    {
        public T value { get; private set; }

        void IAsset.LoadAsync()
        {
            OnLoad();
        }
        void IAsset.UnLoad()
        {
            OnUnLoad();
        }

        protected abstract void OnUnLoad();
        protected abstract void OnLoad();

        protected void SetResult(T value)
        {
            this.value = value;
            InvokeComplete();
        }

    }
}
