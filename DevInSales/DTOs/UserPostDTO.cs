using System.ComponentModel.DataAnnotations;

namespace DevInSales.DTOs
{
    public class UserPostDTO
    {
        [Required(ErrorMessage = "O campo {0} do usuário precisa ser informado.")]
        [Display(Name = "name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} do usuário precisa ser informado.")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} do usuário precisa ser informado.")]
        [StringLength(maximumLength: 50, MinimumLength = 4, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.")]
        [RegularExpression(@"\w*\d", ErrorMessage = "O campo {0} deve ter pelo menos um caractere alfabético e um numérico.")]
        [DataType(DataType.Password)]
        [Display(Name = "password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo {0} do usuário precisa ser informado.")]
        [RegularExpression(@"\d{2}\/\d{2}\/\d{4}", ErrorMessage = "Informe a data no padrão brasileiro dd/mm/aaaa")]
        [Display(Name = "birthDate")]
        public string BirthDate { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} deve ser informado.")]
        [Display(Name = "profileId")]
        public int ProfileId { get; set; }
    }
}
