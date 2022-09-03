using System.Reflection;
using System.Security.Cryptography;
using Random = System.Random;
namespace EMO.ServerCore.Utils;

public static class StringUtils
{
    public static void FormatSqlStr(object obj, out string keyStr, out string valueStr)
    {
        keyStr = "";
        valueStr = "";
        var lstColumns = obj.GetType()
            .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public |
                           BindingFlags.NonPublic).ToList();

        foreach (var t in lstColumns)
        {
            keyStr += t.Name;
            keyStr += ",";
            var value = t.GetValue(obj);
            if (value == null || ReferenceEquals(value, ""))
            {
                value = "''";
            }
            else if (value is DateTime or string)
            {
                //特殊处理 dateTime 类型
                value = $"'{value}'";
            }

            valueStr += value;
            valueStr += ",";
        }

        if (keyStr.EndsWith(","))
        {
            keyStr = keyStr.Substring(0, keyStr.Length - 1);
        }

        if (valueStr.EndsWith(","))
        {
            valueStr = valueStr.Substring(0, valueStr.Length - 1);
        }
    }


    ///<summary>
    ///生成随机字符串 
    ///</summary>
    ///<param name="length">目标字符串的长度</param>
    ///<param name="useNum">是否包含数字，1=包含，默认为包含</param>
    ///<param name="useLow">是否包含小写字母，1=包含，默认为包含</param>
    ///<param name="useUpp">是否包含大写字母，1=包含，默认为包含</param>
    ///<param name="useSpe">是否包含特殊字符，1=包含，默认为不包含</param>
    ///<param name="custom">要包含的自定义字符，直接输入要包含的字符列表</param>
    ///<returns>指定长度的随机字符串</returns>
    public static string GetRandomString(int length, bool useNum = true, bool useLow = true, bool useUpp = true,
        bool useSpe = false,
        string custom = "")
    {
        byte[] b = new byte[4];
        // new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
        RandomNumberGenerator.Create().GetBytes(b);
        System.Random r = new System.Random(BitConverter.ToInt32(b, 0));
        string s = "", str = custom;
        if (useNum == true)
        {
            str += "0123456789";
        }

        if (useLow == true)
        {
            str += "abcdefghijklmnopqrstuvwxyz";
        }

        if (useUpp == true)
        {
            str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        }

        if (useSpe == true)
        {
            str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
        }

        for (int i = 0; i < length; i++)
        {
            s += str.Substring(r.Next(0, str.Length - 1), 1);
        }

        return s;
    }
}