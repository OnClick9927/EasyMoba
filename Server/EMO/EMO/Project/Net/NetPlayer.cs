using EMO.Project.Base.Net;
using IFramework.Net;

namespace EMO.Project.Net;

public class NetPlayer : ClientData
{
    public long id = 0; //roleId
    [Newtonsoft.Json.JsonIgnore] public SocketToken token; //链接token
}