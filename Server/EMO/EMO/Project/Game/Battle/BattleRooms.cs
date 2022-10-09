using EMO.Project.Base;
using EMO.Project.Game.Battle.Rooms;
using EMO.Project.Game.Match;
using EMO.Project.Game.Match.Rooms;
using EMO.ServerCore.Modules.NetCore;
using IFramework;
using IFramework.Net;
using IFramework.Net.Udp;
using IFramework.Packets;
using IFramework.Singleton;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;
using Room = EMO.Project.Game.Battle.Rooms.Room;

namespace EMO.Project.Game.Battle;

class BattleRooms : Singleton<BattleRooms>
{

    private Dictionary<string, Room> rooms = new Dictionary<string, Room>();
    private IUdpServerProvider server;
    private Encoding en = Encoding.UTF8;
    private Dictionary<long, IPEndPoint> roles = new Dictionary<long, IPEndPoint>();

    public void BuildRoom(SPMatchSuccess sp)
    {
        List<long> roles = new List<long>(sp.enemy);
        roles.AddRange(sp.roles);
        rooms.Add(sp.roomID, new Room()
        {
            type = sp.type,
            roles = roles
        });
    }

    private Room FindRoom(string id)
    {
        return rooms[id];
    }
    protected override void OnSingletonInit()
    {
        server = NetTool.CreateUdpSever(SeverConst.pkgSize, SeverConst.connections);
        server.ReceivedOffsetHanlder += RecieveBattleFrame;
        server.Start(SeverConst.udpPort);
    }




    public void PlayerReady(string roomID, long roleID)
    {
        if (FindRoom(roomID) != null)
        {
            rooms[roomID].Ready(roleID);
        }
    }
    public void SendAllReady(Room room)
    {
        SPBattleAllReady sp = new SPBattleAllReady();
        for (int i = 0; i < room.roles.Count; i++)
        {
            var roleID = room.roles[i];
            GamePeer.SendResponse(roleID, sp);
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

    protected override void OnDispose()
    {

    }
}
