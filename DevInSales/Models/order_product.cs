using System;

namespace DevInSales.Models;


public class order_product
{
    public int id { get; set; }
    public int order_id { get; set; }
    public int product_id { get; set; }
    public float unit_price { get; set; }
    public int amount { get; set; }
    
}
