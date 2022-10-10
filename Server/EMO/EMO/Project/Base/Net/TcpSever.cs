using System.Reflection;
using System.Text;
using IFramework;
using IFramework.Net;
using IFramework.Net.Tcp;
using IFramework.Packets;
using Newtonsoft.Json;

namespace EMO.Project.Base.Net;

public class TcpSever : Unit
{
    public static bool EnableLogMessage = true;
    public class MsgHandleGroup
    {
        private Dictionary<Type, MethodInfo> _msgHandles = new Dictionary<Type, MethodInfo>();
        public MsgHandleGroup()
        {
            AppDomain.CurrentDomain.GetAssemblies()
                 .SelectMany(item => item.GetTypes())
                 .Where(item => item.IsDefined(typeof(RequestHandler))).ToList().ForEach((type) =>
            {
                var ms = type.GetMethods(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
                foreach (var item in ms)
                {
                    var p = item.GetParameters()[1];
                    _msgHandles.Add(p.ParameterType, item);
                }
            });
        }
        public void Handle(SocketToken token, INetMsg request)
        {
            var type = request.GetType();
            var m = _msgHandles[type];
            m.Invoke(null, new object[] { token, request });
        }
    }
    public class NetCodeParser
    {
        private Dictionary<uint, Dictionary<uint, Type>> requstMap;
        private Dictionary<Type, Tuple<uint, uint>> responseMap;
        private static Encoding en = Encoding.UTF8;

        public NetCodeParser()
        {
            var list = typeof(INetMsg).GetSubTypesInAssemblys().ToList();
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
            foreach (var type in typeof(INetMsg).GetSubTypesInAssemblys())
            {
                if (type.IsAbstract)
                    continue;
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

        public Packet GetPacket<TResponse>(TResponse response) where TResponse : INetMsg
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

        public INetMsg? Parse(Packet pkg)
        {
            INetMsg req = null;
            var type = requstMap[pkg.MainId][pkg.SubId];
            var str = en.GetString(pkg.message);
            object? msg = null;
            try
            {
                msg = JsonConvert.DeserializeObject(str, type);
            }
            catch (Exception e)
            {
                msg = null;
                Log.E($"消息转json 失败 {type}");
            }

            if (msg != null)
            {
                req = msg as INetMsg;
                if (EnableLogMessage)
                {
                    if (req != null) Log.L($"接收到给客户端请求 NetMessageCode: {pkg.MainId}({req.GetType()})");
                    Console.WriteLine($"{ConvertJsonString(str)}");
                }
            }

            return req;
        }
    }
    public ITcpServerProvider Sever;
    public NetCodeParser PeerPool;
    private IClientsData _clientsData;
    private readonly MsgHandleGroup handle;

    public TClientsData GetClientsData<TClientsData>() where TClientsData : class, IClientsData
    {
        return _clientsData as TClientsData;
    }

    public TcpSever(int port, int connections, int pkgSize, IClientsData data)
    {
        PeerPool = new NetCodeParser();
        data.SetPkgSize(pkgSize);
        _clientsData = data;
        handle = new MsgHandleGroup();
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

    public void SendResponse<TResponse>(SocketToken token, TResponse response) where TResponse : INetMsg
    {
        Packet pkg = PeerPool.GetPacket(response);
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
            for (int i = 0; i < pkgs.Count; i++)
            {
                var p = PeerPool.Parse(pkgs[i]);
                if (p != null)
                {
                    handle.Handle(session.sToken, p);
                }
            }
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