﻿/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2017.2.3p3
 *Date:           2019-07-02
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

namespace IFramework.UI
{
    public class LoadPanelAsyncOperation : UIAsyncOperation<UIPanel>
    {
        public string path;
        public new void SetToDefault()
        {
            base.SetToDefault();
            path = null;
        }
    }
}
