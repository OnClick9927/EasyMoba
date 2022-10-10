using IFramework.Net;
using EMO.Project.Game.Db;
using EMO.Project.Net;
using EMO.Project.Base.Utils;
using EMO.Project.Base.Net;

namespace EMO.Project.Game.Role;

[RequestHandler]
class RoleRequestHandler
{
    public static async void OnRecieve(SocketToken sToken, CSRoleLogin req)
    {
        RoleDB db = ServerTool.GetDB<RoleDB>();
        SCRoleLogin rsp = new SCRoleLogin()
        {
            loginType = req.loginType,
        };
        switch (req.loginType)
        {
            case LoginType.Login:
                {
                    var id = req.RoleID;
                    var Password = req.Password;
                    var find = await db.ExistRole(id);
                    if (find)
                    {
                        var _psd = Verifier.GetStringMD5(id.ToString());
                        if (_psd == Password)
                        {
                            rsp.Code = LoginErrCode.Success;
                            rsp.Password = Password;
                            rsp.RoleID = id;
                        }
                        else
                        {
                            rsp.Code = LoginErrCode.PasswordErr;
                        }
                    }
                    else
                    {
                        rsp.Code = LoginErrCode.NotExistRoleID;
                    }
                }
                break;
            case LoginType.Signin:
                {
                    var id = ServerTool.CreateRandomRoleId();
                    var Password = Verifier.GetStringMD5(id.ToString());
                    await db.CreateRole(id);
                    rsp.Code = LoginErrCode.Success;
                    rsp.Password = Password;
                    rsp.RoleID = id;
                }
                break;
        }
        ServerTool.SendResponse(sToken, rsp);
        if (rsp.Code == LoginErrCode.Success)
        {
            NetPlayersData netPlayers = ServerTool.GetClientsData();
            netPlayers.OnRoleLogIn(rsp.RoleID, sToken);

        }
    }

}

