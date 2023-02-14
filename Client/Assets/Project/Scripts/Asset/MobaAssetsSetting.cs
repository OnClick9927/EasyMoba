/*********************************************************************************
 *Author:         OnClick
 *Version:        1.0
 *UnityVersion:   2020.3.3f1c1
 *Date:           2022-09-03
 *Description:    Description
 *History:        2022-09-03--
*********************************************************************************/
using IFramework;
using IFramework.Hotfix.Asset;
using UnityEngine;

namespace EasyMoba
{
    public class MobaAssetsSetting : AssetsSetting
    {

        private string root = Application.dataPath.CombinePath("../DLC/Windowsx");

        public override string GetUrlByBundleName(string buildTarget, string bundleName)
        {
            return root.CombinePath(bundleName).ToRegularPath();
        }

        public override string GetVersionUrl(string buildTarget)
        {
            return root.CombinePath("version").ToRegularPath();
        }
    }
}
