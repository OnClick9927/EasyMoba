using EMO.ServerCore;
using OPServer.IFramework;

namespace EMO.Project.Base;

public static class SeverConst
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
    public static int port = 9633;
    public static int connections = 2000;
    public static int pkgSize = 1024 * 1024;
    public static int udpPort = 9634;
    public static string rootPath = "";
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
