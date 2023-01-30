/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.1f1
 *Date:           2019-03-22
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System.IO;
using System.Runtime.CompilerServices;

namespace IFramework
{
    public class EditorEnvPath
    {
        private static string GetFilePath([CallerFilePath] string path = "")
        {
            return path;
        }
        public static string frameworkPath
        {
            get
            {
                var path = GetFilePath().ToAssetsPath();
                int index = path.IndexOf("Core");
                path = path.Substring(0, index);
                return path;
            }
        }
        public static string projectMemoryPath = "Assets/IFrameworkProjectMemory/Editor";
        public static string projectPath = "Assets/Project";
        public static string projectConfigPath  { get { return projectPath.CombinePath("Configs"); } }
        public static string projectScriptPath { get { return projectPath.CombinePath("Scripts"); } }


    }

}
