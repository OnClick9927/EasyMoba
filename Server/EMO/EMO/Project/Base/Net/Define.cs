using EMO.Project.Game;
using IFramework.Net;

namespace EMO.Project.Base.Net;
public interface INetMsg { }

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
class NetMessageCode : Attribute
{
    public uint MainId;
    public uint SubId;
    public NetMessageCode(ModuleDefine mainId, uint subId)
    {
        MainId = (uint)mainId;
        SubId = subId;
    }
}


[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public class RequestHandler : Attribute { }

