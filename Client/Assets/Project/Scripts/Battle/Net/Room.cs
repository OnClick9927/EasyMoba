﻿

using System;
using System.Collections.Generic;
using System.Threading;
public enum MatchRoomType
{
    Normal,
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

    public Room(MatchRoomType type, List<long> roles,int gap)
    {
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
    private void GameBegin()
    {
        //SPBattleAllReady sp = new SPBattleAllReady();
        foreach (var roleID in players.Keys)
        {
            //ServerTool.SendResponse(roleID, sp);
        }
        CreateSPFrame();
        timer = new Timer(Update, null, gap * 2, gap);
    }


    private void Update(object? state)
    {
        foreach (var p in players.Values)
        {
            var from = p.frameID;
            for (int i = from; i <= curFrame; i++)
            {
                //ServerTool.GetModule<BattleModule>().SendBattleFrame(p.roleId, frames[i]);
            }
        }
        curFrame++;
        CreateSPFrame();
    }

    public void ReadBattleFrame(CSBattleFrame frame)
    {
        var frameID = frame.frameID;
        var roleId = frame.roleID;
        if (frameID > curFrame) return;//这个人太快了
        if (frameID < curFrame)//这个人太慢了，不接受他的操作，只记录他同步到的fram
        {
            players[roleId].frameID = Math.Min(players[roleId].frameID, frameID);
        }
        else//这个人很正常
        {
            var scFrame = GetCurFrame();
            players[roleId].frameID = frameID;
            if (scFrame.datas.Find(x => x.roleID == roleId) == null)
            {
                scFrame.datas.Add(frame.data);
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