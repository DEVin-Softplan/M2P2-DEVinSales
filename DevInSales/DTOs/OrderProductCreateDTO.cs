using DevInSales.Models;
using System.ComponentModel.DataAnnotations;

namespace DevInSales.DTOs
{
    public class OrderProductCreateDTO
    {
        [Required(ErrorMessage = "O campo Unit_Price do OrderProduct precisa ser informado.")]
        public decimal Unit_Price { get; set; }

        [Required(ErrorMessage = "O campo Amount do OrderProduct precisa ser informado.")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "O campo Product_Id do OrderProduct precisa ser informado.")]
        public int Product_Id { get; set; }

        [Required(ErrorMessage = "O campo Order_Id do OrderProduct precisa ser informado.")]
        public int Order_Id { get; set; }

        public static OrderProduct ConverterParaEntidade(OrderProductCreateDTO orderProduct,Product product, Order order)
        {
            if (orderProduct == null) return null;

            return new OrderProduct()
            {
                Unit_Price = orderProduct.Unit_Price,
                Amount = orderProduct.Amount,
                Order = order,
                Product = product
            };
        }

    }
}
