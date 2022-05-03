namespace DevInSales.Models
{
    public class StatePrice
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
        public int ShippingCompanyId { get; set; }
        public ShippingCompany ShippingCompany { get; set; }
        public decimal BasePrice { get; set; }

    }
}
