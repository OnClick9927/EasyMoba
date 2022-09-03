namespace EMO.ServerCore.Modules.NetCore
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    class RequestHandler : Attribute
    {
        public Type requsetType;

        public RequestHandler(Type requsetType)
        {
            this.requsetType = requsetType;
        }
    }

}
