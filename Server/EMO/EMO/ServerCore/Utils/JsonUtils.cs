using Newtonsoft.Json;

namespace EMO.ServerCore.Utils;

public static class JsonUtils
{
    public static string ToJson(object json)
    {
        return JsonConvert.SerializeObject(json);
    }

    public static T? FromJson<T>(string json)
    {
        return JsonConvert.DeserializeObject<T>(json);
    }
}