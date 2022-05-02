using System.ComponentModel.DataAnnotations.Schema;

namespace DevInSales.Models;

public class User
{
    [Column("id")]
    public int Id { get; set; }
    [Column("email")]
    public string Email { get; set; }
    [Column("password")]
    public string Password { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("birth_date")]
    public DateTime BirthDate { get; set; }
    public Profile Profile { get; set; }
    public int ProfileId { get; set; }

    public User()
    {
    }
}