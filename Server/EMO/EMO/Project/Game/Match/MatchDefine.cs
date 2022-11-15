using EMO.Project.Base;
using EMO.Project.Base.Net;

namespace EMO.Project.Game.Match;

public enum MatchRoomType
{
    Normal,
}

[NetMessageCode(ModuleDefine.Match, 1)]
public class CSMatch : INetMsg
{
    public MatchRoomType type { get; set; }
}
[NetMessageCode(ModuleDefine.Match, 2)]
public class SCMatch : INetMsg
{
    public MatchErrCode Code { get; set; }
    public MatchRoomType type { get; set; }

}
[NetMessageCode(ModuleDefine.Match, 3)]
public class CSDisMatch : INetMsg
{
    public MatchRoomType type { get; set; }

}
[NetMessageCode(ModuleDefine.Match, 4)]
public class SCDisMatch : INetMsg
{
    public MatchRoomType type { get; set; }

public MatchErrCode Code { get; set; }
}
[NetMessageCode(ModuleDefine.Match, 5)]

public class SPMatchSuccess : INetMsg
{
    public MatchRoomType type { get; set; }
    public string roomID { get; set; }
    public BattlePlayer[] roles;
}


public enum MatchErrCode
{
    Success,
    ReadyInMatch,
    NotExistRole,
}

