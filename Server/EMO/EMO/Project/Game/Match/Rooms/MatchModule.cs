using IFramework;


namespace EMO.Project.Game.Match.Rooms;
public class MatchModule : UpdateModule
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
    protected override void Awake()
    {
        dic.Add(MatchRoomType.Normal, new NormalRoom());
    }

    protected override void OnDispose()
    {
       
    }
    protected override ModulePriority OnGetDefautPriority()
    {
        return base.OnGetDefautPriority() + 30;
    }
    protected override void OnUpdate()
    {
        foreach (var item in dic.Values)
        {
            item.Update();
        }
    }
}
