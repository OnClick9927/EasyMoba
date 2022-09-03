namespace EMO.ServerCore.Utils;

public static class ListUtils
{
    public static List<List<T>> GroupList<T>(List<T> sourceList, int groupCount=50)
    {
        var listGroup = new List<List<T>>();
        var j = groupCount;
        for (int i = 0; i < sourceList.Count; i += groupCount)
        {
            var cList = sourceList.Take(j).Skip(i).ToList();
            j += groupCount;
            listGroup.Add(cList);
        }

        return listGroup;
    }
}