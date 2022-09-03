/*********************************************************************************
 *Author:         OnClick
 *Version:        1.0
 *UnityVersion:   2020.3.3f1c1
 *Date:           2022-09-03
 *Description:    Description
 *History:        2022-09-03--
*********************************************************************************/
using IFramework.Hotfix.Asset;

namespace EasyMoba
{
    public class MobaAssetsSetting : AssetsSetting
    {
        public override string GetUrlByBundleName(string buildTarget, string bundleName)
        {
            return "";
        }

        public override string GetVersionUrl()
        {
            return "";
        }
    }
}
