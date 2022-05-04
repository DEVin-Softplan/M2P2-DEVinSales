﻿using DevInSales.Models;

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
                BasePrice = 17
            },
            new StatePrice
            {
                Id = 2,
                StateId = 2,
                ShippingCompanyId = 1,
                BasePrice = 20
            },
            new StatePrice
            {
                Id = 3,
                StateId = 3,
                ShippingCompanyId = 1,
                BasePrice = 30
            },
            new StatePrice
            {
                Id = 4,
                StateId = 1,
                ShippingCompanyId = 2,
                BasePrice = 19
            },
            new StatePrice
            {
                Id = 5,
                StateId = 2,
                ShippingCompanyId = 2,
                BasePrice = 29
            },
            new StatePrice
            {
                Id = 6,
                StateId = 3,
                ShippingCompanyId = 2,
                BasePrice = 37
            },
            new StatePrice
            {
                Id = 7,
                StateId = 1,
                ShippingCompanyId = 3,
                BasePrice = 10
            },
            new StatePrice
            {
                Id = 8,
                StateId = 2,
                ShippingCompanyId = 3,
                BasePrice = 35
            },
            new StatePrice
            {
                Id = 9,
                StateId = 3,
                ShippingCompanyId = 3,
                BasePrice = 33
            },
        };
    }
}