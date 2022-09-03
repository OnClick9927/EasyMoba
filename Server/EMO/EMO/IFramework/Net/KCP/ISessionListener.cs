namespace IFramework.Net.KCP
{
    public interface ISessionListener
    {
        void OnMessage(IKcpSocket client, byte[] buffer, int offset, int length);
    }
}
