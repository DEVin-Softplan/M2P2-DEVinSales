using System.ComponentModel.DataAnnotations.Schema;

namespace DevInSales.Models;

public class Profile
{
    [Column("Id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name{ get; set; }
}