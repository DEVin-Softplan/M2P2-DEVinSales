namespace DevInSales.Models
{
    public class delivery
    {
        public int id { get; set; }
        public int order_id { get; set; }
        public int address_id { get; set; }
        public DateTime delivery_forecast { get; set; }
        public DateTime delivery_date { get; set; }
        public int status { get; set; }
    }
}
