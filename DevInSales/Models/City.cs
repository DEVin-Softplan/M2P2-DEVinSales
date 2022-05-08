using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevInSales.Models
{
    public class  City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("State")]
        public int State_Id { get; set; }
        public State State { get; set; }
    }
}
