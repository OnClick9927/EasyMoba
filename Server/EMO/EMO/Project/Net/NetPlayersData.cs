using EMO.Project.Base.Net;
using EMO.Project.Game;
using IFramework.Net;

namespace EMO.Project.Net;


public class NetPlayersData : ClientsData<NetPlayer>
{
    private Dictionary<long, SocketToken?> mapRoleId = new Dictionary<long, SocketToken?>();

    private void BindSTokenWithRole(long roleId, SocketToken sToken)
    {
        mapRoleId[roleId] = sToken;
    }
    private void UnBindSTokenWithRole(long roleId)
    {
        mapRoleId[roleId] = null;
        mapRoleId.Remove(roleId);
    }

    public SocketToken? GetSTokenByRoleId(long roleId)
    {
        SocketToken? t;
        if (mapRoleId.TryGetValue(roleId, out t))
        {
            return t;
        }

        return null;
    }

    public long GetRoleIdBySToken(SocketToken sToken)
    {
        var data = GetData(sToken);
        if (data != null)
        {
            return data.id;
        }
        return 0;
    }


    protected override void OnAccept(SocketToken sToken)
    {
        ServerTool.OnAccept(sToken);
    }

    protected override void OnDisconnect(SocketToken sToken)
    {
        var data = GetData(sToken);
        if (data != null && data.id != 0)
        {
            ServerTool.OnDisconnect(sToken, data.id);
            UnBindSTokenWithRole(data.id);
        }
    }

    public void OnRoleLogIn(long roleId, SocketToken token)
    {
        var data = GetData(token);
        if (data != null)
        {
            data.token = token;
            data.id = roleId;
        }
        BindSTokenWithRole(roleId, token);
        ServerTool.OnRoleLogIn(token, data.id);
    }
}