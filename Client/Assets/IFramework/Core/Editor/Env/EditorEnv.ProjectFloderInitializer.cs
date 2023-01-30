/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.1f1
 *Date:           2019-03-22
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System.Collections.Generic;

namespace IFramework
{
    public partial class EditorEnv
    {
        class ProjectFloderInitializer : FileInitializer
        {
            protected override List<string> directorys
            {
                get
                {
                    return new List<string>()
                    {
                        EditorEnvPath.projectMemoryPath,
                        EditorEnvPath.projectPath,
                        EditorEnvPath.projectConfigPath,
                        EditorEnvPath.projectScriptPath,
                    };
                }
            }

            protected override List<string> files { get { return null; } }
        }
    }

}
