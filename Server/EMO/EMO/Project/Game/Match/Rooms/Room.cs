using EMO.Project.Game.Battle.Rooms;

namespace EMO.Project.Game.Match.Rooms;

abstract class Room
{
    protected abstract MatchRoomType type { get; }
    public List<long> roles = new List<long>();
    public bool AddRole(long role)
    {
        if (roles.Contains(role))
        {
            return false;
        }
        roles.Add(role);
        return true;
    }
    public bool RemoveRole(long role)
    {
        return roles.Remove(role);
    }

    public virtual void Update() { }

    protected void Send(long[] roles, long[] enemy)
    {
        SPMatchSuccess sp = new SPMatchSuccess();
        sp.roomID = Guid.NewGuid().ToString();
        sp.roles = roles;
        sp.enemy = enemy;
        sp.type = type;
        if (roles != null)
            for (int i = 0; i < roles.Length; i++)
                RemoveRole(roles[i]);
        if (enemy != null)
            for (int i = 0; i < enemy.Length; i++)
                RemoveRole(enemy[i]);
        if (roles != null)
            for (int i = 0; i < roles.Length; i++)
                ServerTool.SendResponse(roles[i], sp);
        if (enemy != null)
            for (int i = 0; i < enemy.Length; i++)
                ServerTool.SendResponse(enemy[i], sp);

        ServerTool.GetModule<BattleModule>().BuildRoom(sp);
    }
}
