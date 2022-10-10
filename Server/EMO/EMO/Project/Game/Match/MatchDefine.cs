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
public class SCMatch : ICode, INetMsg
{
    public int Code { get; set; }
    public MatchRoomType type { get; set; }

}
[NetMessageCode(ModuleDefine.Match, 3)]
public class CSDisMatch : INetMsg
{
    public MatchRoomType type { get; set; }

}
[NetMessageCode(ModuleDefine.Match, 4)]
public class SCDisMatch : ICode, INetMsg
{
    public MatchRoomType type { get; set; }

    public int Code { get; set; }
}
[NetMessageCode(ModuleDefine.Match, 5)]

public class SPMatchSuccess : INetMsg
{
    public MatchRoomType type { get; set; }
    public string roomID { get; set; }
    public long[] roles;
    public long[] enemy;
}
[NetworkErrCodeDefine]
public class MatchErrCode : ErrCodeDefine
{
    public static int ReadyInMatch = 2;
    public static int NotExistRole = 2;


}

