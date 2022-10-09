using EMO.Project.Base;
using EMO.Project.Game.Match.Rooms;
using EMO.ServerCore.Modules.NetCore;
using IFramework.Net;


namespace EMO.Project.Game.Match;

[RequestHandler(typeof(CSDisMatch))]
internal class DisMatchPeer : GamePeer
{
    public override void OnRecieve(SocketToken sToken, IRequest request)
    {
        CSDisMatch? req = request as CSDisMatch;
        if (req == null) return;
        var roleId = GetRoleID(sToken);
        var success = MathRooms.instance.RemoveRole(req.type, roleId);
        SCDisMatch res = new SCDisMatch();
        res.type = req.type;
        res.Code = success ? MatchErrCode.Success : MatchErrCode.NotExistRole;
        SendResponse(sToken, res);
    }

}
