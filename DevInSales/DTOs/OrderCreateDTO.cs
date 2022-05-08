namespace DevInSales.DTOs
{
    public class OrderCreateDTO
    {
        public int UserId { get; set; }
        public int SellerId { get; set; }
        public DateTime Date_Order { get; set; }
        public decimal Shipping_Company_Price { get; set; }

    }
}
