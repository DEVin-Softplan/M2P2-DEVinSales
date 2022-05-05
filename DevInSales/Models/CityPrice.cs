using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevInSales.Models
{
    public class CityPrice
    {
        //internal int CityId;

        [Key]
        public int Id { get; set; }
        //[ForeignKey("City")]
        public int CityId { get; set; }
        public City City { get; set; }
        //[ForeignKey("ShippingCompany")]
        public ShippingCompany ShippingCompany { get; set; }
        public decimal BasePrice { get; set; }
        public int ShippingCompanyId { get; set; }
    }
}
