using EMO.Project.Base;
using IFramework.Singleton;


namespace EMO.Project.Game.Match.Rooms;
public class MathRooms : Singleton<MathRooms>
{


    private Dictionary<MatchRoomType, Room> dic = new Dictionary<MatchRoomType, Room>();
    public bool AddRole(MatchRoomType type, long role)
    {
        return dic[type].AddRole(role);
    }
    public bool RemoveRole(MatchRoomType type, long role)
    {
        return dic[type].RemoveRole(role);
    }
    protected override void OnSingletonInit()
    {
        dic.Add(MatchRoomType.Normal, new NormalRoom());
        ServerInstance.env.BindUpdate(Update);
    }
    protected override void OnDispose()
    {

    }

    private void Update()
    {
        foreach (var item in dic.Values)
        {
            item.Update();
        }
    }
}
