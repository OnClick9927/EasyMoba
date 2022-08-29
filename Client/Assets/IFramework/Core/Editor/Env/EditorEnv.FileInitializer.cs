/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.1f1
 *Date:           2019-03-22
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System.IO;
using System.Collections.Generic;

namespace IFramework
{
    public partial class EditorEnv
    {
        public abstract class FileInitializer : IFileInitializer
        {
            protected abstract List<string> directorys { get; }
            protected abstract List<string> files { get; }

            protected virtual bool CreateFile(int index, string path) { return true; }
            protected static bool ExistFile(string path)
            {
                return File.Exists(path);
            }
            protected static bool ExistDirectory(string path)
            {
                return Directory.Exists(path);
            }
            public virtual void Create()
            {
                if (directorys != null)
                {
                    directorys.ForEach((path) =>
                    {
                        if (!string.IsNullOrEmpty(path) && !Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                    });
                }
                if (files != null)
                {
                    for (int i = 0; i < files.Count; i++)
                    {
                        var index = i;
                        var path= files[index];
                        bool bo = CreateFile(index, path);
                        if (!bo)
                        {
                            if (!string.IsNullOrEmpty(path) && !File.Exists(path))
                            {
                                File.Create(path);
                            }
                        }
                    }
                }
            }
        }
    }

}
