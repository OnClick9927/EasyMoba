using IFramework;
using IFramework.Singleton;
using Yitter.IdGenerator;

namespace EMO.ServerCore.Plugins;

public class IdGeneratorMgr : Singleton<IdGeneratorMgr>
{
    private bool _isInit = false;
    protected IdGeneratorMgr()
    {
        
    }
    protected override void OnSingletonInit()
    {
        //todo 需要在数据库注册 
        //除非workid 发生变化， 这个类不需要重新设置
        // SeverConfig config = Configs.Get<SeverConfig>();
        //todo 后面再考虑
        // var db = SeverInstance.GetDbContext<MySqlDbContext>();
        // var dbSet = db.AddSet<T_GAME_SERVER_REGISTER>();
        // var idDbConf = dbSet.FirstOrDefault(s => (s.Name == config.data.serverName && s.Type == (ushort) config.data.serverType));
    }
    protected override void OnDispose()
    {
      
    }
    /// <summary>
    /// 初始化配置
    /// </summary>
    /// <param name="workerId"></param>
    /// <param name="workerIdBitLength"></param>
    public void Init(ushort workerId =1 , byte workerIdBitLength = 10 )
    {
        if (_isInit) return;
        var options = new IdGeneratorOptions(workerId);
        options.WorkerIdBitLength = workerIdBitLength;
        YitIdHelper.SetIdGenerator(options);
        _isInit = true; 
        Log.L("id雪花算法初始化完成");
    }
    
    /// <summary>
    /// 获取不重复id接口
    /// </summary>
    /// <returns></returns>
    public long CreateId()
    {
        if (!_isInit)
        {
            Log.E("雪花算法工具并未初始化");
        }
        return YitIdHelper.NextId();
    }


}