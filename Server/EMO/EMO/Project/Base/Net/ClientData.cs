using IFramework;
using IFramework.Net;
using IFramework.Packets;

namespace EMO.Project.Base.Net;
public interface IClientsData
{
    void SetPkgSize(int pkgSize);
    void Accept(SocketToken sToken);
    void Disconnect(SocketToken sToken);

    PacketReader? GetPacketReader(SocketToken? sToken);
}

public class ClientData
{
    private int pkgSize;
    public void SetPkgSize(int pkgSize)
    {
        this.pkgSize = pkgSize;
    }
    private PacketReader _p;
    public PacketReader packets
    {
        get
        {
            if (_p == null)
            {
                _p = new PacketReader(pkgSize);
            }
            return _p;
        }
    }
}
public class ClientsData<Data> : IClientsData where Data : ClientData, new()
{
    private Dictionary<SocketToken, Data> _map = new Dictionary<SocketToken, Data>();
    private int _pkgSize;


    public void SetPkgSize(int pkgSize)
    {
        _pkgSize = pkgSize;
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
    }

    protected virtual void OnDisconnect(SocketToken sToken)
    {
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
