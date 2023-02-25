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
    partial class AssetsInternal
    {
        public interface IAssetLife<T> where T : IAsset
        {
            void OnAssetCreate(string path, T asset);
            void OnAssetRetain(T asset, int count);
            void OnAssetRelease(T asset, int count);
            void OnAssetUnload(string path, T asset);
        }
    }
}
