using System;

namespace DevInSales.Models;


public class Order_Product
{
    public int Id { get; set; }
    public decimal Unit_Price { get; set; }
    public int Amount { get; set; }

    public ICollection<Order>? Orders { get; set; }

    public ICollection<Product> Products { get; set; }


}
