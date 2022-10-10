namespace EMO.Project.Base.Utils;

public static class FileUtils
{
    public static void CreateDir(string pathDir)
    {
        if (!Directory.Exists(pathDir))
        {
            Directory.CreateDirectory(pathDir);
        }
    }
}