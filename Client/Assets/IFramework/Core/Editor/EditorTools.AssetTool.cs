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
using System.Collections.Generic;
using System;
using System.Linq;
using Object = UnityEngine.Object;

namespace IFramework
{

    public static partial class EditorTools
    {
        public class AssetTool
        {
            public static T CreateScriptableObject<T>(string savePath) where T : ScriptableObject
            {
                ScriptableObject sto = ScriptableObject.CreateInstance<T>();
                AssetDatabase.CreateAsset(sto, savePath);
                EditorUtility.SetDirty(sto);
                AssetDatabase.ImportAsset(savePath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                return AssetDatabase.LoadAssetAtPath<T>(savePath);
            }
            public static T Load<T>(string path) where T : Object
            {
                return AssetDatabase.LoadAssetAtPath<T>(path);
            }
            public static void Update<T>(T t) where T : Object
            {
                EditorEnv.delayCall += delegate ()
                {
                    EditorUtility.SetDirty(t);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();

                };
            }
            public static void Update<T>(T sto, Object[] subAssets) where T : Object
            {
                EditorEnv.delayCall += delegate ()
                {
                    string path = AssetDatabase.GetAssetPath(sto);
                    Object[] objs = AssetDatabase.LoadAllAssetsAtPath(path);
                    if (objs != null)
                    {
                        List<Type> typeList = new List<Type>();
                        for (int i = 0; i < subAssets.Length; i++)
                        {
                            typeList.Add(subAssets[i].GetType());
                        }
                        typeList = typeList.Distinct().ToList();
#if UNITY_2017_4_OR_NEWER
                        for (int i = 0; i < objs.Length; i++)
                        {
                            if (objs[i] != null)
                            {
                                if (AssetDatabase.IsMainAsset(objs[i])) continue;

                                Type objType = objs[i].GetType();
                                if (typeList.Contains(objType) && !subAssets.ToList().Contains(objs[i]))
                                    AssetDatabase.RemoveObjectFromAsset(objs[i]);
                            }

                        }
#else
                    for (int i = 0; i < objs.Length; i++)
                    {
                        if (objs[i] != null)
                        {
                            if (AssetDatabase.IsMainAsset(objs[i])) continue;
                           
                            Type objType = objs[i].GetType();
                            if (typeList.Contains(objType) && !subAssets.ToList().Contains(objs[i]))
                                Object.DestroyImmediate(objs[i],true);
                        }
                    }
#endif
                    }
                    AssetDatabase.ImportAsset(path);
                    if (subAssets == null || subAssets.Length == 0) return;
                    for (int i = subAssets.Length - 1; i >= 0; i--)
                    {
                        if (subAssets[i] != null && !AssetDatabase.Contains(subAssets[i]))
                        {
                            Object asset = subAssets[i];
                            AssetDatabase.AddObjectToAsset(asset, sto);
                            //asset.hideFlags = HideFlags.HideInHierarchy;
                        }
                    }
                    EditorApplication.RepaintProjectWindow();
                    EditorUtility.SetDirty(sto);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                };
            }
            public static void Delete<T>(string path) where T : Object
            {
                AssetDatabase.DeleteAsset(path);
                AssetDatabase.Refresh();
            }
            public static void Delete<T>(T sto) where T : Object
            {
                AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(sto));
                AssetDatabase.Refresh();
            }
        }
    }
}
