using EMO.Project.Base.Net;
using LockStep.Math;

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

