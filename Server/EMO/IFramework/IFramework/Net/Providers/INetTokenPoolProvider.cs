using System.Collections.Generic;

namespace IFramework.Net
{
    public interface INetTokenPoolProvider
    {
        int ConnectionTimeout { get; set; }
        int Count { get; }
        void TimerEnable(bool isContinue);
        NetConnectionToken GetTopToken();
        void InsertToken(NetConnectionToken ncToken);
        bool RemoveToken(NetConnectionToken ncToken,bool isClose=true);
        void Clear(bool isClose = true);
        NetConnectionToken GetTokenById(int Id);
        NetConnectionToken GetTokenBySocketToken(SocketToken sToken);
        IEnumerable<NetConnectionToken> Reader();
        bool RefreshExpireToken(SocketToken sToken);
    }
}
