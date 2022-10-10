using EMO.Project.Base.Net;


namespace EMO.Project.Game.Battle;


[NetMessageCode(ModuleDefine.Battle, 1)]
public class CSBattleReady : INetMsg
{
    public long roleID { get; set; }
    public string roomID { get; set; }
}

[NetMessageCode(ModuleDefine.Battle, 2)]
public class SPBattleAllReady : INetMsg
{

}

public class FrameData
{
    public long roleID { get; set; }

    public string opText { get; set; }
}

[NetMessageCode(ModuleDefine.Battle, 3)]
public class CSBattleFrame : INetMsg
{
    public string roomID { get; set; }
    public int frameID { get; set; }
    public long roleID { get; set; }


    public FrameData data { get; set; }
}

[NetMessageCode(ModuleDefine.Battle, 4)]
public class SPBattleFrame : INetMsg
{
    public int frameID { get; set; }

    public List<FrameData> datas { get; set; }
}