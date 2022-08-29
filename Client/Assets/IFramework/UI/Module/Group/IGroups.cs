/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2017.2.3p3
 *Date:           2019-07-02
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System;

namespace IFramework.UI
{
    /// <summary>
    /// ui 组
    /// </summary>
    public interface IGroups : IDisposable
    {
       
        /// <summary>
        /// 添加 ui 入组
        /// </summary>
        /// <param name="panel"></param>
        bool Subscribe(UIPanel panel);
        /// <summary>
        /// 移除 ui
        /// </summary>
        /// <param name="panel"></param>
        bool UnSubscribe(UIPanel panel);
        /// <summary>
        /// 加载完毕
        /// </summary>
        /// <param name="name"></param>
        void OnLoad(string name);
        /// <summary>
        /// 要求显示
        /// </summary>
        /// <param name="name"></param>
        void OnShow(string name);
        /// <summary>
        /// 要求隐藏
        /// </summary>
        /// <param name="name"></param>
        void OnHide(string name);
        /// <summary>
        /// 要求关闭
        /// </summary>
        /// <param name="name"></param>
        void OnClose(string name);
    }
}
