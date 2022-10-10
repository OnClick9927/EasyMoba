using EMO.Project.Base;
using EMO.Project.Base.Net;

namespace EMO.Project.Game.Role;

public enum LoginType
{
    Login, Signin
}

[NetMessageCode(ModuleDefine.Role, 1)]
public class CSRoleLogin : INetMsg
{
    public LoginType loginType { get; set; }
    public string Password { get; set; }
    public long RoleID { get; set; }
}
[NetMessageCode(ModuleDefine.Role, 2)]
public class SCRoleLogin : ICode, INetMsg
{
    public int Code { get; set; }
    public LoginType loginType { get; set; }
    public string Password { get; set; }
    public long RoleID { get; set; }
}
[NetworkErrCodeDefine]
public class LoginErrCode : ErrCodeDefine
{
    public static int NotExistRoleID = 2;
    public static int PasswordErr = 3;

}

