namespace EMO.ServerCore.Utils;

public static class TypeParseTool
{
    public static T ParesStr<T>(string str)
    {
        T result = default(T);
        string type = result.GetType().ToString();
        switch (type)
        {
            case "System.String":
                result = (T)(object)str;
                break;
            case "System.Int32":
                result = (T)(object)IntParse(str);
                break;
            case "System.Int64":
                result = (T)(object)LongParse(str);
                break;
            case "System.Boolean":
                result = (T)(object)BoolParse(str);
                break;
            case "System.Float":
                result = (T)(object)FloatParse(str);
                break;
            case "System.Double":
                result = (T)(object)DoubleParse(str);
                break;
            case "System.Int16":
                result = (T)(object)ShortParse(str);
                break;
            case "System.Byte":
                result = (T)(object)ByteParse(str);
                break;
        }

        return result;
    }

    public static T ParesObject<T>(object str)
    {
        return ParesStr<T>(StringParse(str));
    }


    #region string 转 其他类型

    public static int IntParse(string str)
    {
        int.TryParse(str, out var value);
        return value;
    }

    public static float FloatParse(string str)
    {
        float.TryParse(str, out var value);
        return value;
    }

    public static double DoubleParse(string str)
    {
        double.TryParse(str, out var value);
        return value;
    }

    public static long LongParse(string str)
    {
        long.TryParse(str, out var value);
        return value;
    }

    public static bool BoolParse(string str)
    {
        bool.TryParse(str, out var value);
        return value;
    }

    public static short ShortParse(string str)
    {
        short.TryParse(str, out var value);
        return value;
    }

    public static byte ByteParse(string str)
    {
        byte.TryParse(str, out var value);
        return value;
    }

    #endregion

    /// <summary>
    /// object 转string
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string StringParse(object value)
    {
        return $"{value}";
    }

    public static float Long2Float(long f, int length = 0)
    {
        string str = f.ToString();
        if (length == 0)
        {
            return FloatParse(str);
        }
        else
        {
            int len = str.Length;
            string catStr = str.Substring(len - length, length);
            return FloatParse(catStr);
        }
    }
    
    
}