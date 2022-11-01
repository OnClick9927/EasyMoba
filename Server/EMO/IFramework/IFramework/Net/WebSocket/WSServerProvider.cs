using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace IFramework.Net.WebSocket
{
    using IFramework.Net.Tcp;


    internal class WSServerProvider : IDisposable, IWSServerProvider
    {
        private Encoding encoding = Encoding.UTF8;
        TcpServerProvider serverProvider = null;
        List<ConnectionInfo> ConnectionPool = null;
        System.Threading.Timer threadingTimer = null;
        int timeout = 1000 * 60 * 6;
        object lockobject = new object();

        public OnReceivedHandler OnReceived { get; set; }
        public OnReceivedSegmentHandler OnReceivedBytes { get; set; }
        public OnAcceptedHandler OnAccepted { get; set; }
        public OnDisconnectedHandler OnDisconnected { get; set; }
        public OnSentHandler OnSent { get; set; }

        public WSServerProvider(int maxConnections=32,int bufferSize=4096)
        {
            ConnectionPool = new  List<ConnectionInfo>(maxConnections);

            serverProvider = new TcpServerProvider(maxConnections, bufferSize);
            //serverProvider.AcceptedCallback = new OnAcceptedHandler(AcceptedHandler);
            serverProvider.DisconnectedCallback = new OnDisconnectedHandler(DisconnectedHandler);
            serverProvider.ReceivedOffsetCallback = new OnReceivedSegmentHandler(ReceivedHandler);
            serverProvider.SentCallback = new OnSentHandler(SentHandler);

            threadingTimer = new System.Threading.Timer(new TimerCallback(TimingEvent), null, -1, -1);
        }

        public static WSServerProvider CreateProvider(int maxConnections = 32, int bufferSize = 4096)
        {
            return new WSServerProvider(maxConnections,bufferSize);
        }

        public void Dispose()
        {
            threadingTimer.Dispose();
        }

        private void TimingEvent(object obj)
        {
            lock (lockobject)
            {
                var items = ConnectionPool.FindAll(x => DateTime.Now.Subtract(x.ConnectedTime).TotalMilliseconds >= (timeout >> 1));

                foreach (var node in items)
                {
                    if (DateTime.Now.Subtract(node.ConnectedTime).TotalMilliseconds >= timeout)
                    {
                        CloseAndRemove(node);
                        continue;
                    }
                    SendPing(node.sToken);
                }
            }
        }

        public bool Start(int port,string ip="0.0.0.0")
        {
            bool isOk = serverProvider.Start(port,ip);
            if (isOk)
            {
                threadingTimer.Change(timeout>>1, timeout);
            }
            return isOk;
        }

        public void Stop()
        {
            threadingTimer.Change(-1, -1);
            lock (lockobject)
            {
                foreach (var node in ConnectionPool)
                {
                    CloseAndRemove(node);
                }
            }
        }

        public void Close(SocketToken sToken)
        {
            serverProvider.Close(sToken);
        }

        public bool Send(SocketToken sToken, string content,bool waiting=true)
        {
           var buffer = new WebsocketFrame().ToSegmentFrame(content);

            return serverProvider.Send(new SegmentToken(sToken, buffer),waiting);
        }

        public bool Send(SegmentToken session,bool waiting=true)
        {
            return serverProvider.Send(session,waiting);
        }

        private void SendPing(SocketToken sToken)
        {
           serverProvider.Send(new SegmentToken(sToken, new byte[] { 0x89, 0x00 }));
        }

        private void SendPong(SegmentToken session)
        {
            var buffer = new WebsocketFrame().ToSegmentFrame(session.Data,OpCodeType.Bong);

            serverProvider.Send(new SegmentToken(session.sToken, buffer));
        }

        //private void AcceptedHandler(SocketToken sToken)
        //{

        //}

        private void DisconnectedHandler(SocketToken sToken)
        {
           // ConnectionPool.Remove(new ConnectionInfo() { sToken = sToken });
            Remove(sToken);

            if (OnDisconnected != null) OnDisconnected(sToken);
        }

        private void RefreshTimeout(SocketToken sToken)
        {
            foreach (var item in ConnectionPool)
            {
                if (item.sToken.TokenId == sToken.TokenId)
                {
                    item.ConnectedTime = DateTime.Now;
                    break;
                }
            }
        }

        private void ReceivedHandler(SegmentToken session)
        {
            var connection = ConnectionPool.Find(x => x.sToken.TokenId == session.sToken.TokenId);
            if (connection == null)
            {
                connection = new ConnectionInfo() { sToken = session.sToken };

                ConnectionPool.Add(connection);
            }

            if (connection.IsHandShaked == false)
            {
                var serverFrame = new WebsocketFrame();

                var access = serverFrame.GetHandshakePackage(session.Data);
                connection.IsHandShaked = access.IsHandShaked();

                if (connection.IsHandShaked == false)
                {
                    CloseAndRemove(connection);
                    return;
                }
                connection.ConnectedTime = DateTime.Now;

                var rsp = serverFrame.RspAcceptedFrame(access);

                serverProvider.Send(new SegmentToken(session.sToken, rsp));

                connection.accessInfo = access;

                if (OnAccepted != null) OnAccepted(session.sToken);
            }
            else
            {
                RefreshTimeout(session.sToken);

                WebsocketFrame packet = new WebsocketFrame();
                bool isOk = packet.DecodingFromBytes(session.Data, true);
                if (isOk == false) return;

                if (packet.OpCode == 0x01)//text
                {
                    if (OnReceived != null)
                        OnReceived(session.sToken, encoding.GetString(packet.Payload.buffer,
                        packet.Payload.offset, packet.Payload.size));

                    return;
                }
                else if (packet.OpCode == 0x08)//close
                {
                    CloseAndRemove(connection);
                    return;
                }
                else if (packet.OpCode == 0x09)//ping
                {
                    SendPong(session);
                }
                else if (packet.OpCode == 0x0A)//pong
                {
                  //  SendPing(session.sToken);
                }

                if (OnReceivedBytes != null && packet.Payload.size>0)
                    OnReceivedBytes(new SegmentToken(session.sToken, packet.Payload));
            }
        }

        private void SentHandler(SegmentToken session)
        {
            if (OnSent != null)
            {
                OnSent(session);
            }
        }

        private void CloseAndRemove(ConnectionInfo connection)
        {
            bool isOk = Remove(connection);
            if (isOk)
            {
                serverProvider.Close(connection.sToken);
            }
        }

        private bool Remove(ConnectionInfo info)
        {
             
               return ConnectionPool.Remove(info);
                
        }

        private bool Remove(SocketToken sToken)
        {

            return ConnectionPool.RemoveAll(x => x.sToken.TokenId == sToken.TokenId) > 0;

        }

        internal class ConnectionInfo : IComparable<SocketToken>
        {
            public SocketToken sToken { get; set; }

            public bool IsHandShaked { get; set; }

            public AccessInfo accessInfo { get; set; }
            public DateTime ConnectedTime { get; set; } = DateTime.MinValue;
            public int CompareTo(SocketToken info)
            {
                return sToken.TokenId - info.TokenId;
            }
        }
    }
}
