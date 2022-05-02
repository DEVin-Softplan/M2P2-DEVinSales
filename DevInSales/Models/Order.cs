namespace DevInSales.Models
{
    public class Order
    {
        public int Id { get; set; }
        public User User { get; set; }
        public User Seller { get; set; }
        public DateTime Date_Order { get; set; }
        //public ShippingCompany Shipping_Company { get; set; }
        public decimal Shipping_Company_Price { get; set; }
    }
}
