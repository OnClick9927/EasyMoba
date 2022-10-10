using System.ComponentModel.DataAnnotations;

namespace EMO.Project.Base.Db;

public class ModelBase
{
    [Key]
    public int id { get; set; }
}
