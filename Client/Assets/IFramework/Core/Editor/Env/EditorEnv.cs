/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.1f1
 *Date:           2019-03-22
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using UnityEditor;
using UnityEditor.Compilation;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace IFramework
{
    public partial class EditorEnv
    {
        public const EnvironmentType envType = EnvironmentType.Ev0;
        public static IEnvironment env { get { return Framework.GetEnv(envType); } }
        public static event EditorApplication.CallbackFunction delayCall { add { EditorApplication.delayCall += value; } remove { EditorApplication.delayCall -= value; } }

        [InitializeOnLoadMethod]
        static void EditorEnvInit()
        {
            Debug.Log("IFramework: EditorEnv Init?   " + EditorEnvPath.frameworkPath);
            Framework.CreateEnv(envType).InitWithAttribute();
            CompilationPipeline.assemblyCompilationStarted += Dispose;
            EditorApplication.update += env.Update;
            SendCommand(new ScriptEnvCheckCommand());
            SendCommand(new FileInitializeCommand());
        }
        private static string GetFilePath([CallerFilePath] string path = "")
        {
            return path;
        }
        private static void Dispose(string obj)
        {
            if (env != null)
                env.Dispose();
            UnityEngine.Debug.Log("IFramework: EditorEnv Dispose");
        }
      
        /// <summary>
        /// 发送命令
        /// </summary>
        /// <param name="command"></param>
        public static void SendCommand(ICommand command)
        {
            command.Excute();
        }
    }

}
