namespace DevInSales.Models
{
    public class StatePrice
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public int ShippingCompanyId { get; set; }
        public decimal basePrice { get; set; }
    }
}
