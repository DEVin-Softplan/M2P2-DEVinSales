using DevInSales.Security;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevInSales.Models;

public class Profile
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name{ get; set; }

    [Column("type")]
    public EProfileType Type { get; set; }

    public Profile()
    {
    }

    public Profile(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public Profile(int id, string name, EProfileType type)
    {
        Id = id;
        Name = name;
        Type = type;
    }
}