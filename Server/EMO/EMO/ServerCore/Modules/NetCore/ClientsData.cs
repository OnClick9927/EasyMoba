using IFramework;
using IFramework.Net;
using IFramework.Packets;

namespace EMO.ServerCore.Modules.NetCore
{
    public class ClientsData<Data> : IClientsData where Data : ClientData, new()
    {
        private Dictionary<SocketToken, Data> _map = new Dictionary<SocketToken, Data>();
        private int _pkgSize;
       
        
        public void SetPkgSize(int pkgSize)
        {
            this._pkgSize = pkgSize;
        }

        public void Accept(SocketToken sToken)
        {
            OnAccept(sToken);
            if (!_map.ContainsKey(sToken))
            {
                Data data = new Data();
                data.SetPkgSize(_pkgSize);
                _map.Add(sToken, data);
            }
        }

        public void Disconnect(SocketToken sToken)
        {
            OnDisconnect(sToken);
            if (_map.ContainsKey(sToken))
            {
                _map.Remove(sToken);
            }
        }

        public Data? GetData(SocketToken sToken)
        {
            return _map.TryGetValue(sToken, out Data? t) ? t : null;
        }


        protected virtual void OnAccept(SocketToken sToken)
        {
            Log.L($"用户端上线  {sToken.TokenIpEndPoint.Address}:{sToken.TokenIpEndPoint.Port}");
        }

        protected virtual void OnDisconnect(SocketToken sToken)
        {
            Log.L($"用户端掉线  {sToken.TokenIpEndPoint.Address}:{sToken.TokenIpEndPoint.Port}");
        }


        public PacketReader? GetPacketReader(SocketToken? sToken)
        {
            if (sToken != null)
            {
                var data = GetData(sToken);
                if (data != null) return data.packets;
            }

            return null;
        }
    }
}