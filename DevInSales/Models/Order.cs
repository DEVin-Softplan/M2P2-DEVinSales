using System.Text.Json.Serialization;

namespace DevInSales.Models
{
    public class Order
    {
        public int Id { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User Seller { get; set; }
        public int SellerId { get; set; }
        public DateTime Date_Order { get; set; }
        public string Shipping_Company { get; set; }
        public decimal Shipping_Company_Price { get; set; }
    }
}
