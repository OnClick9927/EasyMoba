namespace EMO.Project.Game.Battle.Rooms;

public class ServerCanCallClientBattleMsg : ICanCallClientBattleMsg
{
    public void SendBattleFrame(long roleID, SPBattleFrame sp)
    {
        ServerTool.GetModule<BattleModule>().SendBattleFrame(roleID, sp);

    }

    public void SendResponse(long role_id, SPBattleAllReady response)
    {
        ServerTool.SendResponse(role_id, response);

    }
}
