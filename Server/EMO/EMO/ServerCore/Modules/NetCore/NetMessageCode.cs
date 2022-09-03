namespace EMO.ServerCore.Modules.NetCore
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    class NetMessageCode : Attribute
    {
        public uint MainId;
        public uint SubId;
        public NetMessageCode(uint mainId,uint subId)
        {
            this.MainId = mainId;
            this.SubId = subId;
        }
    }

}
