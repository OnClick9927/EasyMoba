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
    public partial class AssetsInternal
    {
        public class AssetEncryptStream : FileStream
        {

            private string bundleName;
            public AssetEncryptStream(string bundleName, string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, bool useAsync) : base(path, mode, access, share, bufferSize, useAsync)
            {
                this.bundleName = bundleName;
            }
            public AssetEncryptStream(string bundleName, string path, FileMode mode) : base(path, mode)
            {
                this.bundleName = bundleName;
            }

            public override int Read(byte[] array, int offset, int count)
            {
                var index = base.Read(array, offset, count);
                DeCode(bundleName, array);
                return index;
            }
            public override void Write(byte[] array, int offset, int count)
            {
                EnCode(bundleName, array);
                base.Write(array, offset, count);
            }

            public static byte[] DeCode(string bundleName, byte[] buffer)
            {
                return GetEncrypt().DeCode(bundleName, buffer);
            }
            public static byte[] EnCode(string bundleName, byte[] buffer)
            {
                return GetEncrypt().EnCode(bundleName, buffer);
            }
        }

    }
}
