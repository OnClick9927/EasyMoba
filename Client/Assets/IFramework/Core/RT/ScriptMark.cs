﻿/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2017.2.3p3
 *Date:           2019-07-30
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System.Collections.Generic;
using UnityEngine;
namespace IFramework
{
    [DisallowMultipleComponent]
    [AddComponentMenu("IFramework/ScriptMark")]
    public class ScriptMark : MonoBehaviour
    {
#if UNITY_EDITOR
        [HideInInspector] public string fieldName;
        [HideInInspector] public string fieldType;
        [HideInInspector] public List<string> componentNames = new List<string>();
        [HideInInspector] public int index;
#endif
    }
}
