/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.2.204
 *UnityVersion:   2019.4.36f1c1
 *Date:           2022-03-09
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System.IO;
using UnityEngine;

namespace IFramework.Hotfix.Asset
{
    class AssetsScriptableObject : ScriptableObject
    {
        public static T Load<T>() where T : AssetsScriptableObject
        {
            string stoPath = EditorEnvPath.projectMemoryPath.CombinePath($"{typeof(T).Name}.asset");
            if (File.Exists(stoPath))
                return EditorTools.AssetTool.Load<T>(stoPath);
            return EditorTools.AssetTool.CreateScriptableObject<T>(stoPath);
        }
        public void Save()
        {
            EditorTools.AssetTool.Update(this);
        }
    }
}
