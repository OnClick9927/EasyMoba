﻿/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2017.2.3p3
 *Date:           2019-07-02
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

using UnityEngine;

namespace IFramework.UI
{
    /// <summary>
    /// ui加载器
    /// </summary>
    public abstract class UIAsset
    {
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public abstract UIPanel LoadPanel(string name);

        public abstract bool LoadPanelAsync(string name, LoadPanelAsyncOperation op);

        public abstract bool LoadItemAsync(string path, LoadItemAsyncOperation op);

        public abstract void ReleaseItemAsset(string releaseAsset);
        public virtual void DestoryPanel(GameObject gameObject)
        {
            GameObject.Destroy(gameObject);
        }
        public virtual Canvas GetCanvas() { return null; }
    }
}
