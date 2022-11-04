using System.Collections.Generic;

namespace IFramework.Net
{
    internal class NetTokenPoolProvider:INetTokenPoolProvider
    {
        TokenConnectionManager tokenManager = null;
        public int ConnectionTimeout
        {
            get { return tokenManager.ConnectionTimeout; }
            set { tokenManager.ConnectionTimeout = value; }
        }

        public int Count { get { return tokenManager.Count; } }

        public static NetTokenPoolProvider CreateProvider(int taskExecutePeriod)
        {
            return new NetTokenPoolProvider(taskExecutePeriod);
        }

        public NetTokenPoolProvider(int taskExecutePeriod)
        {
            tokenManager = new TokenConnectionManager(taskExecutePeriod);
        }

        public void TimerEnable(bool isContinue)
        {
            tokenManager.TimerEnable(isContinue);
        }

        public NetConnectionToken GetTopToken()
        {
           return tokenManager.GetTopToken();
        }

        public void InsertToken(NetConnectionToken ncToken)
        {
            tokenManager.InsertToken(ncToken);
        }


        public IEnumerable<NetConnectionToken> Reader()
        {
            foreach (var item in tokenManager.ReadNext())
            {
                yield return item;
            }
        }

        public bool RemoveToken(NetConnectionToken ncToken,bool isClose=true)
        {
          return  tokenManager.RemoveToken(ncToken,isClose);
        }

        public NetConnectionToken GetTokenById(int Id)
        {
          return  tokenManager.GetTokenById(Id);
        }

        public NetConnectionToken GetTokenBySocketToken(SocketToken sToken)
        {
            return tokenManager.GetTokenBySocketToken(sToken); 
        }

        public bool RefreshExpireToken(SocketToken sToken)
        {
            return tokenManager.RefreshConnectionToken(sToken);
        }

        public void Clear(bool isClose=true)
        {
            tokenManager.Clear(isClose);
        }
    }
}
