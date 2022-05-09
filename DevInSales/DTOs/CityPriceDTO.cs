using System.ComponentModel.DataAnnotations;

namespace DevInSales.DTOs
{
    public class CityPriceDTO
    {
        [Required(ErrorMessage = "A cidade deve ser informada.")]
        public int CityId { get; set; }
        
        [Required(ErrorMessage = "A compania deve ser Informada")]
        public int ShippingCompanyId { get; set; }
        
        [Required(ErrorMessage = "O valor da tabela deve ser informado.")]
        [Range(1, 200000, ErrorMessage = "O valor da tabela deve ser entre R$ 1,00 a R$ 200.000,00 e ")]
        public decimal BasePrice { get; set; }
    }
}
