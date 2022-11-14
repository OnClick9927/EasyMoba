
using LockStep.Math;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Collections.Generic;
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
[System.Serializable]
public class FrameData
{
    public long roleID;

    public LFloat stick_x;
    public LFloat stick_y;

}
[System.Serializable]
public class CSBattleFrame
{
    public string roomID;
    public int frameID;
    public long roleID;
    public FrameData data;
}
[System.Serializable]
public class SPBattleFrame
{
    public int frameID;

    public List<FrameData> datas;
}


[NetMessageCode(ModuleDefine.Battle, 2)]
public class SPBattleAllReady : INetMsg
{

}
[NetMessageCode(ModuleDefine.Battle, 1)]
public class CSBattleReady : INetMsg
{
    public long roleID;
    public string roomID;


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
        public long roleId;
        public int frameID;
        public bool ready = false;

    }
    private Dictionary<long, Player> players = new Dictionary<long, Player>();

    private Dictionary<int, SPBattleFrame> frames = new Dictionary<int, SPBattleFrame>();
    private int curFrame = 0;
    private int gap;
    private Timer timer;
    private ICanCallClientBattleMsg call;
    public Room(MatchRoomType type, List<long> roles, int gap, ICanCallClientBattleMsg call)
    {
        this.call = call;
        this.type = type;
        this.gap = gap;
        for (int i = 0; i < roles.Count; i++)
        {
            players.Add(roles[i], new Player()
            {
                roleId = roles[i],
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
                players[roleId].frameID = System.Math.Min(players[roleId].frameID, frameID);
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