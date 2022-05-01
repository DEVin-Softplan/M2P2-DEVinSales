using System.ComponentModel.DataAnnotations;

namespace DevInSales.DTOs
{
    public class UserResponseDTO
    {
        [Display(Name = "id")]
        public int Id { get; set; }

        [Display(Name = "name")]
        public string Name { get; set; }

        [Display(Name = "email")]
        public string Email { get; set; }

        [Display(Name = "birthDate")]
        public DateTime BirthDate { get; set; }
    }
}
