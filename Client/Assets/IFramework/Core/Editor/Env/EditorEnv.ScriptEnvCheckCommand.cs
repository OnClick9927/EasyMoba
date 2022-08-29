/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.1f1
 *Date:           2019-03-22
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using UnityEditor;

namespace IFramework
{
    public partial class EditorEnv
    {
        private struct ScriptEnvCheckCommand : ICommand
        {
            public void Excute()
            {
#if UNITY_2018_1_OR_NEWER
                PlayerSettings.allowUnsafeCode = true;
#else
            string  path = UnityEngine.Application.dataPath.CombinePath("mcs.rsp");
            string content = "-unsafe";
            if (File.Exists(path) && path.ReadText(System.Text.Encoding.Default) == content) return;
                path.WriteText(content, System.Text.Encoding.Default); 
            AssetDatabase.Refresh();
            EditorTools.Quit();
#endif
            }
        }
    }

}
