using DevInSales.Models;
using System.ComponentModel.DataAnnotations;

namespace DevInSales.DTOs
{
    public class ProductPostAndPutDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public decimal Suggested_Price { get; set; }

        public static Product ConverterParaEntidade(ProductPostAndPutDTO requisicao, int id = 0)
        {
            if (requisicao == null)
                return null;

            return new Product()
            {
                Id = id,
                Name = requisicao.Name,
                CategoryId = requisicao.CategoryId,
                Suggested_Price = requisicao.Suggested_Price
            };
        }
    }
}
