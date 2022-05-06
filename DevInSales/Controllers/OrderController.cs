using DevInSales.Context;
using DevInSales.DTOs;
using DevInSales.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevInSales.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly SqlContext _context;

        public OrderController(SqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Busca registros de venda com o Id do usuário
        /// </summary>
        /// <param name="user_id">Filtra pelo Id do usuário</param>
        /// <returns>Busca registros de venda com o Id do usuário</returns>
        /// <response code="200">Registro encontrado.</response>
        /// <response code="404">Registro não encontrado.</response>
        /// <response code="500">Ocorreu uma exceção durante a consulta</response>
        [HttpGet("user/{user_id}/order")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ICollection<Order>>> GetUserId(int user_id)
        {
            try
            {
                List<Order> listaVendas = _context.Order
                .Include(x => x.User)
                .ToList()
                .FindAll(x => x.User.Id == user_id);

                if (listaVendas == null) return StatusCode(404);

                return listaVendas;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        /// <response code="200"></response>
        /// <response code="404"></response>
        /// <response code="500"></response>
        [HttpGet("user/{user_id}/buy")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ICollection<Order>>> GetBuyId(int user_id)
        {
            try
            {
                List<Order> listaVendas = _context.Order
                .Include(x => x.User)
                .Include(x => x.Seller)
                //.Include(x => x.Shipping_Company)
                .ToList()
                .FindAll(x => x.Seller.Id == user_id);

                if (listaVendas == null) return StatusCode(404);

                return listaVendas;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Atualiza a quantidade do item de venda
        /// </summary>
        /// <param name="order_id">Filtra pelo Id do pedido</param>
        /// <param name="product_id">Filtra pelo Id do produto</param>
        /// <param name="amount">Atualiza a quantidade</param>
        /// <returns>Atualiza a quantidade do item de venda</returns>
        /// <response code="204">Registro atualizado.</response>
        /// <response code="400">Requisição incorreta.</response>
        /// <response code="404">Registro não encontrado.</response>
        /// <response code="500">Ocorreu uma exceção durante a consulta</response>
        [HttpPatch("{order_id}/product/{product_id}/amount/{amount}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Patch(int order_id, int product_id, int amount)
        {
            try
            {
                if (amount <= 0)
                {
                    return BadRequest();
                }

                var orderDB = await _context.Order.FindAsync(order_id);
                var orderProductDB = _context.Order_Product.Include(op => op.Product).Where(p => p.Id == product_id).FirstOrDefault();

                if (orderDB == null || orderProductDB == null)
                {
                    return NotFound();
                }

                orderProductDB.Amount = amount;
                _context.Entry(orderProductDB).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpGet("order/{order_id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Order>> GetOrderId(int order_id)
        {
            try
            {
                List<Order> listaVendas = _context.Order
                    .Include(x => x.User)
                    .Include(x => x.Seller)
                    .Include(x => x.Date_Order)
                    .ToList()
                    .FindAll(x => x.Id == order_id);

                if (order_id.ToString() == null) return StatusCode(404);

                return Ok(listaVendas);

            }
            catch
            {
                throw;

            }
        }
        [HttpPost("order/{order_id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<OrderProduct>> PostOrderProduct (int order_id, [FromBody] OrderProductCreateDTO orderProductDTO)
        {
            try
            {
                var orderDB = await _context.Order.FindAsync(orderProductDTO.Order_Id);
                var productDB = await _context.Product.FindAsync(orderProductDTO.Product_Id);

                if (orderProductDTO.Product_Id.ToString() == null)
                {
                    return StatusCode(404);
                }
                if (orderDB == null || productDB == null)
                {
                    return StatusCode(404);
                }
                if (orderProductDTO.Amount <= 0)
                {
                    return StatusCode(400);
                }
                if (orderProductDTO.Unit_Price <= 0)
                {
                    return BadRequest("Preço inválido");
                }
                

                if (orderProductDTO.Unit_Price.ToString() == null)
                {
                    orderProductDTO.Unit_Price = productDB.Suggested_Price;
                }
                
                if (orderProductDTO.Amount.ToString() == null)
                {
                    orderProductDTO.Amount = 1;
                }

                var OrderProduct = OrderProductCreateDTO.ConverterParaEntidade(orderProductDTO, productDB, orderDB);
                    _context.Order_Product.Add(OrderProduct);
                    await _context.SaveChangesAsync();

                return StatusCode(201,OrderProduct.Id);

            }

            catch
            {
                throw;
            }
        }
    }
}









