using System;

namespace DevInSales.Models;


public class Order_Product
{
    public int Id { get; set; }
    public int Order_Id { get; set; }
    public int Product_Id { get; set; }
    public float Unit_Price { get; set; }
    public int Amount { get; set; }
    
}
