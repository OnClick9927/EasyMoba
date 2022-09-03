
// See https://aka.ms/new-console-template for more information

using System.Globalization;
using System.Runtime.InteropServices;
using IFramework;
using IFramework.Net;
using IFramework.Packets;
using EMO.ServerCore.Plugins;
using EMO.ServerCore.Modules.EmmyLua;
using EMO.Project.Base;

class Program
{
    static void Main(string[] args)
    {
        //出现错误System.NotSupportedException: No data is available for encoding 1252
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        //设置时间格式为24小时制
        System.Globalization.CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("zh-CN", true)
        {
            DateTimeFormat = { ShortDatePattern = "yyyy-MM-dd", FullDateTimePattern = "yyyy-MM-dd HH:mm:ss", LongTimePattern = "HH:mm:ss" }
        };

        Log.loger = new Logger();
        ServerInstance.StartGame();
        bool isWindows = System.Runtime.InteropServices.RuntimeInformation
            .IsOSPlatform(OSPlatform.Windows);
        if (isWindows)
        {
            AgreementsToLua.Build();
            WindowsKeyListener();
        }
        else
        {
            OsPlatformListener();
        }
    }



    private static void WindowsKeyListener()
    {
        Log.L("--------------按键盘 esc 关闭 -------------------------");
        ManualResetEventSlim mres1 = new ManualResetEventSlim(false); // initialize as unsignaled
        var observer = Task.Factory.StartNew(() =>
        {
            while (true)
            {
                Task.Delay(1000);
                ConsoleKey key = Console.ReadKey().Key;
                if (key != ConsoleKey.Escape)
                {
                    HandleKey(key);
                }
                else
                {
                    mres1.Set();
                    break;
                }
            }
        });
        mres1.Wait();
        observer.Wait();
        mres1.Dispose();
        Log.L("--------------------------按键盘 esc 退出 ---------------------");
        CloseServer();
        while (Console.ReadKey().Key != ConsoleKey.Escape) { }
    }

    private static void HandleKey(ConsoleKey key)
    {
        if (key == ConsoleKey.C)
        {
            Console.Clear();
        }
        else if (key == ConsoleKey.Delete)
        {
            //暂时不需要 配置持久化
            // Configs.DeleteConfigs(ServerStaticConfig.ConfigDir);
        }
        else if (key == ConsoleKey.T)
        {
            
        }
    }


    private static void OsPlatformListener()
    {
        for (; ; )
        {
            string? line = Console.ReadLine();
            if (line == string.Empty)
                break;
            // Restart the server
            if (line == "restart")
            {
                RestartServer();
                continue;
            }
            // Multicast admin message to all sessions
            // line = "(admin) " + line;
            // server.Multicast(line);
        }
        CloseServer();
    }


    private static void RestartServer()
    {
        Console.Write("Server Restart...");
        //todo
        Console.WriteLine("Done!");
    }

    private static void CloseServer()
    {
        Console.Write("Server Stop...");
        ServerInstance.CloseGame();
        //不需要保存配置到本地
        // Configs.SaveChanges();
        Console.WriteLine("Done!");
    }

}



