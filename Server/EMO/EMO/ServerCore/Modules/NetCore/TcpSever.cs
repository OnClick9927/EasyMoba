using System.Text;
using EMO.IFramework;
using IFramework;
using IFramework.Net;
using IFramework.Net.Tcp;
using IFramework.Packets;
using Newtonsoft.Json;
using OPServer.IFramework;

namespace EMO.ServerCore.Modules.NetCore
{
    public class TcpSever : Unit
    {
        public static bool EnableLogMessage = true;

        public class NetPeerPool
        {
            private Dictionary<Type, Type> _reqTypeToPeerTypeDic = new Dictionary<Type, Type>(); //请求类型 对应 netpeer 
            private Dictionary<Type, Type> _peerTypeToReqTypeDic = new Dictionary<Type, Type>();
            private Dictionary<Type, NetPeer> _reqTypeToPeerDic = new Dictionary<Type, NetPeer>();




            private Dictionary<uint, Dictionary<uint, Type>> requstMap;
            private Dictionary<Type, Tuple<uint, uint>> responseMap;
            private static Encoding en = Encoding.UTF8;
            private TcpSever sever;

            public NetPeerPool(TcpSever sever)
            {
                this.sever = sever;
                NetPeer.sever = sever;

                var list = typeof(ISeverMsg).GetSubTypesInAssemblys().ToList();
                list.RemoveAll(type => type.IsInterface);
                responseMap = list.ConvertAll((type) =>
                {
                    NetMessageCode h =
                        type.GetCustomAttributes(typeof(NetMessageCode), false).First() as NetMessageCode;
                    return new { type, h.MainId, h.SubId };
                }).ToDictionary(
                    (a) => a.type,
                    (a) => Tuple.Create(a.MainId, a.SubId)
                );
                requstMap = new Dictionary<uint, Dictionary<uint, Type>>();
                foreach (var type in typeof(IRequest).GetSubTypesInAssemblys())
                {
                    NetMessageCode h =
                    type.GetCustomAttributes(typeof(NetMessageCode), false).First() as NetMessageCode;
                    var main = h.MainId;
                    var sub = h.SubId;
                    if (!requstMap.ContainsKey(main))
                    {
                        requstMap.Add(main, new Dictionary<uint, Type>());
                    }
                    requstMap[main].Add(sub, type);
                }
                foreach (var type in typeof(NetPeer).GetSubTypesInAssemblys())
                {
                    RequestHandler[] hs = type.GetCustomAttributes(typeof(RequestHandler), false) as RequestHandler[];
                    for (int i = 0; i < hs.Length; i++)
                    {
                        _reqTypeToPeerTypeDic.Add(hs[i].requsetType, type);
                        _peerTypeToReqTypeDic.Add(type, hs[i].requsetType);
                    }
                }
            }

            public PeerT? GetHandlePeer<PeerT>() where PeerT : class
            {
                var peerType = typeof(PeerT);
                if (_peerTypeToReqTypeDic.TryGetValue(peerType, out var reqType))
                {
                    return GetHandlePeer(reqType) as PeerT;
                }
                return null;
            }

            public NetPeer? GetHandlePeer(Type reqType)
            {
                if (_reqTypeToPeerDic.TryGetValue(reqType, out var peer))
                {
                    return peer;
                }
                if (!_reqTypeToPeerTypeDic.TryGetValue(reqType, out var peerType)) return null;
                peer = Activator.CreateInstance(peerType) as NetPeer;
                _reqTypeToPeerDic.Add(reqType, peer);
                return peer;
            }

            public Packet GetPacket<TResponse>(TResponse response) where TResponse : ISeverMsg
            {
                Type type = typeof(TResponse);
                var msgHead = responseMap[type];
                var result = JsonConvert.SerializeObject(response);
                if (EnableLogMessage)
                {
                    Log.L(
                        $"发送反馈给客户端 MsgHead.MainId: {msgHead.Item1}  MsgHead.SubId: {msgHead.Item2} ({response.GetType()})");
                    Console.WriteLine($"{ConvertJsonString(result)}");
                }

                return new Packet(1, Convert.ToUInt32(msgHead.Item1), Convert.ToUInt32(msgHead.Item2), 1, en.GetBytes(result));
            }

            private string ConvertJsonString(string str)
            {
                //格式化json字符串
                JsonSerializer serializer = new JsonSerializer();
                TextReader tr = new StringReader(str);
                JsonTextReader jtr = new JsonTextReader(tr);
                object obj = serializer.Deserialize(jtr);
                if (obj != null)
                {
                    StringWriter textWriter = new StringWriter();
                    JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                    {
                        Formatting = Formatting.Indented,
                        Indentation = 4,
                        IndentChar = ' '
                    };
                    serializer.Serialize(jsonWriter, obj);
                    return textWriter.ToString();
                }
                else
                {
                    return str;
                }
            }

            public void OnRecieve(List<Packet> pkgs, SocketToken token)
            {
                for (int i = 0; i < pkgs.Count; i++)
                {
                    var pkg = pkgs[i];
                    var type = requstMap[pkg.MainId][pkg.SubId];
                    var str = en.GetString(pkg.message);
                    object? msg = null;
                    try
                    {
                        msg = JsonConvert.DeserializeObject(str, type);
                    }
                    catch (Exception e)
                    {
                        // Console.WriteLine(e);
                        // throw;
                        msg = null;
                        Log.E($"消息转json 失败 {type}");
                    }

                    if (msg == null) return;
                    var req = msg as IRequest;
                    if (EnableLogMessage)
                    {
                        if (req != null) Log.L($"接收到给客户端请求 NetMessageCode: {pkg.MainId}({req.GetType()})");
                        Console.WriteLine($"{ConvertJsonString(str)}");
                    }

                    if (req != null) GetHandlePeer(type)?.OnRecieve(token, req);
                }
            }
        }

        public ITcpServerProvider Sever;
        public NetPeerPool PeerPool;
        private IClientsData _clientsData;

        public TClientsData GetClientsData<TClientsData>() where TClientsData : class, IClientsData
        {
            return _clientsData as TClientsData;
        }

        public TcpSever(int port, int connections, int pkgSize, IClientsData data)
        {
            PeerPool = new NetPeerPool(this);
            data.SetPkgSize(pkgSize);
            this._clientsData = data;
            Log.L($"尝试开启TCP服务 端口：{port} 最大连接数：{connections}");

            Sever = NetTool.CreateTcpSever(maxNumberOfConnections: connections);
            Sever.ReceivedOffsetCallback = OnRecive;
            Sever.AcceptedCallback = OnAccept;
            Sever.DisconnectedCallback = OnDisconnect;
            bool isOk = Sever.Start(port);
            string result = isOk ? "成功" : "失败";
            Log.L($"开启TCP服务 {result}");
            Log.L($"TCP服务初始化完毕---------------------");
        }

        public void SendResponse<TResponse>(SocketToken token, TResponse response) where TResponse : ISeverMsg
        {
            Packet pkg = PeerPool.GetPacket<TResponse>(response);
            Sever.Send(new SegmentToken(token, pkg.Pack()));
        }

        private void OnRecive(SegmentToken session)
        {
            PacketReader? reader = null;
            try
            {
                reader = _clientsData.GetPacketReader(session.sToken);
            }
            catch (Exception e)
            {
                Log.E("OnRecive GetPacketReader is error");
            }

            if (reader != null)
            {
                reader.Set(session.Data.buffer, session.Data.offset, session.Data.size);
                var pkgs = reader.Get();
                if (pkgs == null || pkgs.Count == 0) return;
                PeerPool.OnRecieve(pkgs, session.sToken);
            }
        }


        private void OnAccept(SocketToken sToken)
        {
            _clientsData.Accept(sToken);
        }

        private void OnDisconnect(SocketToken sToken)
        {
            //todo 通知业务层 用户掉线， 保存用户数据并 删除用户对象 

            _clientsData.Disconnect(sToken);
        }

        protected override void OnDispose()
        {
            Sever.Dispose();
        }
    }
}