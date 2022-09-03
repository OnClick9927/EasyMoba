using IFramework.Net;
using IFramework.Packets;

namespace EMO.ServerCore.Modules.NetCore
{
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

}
