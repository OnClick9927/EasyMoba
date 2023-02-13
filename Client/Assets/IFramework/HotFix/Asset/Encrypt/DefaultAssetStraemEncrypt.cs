/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.179
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-07
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

using UnityEngine;

namespace IFramework.Hotfix.Asset
{
    public class DefaultAssetStraemEncrypt : IAssetStraemEncrypt
    {
        public byte[] DeCode(string bundleName, byte[] buffer)
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                byte key = (byte)bundleName[(int)Mathf.Repeat(i, bundleName.Length)];
                buffer[i] ^= key;
            }
            return buffer;
        }

        public byte[] EnCode(string bundleName, byte[] buffer)
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                byte key = (byte)bundleName[(int)Mathf.Repeat(i, bundleName.Length)];
                buffer[i] ^= key;
            }
            return buffer;
        }
    }
}
