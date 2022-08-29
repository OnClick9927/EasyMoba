/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.1f1
 *Date:           2019-03-22
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using UnityEditor;
using System;

namespace IFramework
{
    public partial class EditorEnv
    {
        private struct FileInitializeCommand : ICommand
        {
            public void Excute()
            {
                foreach (var type in typeof(IFileInitializer).GetSubTypesInAssemblys())
                {
                    if (!type.IsAbstract)
                    {
                        (Activator.CreateInstance(type) as IFileInitializer).Create();
                    }
                }
                delayCall += () => { AssetDatabase.Refresh(); };
            }
        }
    }

}
