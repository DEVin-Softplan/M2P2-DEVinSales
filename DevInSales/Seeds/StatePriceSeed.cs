using DevInSales.Models;

namespace DevInSales.Seeds
{
    public class StatePriceSeed
    {
        public static List<StatePrice> Seed { get; set; } = new List<StatePrice>()
        {
            new StatePrice
            {
                Id = 1,
                StateId = 1,
                ShippingCompanyId = 1,
                BasePrice = 10
            },
            new StatePrice
            {
                Id = 2,
                StateId = 2,
                ShippingCompanyId = 2,
                BasePrice = 20
            },
            new StatePrice
            {
                Id = 3,
                StateId = 3,
                ShippingCompanyId = 3,
                BasePrice = 30
            },
        };
    }
}