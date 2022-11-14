using IFramework.Net;
using EMO.Project.Game.Battle.Rooms;
using EMO.Project.Base.Net;

namespace EMO.Project.Game.Battle;

[RequestHandler]
class BattleRequestHandler
{

    public static void OnRecieve(SocketToken sToken, CSBattleReady req)
    {


        ServerTool.GetModule<BattleModule>().PlayerReady(req.roomID, req.roleID);
    }
}

