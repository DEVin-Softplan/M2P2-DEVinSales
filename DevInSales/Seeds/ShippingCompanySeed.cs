using DevInSales.Models;

namespace DevInSales.Seeds
{
    public static class ShippingCompanySeed
    {
        public static List<ShippingCompany> Seed { get; set; } = new List<ShippingCompany>()
        {
            new ShippingCompany
            {
                Id = 1,
                Name = "Rapidex"
            },
            new ShippingCompany
            {
                Id = 2,
                Name = "Veloz e Feroz"
            },
            new ShippingCompany
            {
                Id = 3,
                Name = "Além Paraíba"
            },
            new ShippingCompany
            {
                Id = 4,
                Name = "Empresa Padrão"
            }
        };
    }
}
