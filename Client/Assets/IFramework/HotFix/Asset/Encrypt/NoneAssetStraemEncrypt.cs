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
    public class NoneAssetStraemEncrypt : IAssetStraemEncrypt
    {
        public byte[] DeCode(string bundleName, byte[] buffer)
        {
            return buffer;
        }

        public byte[] EnCode(string bundleName, byte[] buffer)
        {
            return buffer;
        }
    }
}
