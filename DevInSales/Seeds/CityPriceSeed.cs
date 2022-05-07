using DevInSales.Models;

namespace DevInSales.Seeds
{
    public static class CityPriceSeed
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
                CityId = 1,
                ShippingCompanyId = 2,
                BasePrice = 20
            },
            new CityPrice
            {
                Id = 3,
                CityId = 1,
                ShippingCompanyId = 3,
                BasePrice = 30
            },
            new CityPrice
            {
                Id = 4,
                CityId = 2,
                ShippingCompanyId = 1,
                BasePrice = 21
            },
            new CityPrice
            {
                Id = 5,
                CityId = 2,
                ShippingCompanyId = 2,
                BasePrice = 22
            },
            new CityPrice
            {
                Id = 6,
                CityId = 2,
                ShippingCompanyId = 3,
                BasePrice = 23
            },
            new CityPrice
            {
                Id = 7,
                CityId = 3,
                ShippingCompanyId = 1,
                BasePrice = 31
            },
            new CityPrice
            {
                Id = 8,
                CityId = 3,
                ShippingCompanyId = 2,
                BasePrice = 32
            },
            new CityPrice
            {
                Id = 9,
                CityId = 3,
                ShippingCompanyId = 3,
                BasePrice = 33
            },
            new CityPrice
            {
                Id = 10,
                CityId = 1,
                ShippingCompanyId = 4,
                BasePrice = 5
            },
            new CityPrice
            {
                Id = 11,
                CityId = 2,
                ShippingCompanyId = 4,
                BasePrice = 6
            },
            new CityPrice
            {
                Id = 12,
                CityId = 3,
                ShippingCompanyId = 4,
                BasePrice = 7
            },
        };
    }
}