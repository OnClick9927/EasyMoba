/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.179
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-07
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

using System;

namespace IFramework.Hotfix.Asset
{
    public interface IAssetOperation
    {
        string error { get; }
        bool isDone { get; }
        float progress { get; }
        event Action completed;
    }
}
