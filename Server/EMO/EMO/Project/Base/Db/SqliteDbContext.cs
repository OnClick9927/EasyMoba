using IFramework;
using Microsoft.EntityFrameworkCore;

namespace EMO.Project.Base.Db;
public class SqliteDbContext : DbContext
{
    private string rootPath;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data source={Path.Combine(rootPath, $"{GetType().Name}.db")}");    //创建文件夹的位置  
    }

    private async static Task<SqliteDbContext> Create(Type type, string rootPath)
    {
        SqliteDbContext model = Activator.CreateInstance(type) as SqliteDbContext;
        model.rootPath = rootPath;
        Task<bool> task = model.Database.EnsureCreatedAsync();
        await task;
        if (task.Exception != null)
        {
            throw task.Exception;
        }
        return model;
    }

    public async static Task Create(string rootPath)
    {
        var list = typeof(SqliteDbContext).GetSubTypesInAssemblys().ToList();
        for (int i = 0; i < list.Count; i++)
        {
            var type = list[i];
            SqliteDbContext context = await Create(type, rootPath);
            contexts.Add(context);
        }

    }
    private static List<SqliteDbContext> contexts = new List<SqliteDbContext>();
    public static T Get<T>() where T : SqliteDbContext
    {
        foreach (var item in contexts)
        {
            if (item is T)
            {
                return item as T;
            }
        }
        return null;
    }
}
