﻿using EMO.Project.Base;
using EMO.Project.Game.Match;
using IFramework;
using IFramework.Net;
using IFramework.Net.Udp;
using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace EMO.Project.Game.Battle.Rooms;

class BattleModule : IFramework.Module
{
    private Dictionary<long, Room> rooms = new Dictionary<long, Room>();
    //private IUdpServerProvider server;
    private Encoding en = Encoding.UTF8;
    private Dictionary<long, IPEndPoint> roles = new Dictionary<long, IPEndPoint>();
    private UdpClient client;
    protected override ModulePriority OnGetDefautPriority()
    {
        return base.OnGetDefautPriority() + 20;
    }
    protected override void Awake()
    {
        //server = NetTool.CreateUdpSever(ServerConst.udppkgSize, ServerConst.connections);
        //server.ReceivedOffsetHanlder += RecieveBattleFrame;
        //server.Start(ServerConst.udpPort);
        client = new UdpClient(new IPEndPoint(IPAddress.Any,ServerConst.udpPort));
        Go();
    }
    async void Go()
    {
        UdpReceiveResult result = await client.ReceiveAsync();
        RecieveBattleFrame(result.Buffer, result.RemoteEndPoint);
        Go();
    }

    protected override void OnDispose()
    {
        client.Dispose();
        //server.Dispose();
    }
    public void BuildRoom(SPMatchSuccess sp)
    {
      
        rooms.Add(sp.roomID, new Room(sp.type, sp.roles,
            66,
            new ServerCanCallClientBattleMsg()));
    }

    private Room FindRoom(long id)
    {
        if (rooms.ContainsKey(id))
        {

            return rooms[id];
        }
        return null;
    }
    public void PlayerReady(long roomID, long roleID)
    {
        if (FindRoom(roomID) != null)
        {
            rooms[roomID].Ready(roleID);
        }
    }

    public void RecieveBattleFrame(byte[] buffer,IPEndPoint point)
    {
        CSBattleFrame frame = BattleFrameConvert.ReadCS(buffer);
        var roomID = frame.roomID;
        if (FindRoom(roomID) == null) return;
        var roleID = frame.roleID;
        if (roles.ContainsKey(roleID))
            roles[roleID] = point;
        else
            roles.Add(roleID, point);
        FindRoom(roomID).ReadBattleFrame(frame);
    }
    public void SendBattleFrame(long roleID, SPBattleFrame frame)
    {
        var bytes = BattleFrameConvert.Tobytes(frame);
        //SegmentOffset dataSegment = new SegmentOffset(bytes);
        if (roles.ContainsKey(roleID))
        {
            client.SendAsync(bytes, roles[roleID]);
            //server.Send(dataSegment, );
        }

    }
    public void OnRoleDisConnect(long roleID)
    {
        foreach (var item in rooms.Values)
        {
            item.OnRoleDisConnect(roleID);
        }
    }
}
