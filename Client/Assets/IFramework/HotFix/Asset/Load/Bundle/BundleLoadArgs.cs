/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.179
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-07
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

using System.IO;
namespace IFramework.Hotfix.Asset
{
    public struct BundleLoadArgs : IEventArgs
    {
        public BundleLoadType type;
        public string path;
        public uint crc;
        public ulong offset;

        public BundleLoadArgs(BundleLoadType type, string path, uint crc, ulong offset)
        {
            this.type = type;
            this.path = path;
            this.crc = crc;
            this.offset = offset;
        }
    }
}
