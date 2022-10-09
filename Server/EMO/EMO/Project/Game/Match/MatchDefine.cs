using EMO.Project.Base;
using EMO.ServerCore.Modules.NetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMO.Project.Game.Match;

public enum MatchRoomType
{
    Normal,
}

[NetMessageCode(ModuleDefine.Match, 1)]
public class CSMatch : IRequest
{
    public MatchRoomType type { get; set; }
}
[NetMessageCode(ModuleDefine.Match, 1)]
public class SCMatch : IResponse
{
    public int Code { get; set; }
    public MatchRoomType type { get; set; }

}
[NetMessageCode(ModuleDefine.Match, 2)]
public class CSDisMatch : IRequest
{
    public MatchRoomType type { get; set; }

}
[NetMessageCode(ModuleDefine.Match, 2)]
public class SCDisMatch : IResponse
{
    public MatchRoomType type { get; set; }

    public int Code { get; set; }
}
[NetMessageCode(ModuleDefine.Match, 3)]

public class SPMatchSuccess : ISeverMsg
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

