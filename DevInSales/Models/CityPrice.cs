namespace DevInSales.Models
{
    public class CityPrice
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int ShippingCompanyId { get; set; }
        public decimal BasePrice { get; set; }
    }
}
