using IFramework.Net;

namespace EMO.ServerCore.Modules.NetCore
{
    public abstract class NetPeer
    {
        public static TcpSever sever;

        public static void SendResponse<TResponse>(SocketToken token, TResponse response) where TResponse : ISeverMsg
        {
            sever.SendResponse<TResponse>(token, response);
        }

        public  abstract void OnRecieve(SocketToken sToken, IRequest request);
        
    }

}
