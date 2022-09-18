/*********************************************************************************
 *Author:         OnClick
 *Version:        1.0
 *UnityVersion:   2020.3.3f1c1
 *Date:           2022-09-03
 *Description:    Description
 *History:        2022-09-03--
*********************************************************************************/
using IFramework.UI;
using UnityEngine;

namespace EasyMoba
{
    public class UpdateUIAsset : UIAsset
    {
        public override bool LoadItemAsync(string path, LoadItemAsyncOperation op)
        {
            return false;
        }

        public override UIPanel LoadPanel(string name)
        {
            return Resources.Load<UIPanel>($"UI/{name}");
        }

        public override bool LoadPanelAsync(string name, LoadPanelAsyncOperation op)
        {
            return false;
        }

      
    }
}
