using IFramework;
using System.Timers;
using EMO.Project.Net;
using EMO.Project.Base.Db;
using Yitter.IdGenerator;
using EMO.Project.Base.Net;

namespace EMO.Project.Base;

public static class ServerInstance
{
    static System.Timers.Timer timer;
    const EnvironmentType envType = EnvironmentType.Ev0;
    public static IEnvironment env { get; private set; }
    private static TcpSever sever;


    public static void StartGame()
    {
        timer = new System.Timers.Timer(1000 / ServerConst.trickPerSecond);
        timer.Elapsed += Timer_Elapsed;
        Framework.CreateEnv(envType).InitWithAttribute();
        timer.Start();
        env = Framework.GetEnv(envType);

        var options = new IdGeneratorOptions(ServerConst.workerId);
        options.WorkerIdBitLength = ServerConst.workerIdBitLength;
        YitIdHelper.SetIdGenerator(options);
        Log.L("id雪花算法初始化完成");

        sever = new TcpSever(ServerConst.port, ServerConst.connections,
            ServerConst.pkgSize, new NetPlayersData());
        SqliteDbContext.Create(ServerConst.dbPath);
    }

    private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        env.Update();
    }

    public static void CloseGame()
    {
        Log.L($"开始关闭  {nameof(ServerInstance)}");
        Framework.GetEnv(envType).Dispose();
        sever.Dispose();
        Log.L($"关闭成功 {nameof(ServerInstance)}");
    }
    public static TcpSever GetServer()
    {
        return sever;
    }
}