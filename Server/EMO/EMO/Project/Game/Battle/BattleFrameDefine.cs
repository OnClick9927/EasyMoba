
using LockStep.Math;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Collections.Generic;
using System;
#if !UNITY_5_3_OR_NEWER
using EMO.Project.Base.Net;
using EMO.Project.Game;
using EMO.Project.Game.Match;
#else
using EasyMoba;

public enum MatchRoomType
{
    Normal,
}
public enum ModuleDefine
{
    Role = 1,
    Match = 2,
    Battle,
}
#endif

public enum TeamType
{
    One,
    Two,
    Mid,
}
public class BattlePlayer
{

    public long role_id;
    public TeamType team_type;
}
public class FrameData
{
    public const int length = 8 * 3;
    public long roleID;

    public LFloat stick_x;
    public LFloat stick_y;

}
public class CSBattleFrame
{
    public long roomID;
    public int frameID;
    public long roleID { get { return data.roleID; } }
    public FrameData data;
}
public class SPBattleFrame
{
    public int frameID;

    public List<FrameData> datas;
}

public class BattleFrameConvert
{
    private static int WriteByte(byte[] data, int index, byte value)
    {
        data[index] = value;
        return index + 1;
    }
    private static int WriteInt(byte[] data, int index, int value)
    {
        data[index] = (byte)(value);
        data[index + 1] = (byte)(value >> 8);
        data[index + 2] = (byte)(value >> 16);
        data[index + 3] = (byte)(value >> 24);
        return index + 4;

    }
    private static int WriteLong(byte[] data, int index, long value)
    {
        data[index] = (byte)(value);
        data[index + 1] = (byte)(value >> 8);
        data[index + 2] = (byte)(value >> 16);
        data[index + 3] = (byte)(value >> 24);
        data[index + 4] = (byte)(value >> 32);
        data[index + 5] = (byte)(value >> 40);
        data[index + 6] = (byte)(value >> 48);
        data[index + 7] = (byte)(value >> 56);
        return index + 8;

    }
    private static int WriteFrameData(byte[] data, int index, FrameData value)
    {
        index = WriteLong(data, index, value.roleID);
        index = WriteLong(data, index, value.stick_x._val);
        index = WriteLong(data, index, value.stick_y._val);
        return index;

    }
    private static short ToShort(byte[] array, int offset = 0)
    {
        return (short)((array[offset]) | array[offset + 1] << 8);
    }
    private static int ToInt(byte[] array, int offset = 0)
    {
        return (((int)array[offset])
           | ((int)array[offset + 1] << 8)
           | ((int)array[offset + 2] << 16)
           | array[offset + 3] << 24);
    }
    private static long ToLong(byte[] array, int offset = 0)
    {
        return (((long)array[offset])
             | ((long)array[offset + 1] << 8)
             | ((long)array[offset + 2] << 16)
             | ((long)array[offset + 3] << 24)
             | ((long)array[offset + 4] << 32)
             | ((long)array[offset + 5] << 40)
             | ((long)array[offset + 6] << 48)
             | (long)array[offset + 7] << 56);
    }

    private static FrameData ToFrameData(byte[] bytes, int offset)
    {
        FrameData data = new FrameData();
        data.roleID = ToLong(bytes, offset);
        data.stick_x = LFloat.CreateByRaw(ToLong(bytes, offset + 8));
        data.stick_y = LFloat.CreateByRaw(ToLong(bytes, offset + 16));
        return data;
    }
    public static byte[] Tobytes(CSBattleFrame cs)
    {
        byte[] bytes = new byte[FrameData.length + 12];
        int index = 0;
        index = WriteLong(bytes, index, cs.roomID);
        index = WriteInt(bytes, index, cs.frameID);
        index = WriteFrameData(bytes, index, cs.data);
        return bytes;
    }
    public static byte[] Tobytes(SPBattleFrame cs)
    {
        byte[] bytes = new byte[FrameData.length * cs.datas.Count + 4];
        int index = 0;
        index = WriteInt(bytes, index, cs.frameID);
        for (int i = 0; i < cs.datas.Count; i++)
        {
            index = WriteFrameData(bytes, index, cs.datas[i]);
        }
        return bytes;
    }

    public static CSBattleFrame ReadCS(byte[] bytes)
    {
        CSBattleFrame cs = new CSBattleFrame();
        cs.roomID = ToLong(bytes, 0);
        cs.frameID = ToInt(bytes, 8);
        cs.data = ToFrameData(bytes, 12);
        return cs;
    }
    public static SPBattleFrame ReadSC(byte[] bytes)
    {
        SPBattleFrame cs = new SPBattleFrame();
        var count = (bytes.Length - 4) / FrameData.length;
        cs.frameID = ToInt(bytes, 0);
        cs.datas = new List<FrameData>();
        for (int i = 0; i < count; i++)
        {
            var data = ToFrameData(bytes, 4 + i * FrameData.length);
            cs.datas.Add(data);
        }
        return cs;
    }
}

[NetMessageCode(ModuleDefine.Battle, 2)]
public class SPBattleAllReady : INetMsg
{

}
[NetMessageCode(ModuleDefine.Battle, 1)]
public class CSBattleReady : INetMsg
{
    public long roleID;
    public long roomID;
}
public interface ICanCallClientBattleMsg
{
    void SendResponse(long role_id, SPBattleAllReady response);
    void SendBattleFrame(long roleID, SPBattleFrame frame);
}
class Room
{
    public MatchRoomType type;
    public class Player
    {
        public BattlePlayer bplayer;
        public long roleId { get { return bplayer.role_id; } }
        public int frameID;
        public bool ready = false;

    }
    private Dictionary<long, Player> players = new Dictionary<long, Player>();

    private Dictionary<int, SPBattleFrame> frames = new Dictionary<int, SPBattleFrame>();
    private int curFrame = 0;
    private int gap;
    private Timer timer;
    private ICanCallClientBattleMsg call;
    public Room(MatchRoomType type, BattlePlayer[] roles, int gap, ICanCallClientBattleMsg call)
    {
        this.call = call;
        this.type = type;
        this.gap = gap;
        for (int i = 0; i < roles.Length; i++)
        {
            players.Add(roles[i].role_id, new Player()
            {
                bplayer = roles[i],
            });
        }
    }

    public void Ready(long roleID)
    {
        if (!players.ContainsKey(roleID)) return;
        {
            players[roleID].ready = true;
            foreach (var item in players.Values)
            {
                if (!item.ready) return;
            }
            GameBegin();
        }

    }

    private void CreateSPFrame()
    {
        frames[curFrame] = new SPBattleFrame()
        {
            frameID = curFrame,
            datas = new List<FrameData>()
        };
    }
    public void GameEnd()
    {
        if (timer != null)
        {
            timer.Close();
            timer = null;
        }
    }
    private async void GameBegin()
    {
        SPBattleAllReady sp = new SPBattleAllReady();
        foreach (var roleID in players.Keys)
        {
            call.SendResponse(roleID, sp);
        }
        CreateSPFrame();
        //await Task.Delay(1000);
        //Update, null, gap * 2, gap
        timer = new Timer(gap);
        timer.Elapsed += Update;
        timer.Start();
    }

    private SPBattleFrame GetFrame(int frame_id)
    {
        return frames[frame_id];
    }

    private void Update(object sender, ElapsedEventArgs e)
    {
        lock (frames)
        {
            foreach (var p in players.Values)
            {
                var from = p.frameID;
                for (int i = from; i <= curFrame; i++)
                {
                    call.SendBattleFrame(p.roleId, GetFrame(i));
                }
            }
            curFrame++;
            CreateSPFrame();
        }

    }

    public void ReadBattleFrame(CSBattleFrame frame)
    {
        lock (frames)
        {
            var frameID = frame.frameID;
            var roleId = frame.roleID;
            if (frameID > curFrame) return;//这个人太快了
            if (frameID < curFrame)//这个人太慢了，不接受他的操作，只记录他同步到的fram
            {
                players[roleId].frameID = frameID;
            }
            else//这个人很正常
            {

                var scFrame = GetFrame(curFrame);
                players[roleId].frameID = frameID;
                if (scFrame.datas.Find(x => x.roleID == roleId) == null)
                {
                    scFrame.datas.Add(frame.data);
                }
            }
        }

    }

    internal void OnRoleDisConnect(long roleID)
    {
        if (players.ContainsKey(roleID))
        {
            players[roleID].frameID = 0;
        }
    }
}