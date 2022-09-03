using EMO.ServerCore.Modules.Db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMO.Project.Game.Db;

public class Role : ModelBase
{
    public string Name { get; set; }
    public long RoleID { get; set; }
}
internal class RoleDB : SqliteDbContext
{
    public DbSet<Role> Roles { get; set; }
    public async Task<Role> FindRole(long RoleID)
    {
        var count = await Roles.CountAsync();
        if (count <= 0) return null;
        var result = Roles.Where(x => x.RoleID == RoleID);
        return await result.FirstOrDefaultAsync();
    }
    public async Task<bool> ExistRole(long RoleID)
    {
        var result = await FindRole(RoleID);
        return result != null;
    }

    public async Task CreateRole(long RoleID)
    {
        await Roles.AddAsync(new Role
        {
            RoleID = RoleID,
            Name = RoleID.ToString(),
        });
        await SaveChangesAsync();
    }
}
