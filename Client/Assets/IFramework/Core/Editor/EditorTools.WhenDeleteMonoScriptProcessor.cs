/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.1f1
 *Date:           2019-03-18
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using UnityEditor;
using UnityEngine;
using System;
using System.Linq;
using Object = UnityEngine.Object;

namespace IFramework
{
    partial class EditorTools
    {
        class WhenDeleteMonoScriptProcessor : UnityEditor.AssetModificationProcessor
        {
            private static AssetDeleteResult OnWillDeleteAsset(string AssetPath, RemoveAssetOptions rao)
            {
                if (!AssetPath.EndsWith(".cs")) return AssetDeleteResult.DidNotDelete;
                MonoScript monoScript = AssetDatabase.LoadAssetAtPath<MonoScript>(AssetPath);
                if (monoScript == null) return AssetDeleteResult.DidNotDelete;
                Type spType = monoScript.GetClass();
                if (spType == null || !spType.IsSubclassOf(typeof(MonoBehaviour))) return AssetDeleteResult.DidNotDelete;

                MonoBehaviour[] monos = Object.FindObjectsOfType(spType) as MonoBehaviour[];
                foreach (MonoBehaviour mono in monos)
                {
                    Object.DestroyImmediate(mono);
                }
                string[] guids = AssetDatabase.FindAssets("t:Prefab", new string[] { @"Assets" });
                if (guids == null || guids.Length <= 0) return AssetDeleteResult.DidNotDelete;
                guids.ToList()
                     .ConvertAll((guid) => { return AssetDatabase.LoadAssetAtPath<GameObject>(AssetDatabase.GUIDToAssetPath(guid)); })
                     .ForEach((o) =>
                     {
                         var cps = o.GetComponentsInChildren(spType, true);
                         if (cps != null && cps.Length > 0)
                         {
                             foreach (var c in cps)
                             {
                                 Object.DestroyImmediate(c, true);
                             }
                             AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(o));
                             EditorUtility.SetDirty(o);
                         }

                     });
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
                return AssetDeleteResult.DidNotDelete;
            }

        }



    }
}
