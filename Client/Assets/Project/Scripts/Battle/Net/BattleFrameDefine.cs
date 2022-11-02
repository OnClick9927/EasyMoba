using LockStep.Math;
using System.Collections.Generic;


public class FrameData
{
    public long roleID;

    public OPJoyStick stick;
    public class OPJoyStick
    {
        public LFloat x;
        public LFloat y;
    }
}

public class CSBattleFrame
{
    public string roomID;
    public int frameID;
    public long roleID;
    public FrameData data;
}

public class SPBattleFrame
{
    public int frameID;

    public List<FrameData> datas;
}