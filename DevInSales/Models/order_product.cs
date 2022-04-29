using System;

namespace DevInSales.Models;


public class Order_Product
{
    public int Id { get; set; }
    public Order Order { get; set; }
    public Product Product { get; set; }
    public decimal Unit_Price { get; set; }
    public int Amount { get; set; }


}
