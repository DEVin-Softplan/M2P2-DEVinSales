using DevInSales.Models;

namespace DevInSales.Seeds
{
    public class CityPriceSeed
    {
        public static List<CityPrice> Seed { get; set; } = new List<CityPrice>()
        {
            new CityPrice
            {
                Id = 1,
                CityId = 1,
                ShippingCompanyId = 1,
                BasePrice = 10
            },
            new CityPrice
            {
                Id = 2,
                CityId = 2,
                ShippingCompanyId = 2,
                BasePrice = 20
            },
            new CityPrice
            {
                Id = 3,
                CityId = 3,
                ShippingCompanyId = 3,
                BasePrice = 30
            },
        };
    }
}