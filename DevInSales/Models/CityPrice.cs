using DevInSales.Models;

public class CityPrice
{
		public int Id { get; set; }
		public int CityId { get; set; }
		public ShippingCompany ShippingCompanyId { get; set; }
		public decimal BasePrice { get; set; }
}
