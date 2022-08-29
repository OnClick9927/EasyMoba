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
                        "Assets/Project",
                        "Assets/Project/Configs",
                        "Assets/Project/Shaders",
                        "Assets/Project/Textures",
                        "Assets/Project/Images",
                        "Assets/Project/Scripts",
                        "Assets/Project/Scenes",
                        "Assets/Project/Prefabs",
                        "Assets/Project/Resources",
                        "Assets/StreamingAssets",
                    };
                }
            }

            protected override List<string> files { get { return null; } }
        }
    }

}
