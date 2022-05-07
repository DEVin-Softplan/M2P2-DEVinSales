using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DevInSales.Models;

namespace DevInSales.DTOs
{
    /// <summary>
    /// DTO para criar um novo usuário
    /// </summary>
    public class UserCreateDTO
    {
        /// <summary>
        /// O nome do usuário
        /// </summary>
        [Required(ErrorMessage = "O campo {0} do usuário precisa ser informado.")]
        [Display(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// O email do usuário
        /// </summary>
        [Required(ErrorMessage = "O campo {0} do usuário precisa ser informado.")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "email")]
        public string Email { get; set; }

        /// <summary>
        /// A senha do usuário
        /// </summary>
        [Required(ErrorMessage = "O campo {0} do usuário precisa ser informado.")]
        [StringLength(maximumLength: 50, MinimumLength = 4, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.")]
        [DataType(DataType.Password)]
        [Display(Name = "password")]
        public string Password { get; set; }

        /// <summary>
        /// A data de nascimento do usuário
        /// </summary>
        [Required(ErrorMessage = "O campo {0} do usuário precisa ser informado.")]
        [RegularExpression(@"\d{2}\/\d{2}\/\d{4}", ErrorMessage = "Informe a data no padrão brasileiro dd/mm/aaaa")]
        [Display(Name = "birthDate")]
        public string BirthDate { get; set; }

        /// <summary>
        /// O id do perfil do usuário
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} deve ser informado.")]
        [Display(Name = "profileId")]
        public int ProfileId { get; set; }

        public static User ConverterParaEntidade(UserCreateDTO requisicao, Profile profile)
        {
            if (requisicao == null)
            {
                return null;
            }
                
            return new User()
            {
                Name = requisicao.Name,
                Email = requisicao.Email,
                Password = requisicao.Password,
                BirthDate = DateTime.ParseExact(requisicao.BirthDate, "dd/MM/yyyy", new CultureInfo("pt-BR")),
                Profile = profile
            };
        }
    }
}
