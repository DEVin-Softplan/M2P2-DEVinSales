using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevInSales.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
         [ForeignKey("City")]
        public int City_Id { get; set; }
        public City? City { get; set; }
        public string Street { get; set; }
        public string CEP { get; set; }
        public int Number { get; set; }
        public string? Complement { get; set; }
    }
}
