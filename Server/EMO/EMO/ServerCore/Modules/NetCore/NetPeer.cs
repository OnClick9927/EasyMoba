using IFramework.Net;

namespace EMO.ServerCore.Modules.NetCore
{
    public abstract class NetPeer
    {
        public TcpSever sever;

        public void SendResponse<TResponse>(SocketToken token, TResponse response) where TResponse : IResponse
        {
            sever.SendResponse<TResponse>(token, response);
        }

        public  abstract void OnRecieve(SocketToken sToken, IRequest request);
        
    }

}
