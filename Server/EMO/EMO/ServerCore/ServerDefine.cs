namespace EMO.ServerCore;


//优先加载
public class PreInitAttribute : Attribute { }


public enum ServerType : ushort
{
    Default = 0,
    Access = 1
}


