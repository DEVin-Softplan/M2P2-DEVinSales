namespace DevInSales.Models
{
    public class Order
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int seller_id { get; set; }
        public DateTime date_order { get; set; }
        public string shipping_company { get; set; }
        public decimal shipping_company_price { get; set; }

    }
}
