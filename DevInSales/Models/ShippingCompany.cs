using System.ComponentModel.DataAnnotations;

namespace DevInSales.Models
{
    public class ShippingCompany
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
