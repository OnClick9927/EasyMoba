﻿/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.223
 *UnityVersion:   2018.4.24f1
 *Date:           2021-03-10
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
namespace IFramework.UI
{
    /// <summary>
    /// ui 事件
    /// </summary>
    /// <typeparam name="Type"></typeparam>
    /// <typeparam name="Self"></typeparam>
    public interface IUIEvent<Type,Self>: IEventArgs
    {
        Type type { get; }
        Self SetType(Type type);
    }
}
