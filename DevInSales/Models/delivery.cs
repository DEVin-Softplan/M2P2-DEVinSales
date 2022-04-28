namespace DevInSales.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public int Order_Id { get; set; }
        public int Address_Id { get; set; }
        public DateTime Delivery_Forecast { get; set; }
        public DateTime? Delivery_Date { get; set; }
        public int Status { get; set; }
    }
}
