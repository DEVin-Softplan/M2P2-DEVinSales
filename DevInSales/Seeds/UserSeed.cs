using DevInSales.Models;

namespace DevInSales.Seeds
{
    public class UserSeed
    {
        public static List<User> Seed { get; set; } = new List<User>() { new User()
        {
            Id = 1,
            Name = "Romeu A Lenda",
            BirthDate = new DateTime(2000, 02, 01),
            Email = "romeu@lenda.com",
            Password = "romeu123@",
            ProfileId = 1
        }, new User()
        {
            Id = 2,
            Name = "Gustavo Levi Ferreira",
            BirthDate = new DateTime(1974, 4, 11),
            Email = "gustavo_levi_ferreira@gmail.com",
            Password = "!romeu321",
            ProfileId = 1
        }, new User()
        {
            Id = 3,
            Name = "Henrique Luiz Lemos",
            BirthDate = new DateTime(1986, 3, 14),
            Email = "lemosluiz@gmail.com",
            Password = "lemos$2022",
            ProfileId = 1
        }, new User()
        {
            Id = 4,
            Name = "Tomás Paulo Aragão",
            BirthDate = new DateTime(1996, 8, 21),
            Email = "tomas.paulo.aragao@hotmail.com",
            Password = "$tpa1996",
            ProfileId = 1
        }
        };
    }
}
