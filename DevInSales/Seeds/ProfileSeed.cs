using DevInSales.Models;

namespace DevInSales.Seeds
{
    public class ProfileSeed
    {
        public static List<Profile> Seed { get; set; } = new List<Profile>() { new Profile(1, "Cliente") };
    }
}
