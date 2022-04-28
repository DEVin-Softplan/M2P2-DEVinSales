namespace DevInSales.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int Seller_Id { get; set; }
        public DateTime Date_Order { get; set; }
        public string Shipping_Company { get; set; }
        public float Shipping_Company_Price { get; set; }

    }
}
