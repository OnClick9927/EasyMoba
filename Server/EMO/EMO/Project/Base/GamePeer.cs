using IFramework.Net;
using EMO.Project.Net;
using EMO.ServerCore.Modules.Db;
using EMO.ServerCore.Modules.NetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMO.Project.Base
{
    public abstract class GamePeer : NetPeer
    {

        public static  PeerT? GetPeer<PeerT>() where PeerT : GamePeer
        {
            return sever.PeerPool.GetHandlePeer<PeerT>();
        }

        public static void SendResponse<TResponse>(long roleId, TResponse response) where TResponse : ISeverMsg
        {
            var clientsData = sever.GetClientsData<NetPlayersData>();
            var token = clientsData.GetSTokenByRoleId(roleId);
            if (token != null)
            {
                SendResponse(token, response);
            }
        }
        public static long GetRoleID(SocketToken token)
        {
            var clientsData = sever.GetClientsData<NetPlayersData>();
            return clientsData.GetRoleIdBySToken(token);
        }
        public static T GetDB<T>() where T : SqliteDbContext
        {
            return SqliteDbContext.Get<T>();
        }
    }
}
