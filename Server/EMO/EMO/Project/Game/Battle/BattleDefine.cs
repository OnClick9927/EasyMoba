using EMO.Project.Base.Net;
using LockStep.Math;

namespace EMO.Project.Game.Battle;


[NetMessageCode(ModuleDefine.Battle, 1)]
public class CSBattleReady : INetMsg
{
    public long roleID;
    public string roomID;
}

[NetMessageCode(ModuleDefine.Battle, 2)]
public class SPBattleAllReady : INetMsg
{

}

