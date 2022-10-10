using EMO.Project.Base.Net;
using EMO.Project.Game.Match.Rooms;
using IFramework.Net;


namespace EMO.Project.Game.Match;
[RequestHandler]
class MatchRequestHandler
{
    public static void OnRecieve(SocketToken sToken, CSDisMatch req)
    {
        var roleId = ServerTool.GetRoleID(sToken);
        var success = ServerTool.GetModule<MatchModule>().RemoveRole(req.type, roleId);
        SCDisMatch res = new SCDisMatch();
        res.type = req.type;
        res.Code = success ? MatchErrCode.Success : MatchErrCode.NotExistRole;
        ServerTool.SendResponse(sToken, res);
    }
    public static void OnRecieve(SocketToken sToken, CSMatch req)
    {
        var roleId = ServerTool.GetRoleID(sToken);
        var success = ServerTool.GetModule<MatchModule>().AddRole(req.type, roleId);
        SCMatch res = new SCMatch();
        res.type = req.type;
        res.Code = success ? MatchErrCode.Success : MatchErrCode.ReadyInMatch;
        ServerTool.SendResponse(sToken, res);
    }
}
