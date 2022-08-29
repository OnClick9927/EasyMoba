/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.179
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-07
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

using UnityEngine;
using Object = UnityEngine.Object;
namespace IFramework.Hotfix.Asset
{
    public class EditorAsset : Asset
    {
        public EditorAsset(bool async, AssetLoadArgs loadArgs) : base(async, null, null, loadArgs)
        {
        }
        public override float progress { get { return 1; } }
        protected override void OnLoad(bool async)
        {
            var result = UnityEditor.AssetDatabase.LoadAssetAtPath(path, typeof(Object));
            SetResult(result);
        }
        protected override void OnUnLoad()
        {
            Resources.UnloadUnusedAssets();
        }
    }
}
