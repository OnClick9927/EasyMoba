using System.ComponentModel.DataAnnotations;

namespace EMO.ServerCore.Modules.Db;

public class ModelBase
{
    [Key]
    public int id { get; set; }
}
