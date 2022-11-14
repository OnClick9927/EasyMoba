
using IFramework;

namespace EMO.Project.Base;

public static class ServerConst
{


    /// <summary>
    /// 雪花算法 id 生成器配置
    /// </summary>
    public static ushort workerId = 1; // 创建 IdGeneratorOptions 对象，请在构造函数中输入 WorkerId： 最大值 65535

    public static byte workerIdBitLength = 10; // WorkerIdBitLength 默认值6，支持的 WorkerId 最大值为2^6-1，若 WorkerId 超过64，可设置更大的 WorkerIdBitLength

    //设置刷新频率
    public static int trickPerSecond = 30;
    /// <summary>
    /// socket 配置
    /// </summary>
    public const int port = 9633;
    public const int connections = 2000;
    public const int pkgSize = 1024 * 1024;
    public const int udppkgSize = 1024 * 128;
    public const int udpPort = 10568;
    public const int battleRoomTrickPerSecond = 66;

    public const string rootPath = "";
    public static string dbPath
    {
        get
        {
            string path = Path.Combine(rootPath, "DB");
            path.MakeDirectoryExist();
            return path;
        }
    }
}
