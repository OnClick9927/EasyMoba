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
    public interface IRefenceAsset
    {
        int count
        {
            get;
        }

        void Retain();

        void Release();
        void Load();
        void UnLoad();
        void LoadAsync();
    }
}
