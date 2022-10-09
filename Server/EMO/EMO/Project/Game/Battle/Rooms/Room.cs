using EMO.Project.Game.Match;
using System.Threading;

namespace EMO.Project.Game.Battle.Rooms;

class Room
{
    public MatchRoomType type;
    public List<long> roles;
    private List<long> ready = new List<long>();
    private Dictionary<int, SPBattleFrame> frames = new Dictionary<int, SPBattleFrame>();
    private int curFrame = 0;
    private long gap = 1000 / 66;
    private Timer timer;
    private SPBattleFrame GetCurFrame()
    {
        return frames[curFrame];
    }
    private void CreateSPFrame()
    {
        frames[curFrame] = new SPBattleFrame()
        {
            frameID = curFrame,
            datas = new List<FrameData>()
        };
    }
    private void GameEnd()
    {
        timer.Dispose();
    }
    public void Ready(long roleID)
    {
        if (!ready.Contains(roleID) && roles.Contains(roleID))
        {
            ready.Add(roleID);
            if (ready.Count == roles.Count)
            {
                BattleRooms.instance.SendAllReady(this);
                CreateSPFrame();
                timer = new Timer(Update, null, gap, gap);
            }
        }
    }

    private void Update(object? state)
    {
        
    }

    public void ReadBattleFrame(CSBattleFrame frame)
    {

    }
    private void SendFrameToRole(int frameID)
    {
        for (int i = 0; i < roles.Count; i++)
        {
            BattleRooms.instance.SendBattleFrame(roles[i], frames[frameID]);
        }
    }
}
