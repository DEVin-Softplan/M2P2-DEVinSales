using DevInSales.Models;

namespace DevInSales.Seeds
{
    public static class StatePriceSeed
    {
        public static List<StatePrice> Seed { get; set; } = new List<StatePrice>()
        {
            new StatePrice
            {
                Id = 1,
                StateId = 11,
                ShippingCompanyId = 1,
                BasePrice = 17
            },
            new StatePrice
            {
                Id = 2,
                StateId = 22,
                ShippingCompanyId = 1,
                BasePrice = 20
            },
            new StatePrice
            {
                Id = 3,
                StateId = 33,
                ShippingCompanyId = 1,
                BasePrice = 30
            },
            new StatePrice
            {
                Id = 4,
                StateId = 11,
                ShippingCompanyId = 2,
                BasePrice = 19
            },
            new StatePrice
            {
                Id = 5,
                StateId = 22,
                ShippingCompanyId = 2,
                BasePrice = 29
            },
            new StatePrice
            {
                Id = 6,
                StateId = 33,
                ShippingCompanyId = 2,
                BasePrice = 37
            },
            new StatePrice
            {
                Id = 7,
                StateId = 11,
                ShippingCompanyId = 3,
                BasePrice = 10
            },
            new StatePrice
            {
                Id = 8,
                StateId = 22,
                ShippingCompanyId = 3,
                BasePrice = 35
            },
            new StatePrice
            {
                Id = 9,
                StateId = 33,
                ShippingCompanyId = 3,
                BasePrice = 33
            },
            new StatePrice
            {
                Id = 10,
                StateId = 11,
                ShippingCompanyId = 4,
                BasePrice = 5
            },
            new StatePrice
            {
                Id = 11,
                StateId = 22,
                ShippingCompanyId = 4,
                BasePrice = 6
            },
            new StatePrice
            {
                Id = 12,
                StateId = 33,
                ShippingCompanyId = 4,
                BasePrice = 7
            },
        };
    }
}