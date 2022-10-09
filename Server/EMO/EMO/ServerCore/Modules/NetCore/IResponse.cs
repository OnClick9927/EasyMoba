namespace EMO.ServerCore.Modules.NetCore
{
    public interface ISeverMsg
    {

    }
    public interface IResponse : ISeverMsg
    {
        public int Code { get; set; }
    }

}
