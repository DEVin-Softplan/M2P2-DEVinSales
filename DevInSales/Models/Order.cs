namespace DevInSales.Models
{
    public class Order
    {
        public int Id { get; set; }
        public User User_Id { get; set; }
        public User Seller_Id { get; set; }
        public DateTime Date_Order { get; set; }
        public ShippingCompany Shipping_Company { get; set; }
        public CityPrice Shipping_Company_Price { get; set; }
    }
}
