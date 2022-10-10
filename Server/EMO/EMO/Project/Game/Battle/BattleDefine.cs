using EMO.Project.Base.Net;


namespace EMO.Project.Game.Battle;


[NetMessageCode(ModuleDefine.Battle, 1)]
public class CSBattleReady : IRequest
{
    public long roleID { get; set; }
    public string roomID { get; set; }
}

[NetMessageCode(ModuleDefine.Battle, 1)]
public class SPBattleAllReady : ISeverMsg
{

}

public class FrameData
{
    public long roleID { get; set; }

    public string opText { get; set; }
}

[NetMessageCode(ModuleDefine.Battle, 2)]
public class CSBattleFrame
{
    public string roomID { get; set; }
    public int frameID { get; set; }
    public long roleID { get; set; }


    public FrameData data { get; set; }
}

[NetMessageCode(ModuleDefine.Battle, 3)]
public class SPBattleFrame
{
    public int frameID { get; set; }

    public List<FrameData> datas { get; set; }
}