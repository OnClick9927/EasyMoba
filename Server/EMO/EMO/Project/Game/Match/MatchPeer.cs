using EMO.Project.Base;
using EMO.Project.Game.Match.Rooms;
using EMO.ServerCore.Modules.NetCore;
using IFramework.Net;


namespace EMO.Project.Game.Match;


[RequestHandler(typeof(CSMatch))]
internal class MatchPeer : GamePeer
{
    public override void OnRecieve(SocketToken sToken, IRequest request)
    {
        CSMatch? req = request as CSMatch;
        if (req == null) return;
        var roleId = GetRoleID(sToken);
        var success = MathRooms.instance.AddRole(req.type, roleId);
        SCMatch res = new SCMatch();
        res.type = req.type;
        res.Code = success ? MatchErrCode.Success : MatchErrCode.ReadyInMatch;
        SendResponse(sToken, res);
    }

}
