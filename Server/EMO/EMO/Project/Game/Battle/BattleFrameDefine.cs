using EMO.Project.Base.Net;
using LockStep.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMO.Project.Game.Battle;

public class FrameData
{
    public long roleID { get; set; }

    public OPJoyStick stick;
    public class OPJoyStick
    {
        public LFloat x;
        public LFloat y;
    }
}

public class CSBattleFrame
{
    public string roomID { get; set; }
    public int frameID { get; set; }
    public long roleID { get; set; }


    public FrameData data { get; set; }
}

public class SPBattleFrame
{
    public int frameID { get; set; }

    public List<FrameData> datas { get; set; }
}