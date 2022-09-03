namespace EMO.ServerCore.Utils;

public static class DateTimeUtils
{


    public static DateTime DateTimeNow()
    {
        return DateTime.Now;
    }
    
    public static DateTime DateTimeUtcNow()
    {
        return DateTime.UtcNow;
    }
    
    
    
    /// <summary>
    /// 取时间戳，高并发情况下会有重复。想要解决这问题请使用sleep线程睡眠1毫秒。
    /// </summary>
    /// <param name="accurateToMilliseconds">精确到毫秒</param>
    /// <returns>返回一个长整数时间戳</returns>
    public static long GetLocalTimeStamp(bool accurateToMilliseconds = false)
    {
        if (!accurateToMilliseconds)
        {
            return new DateTimeOffset(DateTimeNow()).ToUnixTimeSeconds();
        }
        return new DateTimeOffset(DateTimeNow()).ToUnixTimeMilliseconds();
    }

    
    public static long GetLocalTimeStampFromDate(DateTime date, bool accurateToMilliseconds = false)
    {
        if (!accurateToMilliseconds)
        {
            return new DateTimeOffset(DateTimeNow()).ToUnixTimeSeconds() - new DateTimeOffset(date).ToUnixTimeSeconds();
        }
        return new DateTimeOffset(DateTimeNow()).ToUnixTimeMilliseconds() - new DateTimeOffset(date).ToUnixTimeMilliseconds();
    }
    

    /// <summary>
    /// 时间戳反转为时间，有很多中翻转方法，但是，请不要使用过字符串（string）进行操作，大家都知道字符串会很慢！
    /// </summary>
    /// <param name="timeStamp">时间戳</param>
    /// <param name="accurateToMilliseconds">是否精确到毫秒</param>
    /// <returns>返回一个日期时间</returns>
    public static DateTime GetLocalTime(long timeStamp, bool accurateToMilliseconds = false)
    {
        if (!accurateToMilliseconds)
        {
           return DateTimeOffset.FromUnixTimeSeconds(timeStamp).DateTime.ToLocalTime();
        }
        return DateTimeOffset.FromUnixTimeMilliseconds(timeStamp).DateTime.ToLocalTime();
    }

    
    
}