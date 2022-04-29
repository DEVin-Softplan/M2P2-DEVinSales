using DevInSales.Enums;

namespace DevInSales.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public Order Order_Id { get; set; }
        public Address Address_Id { get; set; }
        public DateTime Delivery_Forecast { get; set; }
        public DateTime Delivery_Date { get; set; }
        public StatusEnum Status { get; set; }

    }
}
