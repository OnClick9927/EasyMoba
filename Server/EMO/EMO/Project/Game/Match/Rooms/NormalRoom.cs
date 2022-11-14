namespace EMO.Project.Game.Match.Rooms;

class NormalRoom : Room
{
    protected override MatchRoomType type => MatchRoomType.Normal;

    public override void Update()
    {
        //if (roles.Count >= 2)
        //{
        //    Send(new long[] { roles[0] }, new long[] { roles[1] });
        //}
        if (roles.Count >= 1)
        {
            Send(new long[] { roles[0] }, new long[0] { });
        }
    }
}
