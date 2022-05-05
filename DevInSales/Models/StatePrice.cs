using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevInSales.Models
{
    public class StatePrice
    {
        [Key]
        public int Id { get; set; }        
        public int StateId { get; set; }
        public State State { get; set; }        
        public int ShippingCompanyId { get; set; }
        public ShippingCompany ShippingCompany { get; set; }
        public decimal BasePrice { get; set; }

    }
}
