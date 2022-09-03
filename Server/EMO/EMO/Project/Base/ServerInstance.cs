using IFramework;
using System.Timers;
using EMO.Project.Net;
using EMO.ServerCore.Modules.NetCore;
using EMO.ServerCore.Plugins;
using EMO.ServerCore.Modules.Db;
using OPServer.IFramework;

namespace EMO.Project.Base
{
    public static class ServerInstance
    {
        static System.Timers.Timer timer;
        public const EnvironmentType envType = EnvironmentType.Ev0;

        public static IEnvironment env { get; private set; }

        //服务器链接
        private static TcpSever sever;

        //数据库链接
        // private static GameDbContext SevicedbContext;


        public static void StartGame()
        {
            timer = new System.Timers.Timer(1000 / SeverConst.trickPerSecond);
            timer.Elapsed += Timer_Elapsed;
            Framework.CreateEnv(envType).InitWithAttribute();
            timer.Start();
            env = Framework.GetEnv(envType);
            InitIdGenerator();
            InitSocket();
            InitDb();
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




        private static void InitIdGenerator()
        {
            IdGeneratorMgr.instance.Init(SeverConst.workerId, SeverConst.workerIdBitLength);
        }

        private static void InitSocket()
        {
            //TcpSever.enableLogMessage = false;
            sever = new TcpSever(SeverConst.port, SeverConst.connections, SeverConst.pkgSize, new NetPlayersData());
        }

        private static void InitDb()
        {
            SqliteDbContext.Create(SeverConst.dbPath);
        }

        public static NetPlayersData GetClientsData()
        {
            return sever.GetClientsData<NetPlayersData>();
        }

        public static TcpSever GetServer()
        {
            return sever;
        }
    }
}