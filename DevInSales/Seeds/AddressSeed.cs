using DevInSales.Models;

namespace DevInSales.Seeds
{
    public static class AddressSeed
    {
        public static List<Address> Seed { get; set; } = new List<Address>() {
            new Address
            {
                Id = 1,
                City_Id = 11,
                Street = "Rua Lateral",
                CEP = "999999-99",
                Number = 22,
                Complement = "casa"
            },new Address
            {
                Id = 2,
                City_Id = 12,
                Street = "Rua Frente",
                CEP = "999999-99",
                Number = 45,
                Complement = "apto"
            },new Address
            {
                Id = 3,
                City_Id = 13,
                Street = "Rua Lateral",
                CEP = "999999-99",
                Number = 123,
                Complement = "casa"
            }

        };
    }
}
