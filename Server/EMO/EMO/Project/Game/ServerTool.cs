using EMO.Project.Net;
using EMO.Project.Base.Db;
using IFramework.Net;
using EMO.Project.Base;
using System.Diagnostics.Metrics;
using IFramework;
using Yitter.IdGenerator;
using EMO.Project.Base.Net;
using Newtonsoft.Json.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EMO.Project.Game;

static class ServerTool
{
    public static NetPlayersData GetClientsData()
    {
        return ServerInstance.GetServer().GetClientsData<NetPlayersData>();
    }
    public static long GetRoleID(SocketToken token)
    {
        var clientsData = ServerInstance.GetServer().GetClientsData<NetPlayersData>();
        return clientsData.GetRoleIdBySToken(token);
    }
    public static void SendResponse<TResponse>(long roleId, TResponse response) where TResponse : INetMsg
    {
        var clientsData = ServerInstance.GetServer().GetClientsData<NetPlayersData>();
        var token = clientsData.GetSTokenByRoleId(roleId);
        if (token != null)
        {
            SendResponse(token, response);
        }
    }
    public static void SendResponse<TResponse>(SocketToken token, TResponse response) where TResponse : INetMsg
    {
        ServerInstance.GetServer().SendResponse(token, response);
    }
    public static T GetDB<T>() where T : SqliteDbContext
    {
        return SqliteDbContext.Get<T>();
    }
    public static long CreateRandomRoleId()
    {
        return YitIdHelper.NextId();
    }

    public static T GetModule<T>() where T : Module
    {
        return ServerInstance.env.modules.GetModule<T>();
    }

    public static void OnAccept(SocketToken sToken)
    {
        Log.L($"用户端上线  {sToken.TokenIpEndPoint.Address}:{sToken.TokenIpEndPoint.Port}");
    }

    internal static void OnDisconnect(SocketToken sToken, long id)
    {
        Log.L($"用户端掉线  {sToken.TokenIpEndPoint.Address}:{sToken.TokenIpEndPoint.Port}");

    }

    internal static void OnRoleLogIn(SocketToken sToken, long id)
    {
        Log.L($"用户端登录  {sToken.TokenIpEndPoint.Address}:{sToken.TokenIpEndPoint.Port} _{id}");

    }
}