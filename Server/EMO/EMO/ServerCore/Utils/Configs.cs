using EMO.ServerCore.Modules.Config;
using IFramework;

namespace EMO.ServerCore.Utils
{
    public static class Configs
    {
        public static void SaveChanges()
        {
            Log.L("——————开始保存服务器数据");
            foreach (var item in configs.Values)
            {
                item.SaveChanges();
            }
            Log.L("——————保存服务器数据结束");
        }

        private static Dictionary<Type, IConfig> configs = new Dictionary<Type, IConfig>();
        public static TConfig Get<TConfig>() where TConfig : class, IConfig, new()
        {
            Type type = typeof(TConfig);
            if (!configs.ContainsKey(type))
            {
                TConfig t = new TConfig();
                configs.Add(type, t);
                return t;
            }
            return configs[type] as TConfig;
        }

     
    }

}
