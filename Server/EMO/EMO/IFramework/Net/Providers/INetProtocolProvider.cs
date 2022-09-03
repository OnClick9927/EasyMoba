using IFramework.Packets;

namespace IFramework.Net
{
    public interface INetProtocolProvider
    {
        Packet Decode(byte[] buffer, int offset, int size);

        byte[] Encode(Packet pkg);

    }
}
