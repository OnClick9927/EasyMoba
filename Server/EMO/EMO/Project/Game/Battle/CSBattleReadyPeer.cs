using EMO.Project.Base;
using EMO.ServerCore.Modules.NetCore;
using IFramework.Net;


namespace EMO.Project.Game.Battle
{
    [RequestHandler(typeof(CSBattleReady))]
    internal class CSBattleReadyPeer : GamePeer
    {
        public override void OnRecieve(SocketToken sToken, IRequest request)
        {
            CSBattleReady? req = request as CSBattleReady;
            if (req == null) return;
            BattleRooms.instance.PlayerReady(req.roomID, req.roleID);
        }
    }
}
