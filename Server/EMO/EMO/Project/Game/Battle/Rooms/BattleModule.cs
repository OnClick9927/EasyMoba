using EMO.Project.Base;
using EMO.Project.Game.Match;
using IFramework;
using IFramework.Net;
using IFramework.Net.Udp;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace EMO.Project.Game.Battle.Rooms;

class BattleModule : IFramework.Module
{
    private Dictionary<string, Room> rooms = new Dictionary<string, Room>();
    private IUdpServerProvider server;
    private Encoding en = Encoding.UTF8;
    private Dictionary<long, IPEndPoint> roles = new Dictionary<long, IPEndPoint>();

    protected override ModulePriority OnGetDefautPriority()
    {
        return base.OnGetDefautPriority() + 20;
    }
    protected override void Awake()
    {
        server = NetTool.CreateUdpSever(ServerConst.udppkgSize, ServerConst.connections);
        server.ReceivedOffsetHanlder += RecieveBattleFrame;
        server.Start(ServerConst.udpPort);
    }

    protected override void OnDispose()
    {

    }
    public void BuildRoom(SPMatchSuccess sp)
    {
        List<long> roles = new List<long>(sp.enemy);
        roles.AddRange(sp.roles);
        rooms.Add(sp.roomID, new Room(sp.type, roles, 1000 / ServerConst.battleRoomTrickPerSecond));
    }

    private Room FindRoom(string id)
    {
        return rooms[id];
    }
    public void PlayerReady(string roomID, long roleID)
    {
        if (FindRoom(roomID) != null)
        {
            rooms[roomID].Ready(roleID);
        }
    }

    public void RecieveBattleFrame(SegmentToken session)
    {
        var buffer = session.Data.buffer;
        var str = en.GetString(buffer);
        CSBattleFrame? frame = JsonConvert.DeserializeObject<CSBattleFrame>(str);
        var roomID = frame.roomID;
        if (FindRoom(roomID) == null) return;
        var roleID = frame.roleID;
        if (roles.ContainsKey(roleID))
            roles[roleID] = session.sToken.TokenIpEndPoint;
        else
            roles.Add(roleID, session.sToken.TokenIpEndPoint);
        FindRoom(roomID).ReadBattleFrame(frame);
    }
    public void SendBattleFrame(long roleID, SPBattleFrame frame)
    {
        var result = JsonConvert.SerializeObject(frame);
        var bytes = en.GetBytes(result);
        SegmentOffset dataSegment = new SegmentOffset(bytes);
        var point = roles[roleID];
        if (point != null)
        {
            server.Send(dataSegment, point);
        }
    }
}
