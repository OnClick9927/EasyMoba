using EMO.Project.Game;

namespace EMO.ServerCore.Modules.NetCore
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    class NetMessageCode : Attribute
    {
        public uint MainId;
        public uint SubId;
        public NetMessageCode(ModuleDefine mainId,uint subId)
        {
            this.MainId = (uint)mainId;
            this.SubId = subId;
        }
    }

}
