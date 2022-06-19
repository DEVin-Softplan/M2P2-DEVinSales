using DevInSales.Context;
using DevInSales.DTOs;
using DevInSales.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        [Authorize(Roles = "Administrador,Gerente,Usuario")]
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
        /// Busca registros de venda com o Id do vendedor
        /// </summary>
        /// <param name="user_id">Filtra pelo Id do vendedor</param>
        /// <returns>Busca registros de venda com o Id do vendedor</returns>
        /// <response code="200"></response>
        /// <response code="404"></response>
        /// <response code="500"></response>
        [HttpGet("user/{user_id}/buy")]
        [Authorize(Roles = "Administrador,Gerente,Usuario")]
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
        /// Atualiza o preço do item de venda
        /// </summary>
        /// <param name="order_id">Id do pedido</param>
        /// <param name="orderProduct_id">Id do order product</param>
        /// <param name="price">Novo preço</param>
        /// <returns>Atualiza o preço do item de venda</returns>
        /// <response code="204">Registro atualizado.</response>
        /// <response code="400">Requisição incorreta.</response>
        /// <response code="404">Registro não encontrado.</response>
        /// <response code="500">Ocorreu uma exceção durante a consulta</response>
        [HttpPatch("{order_id}/product/{product_id}/price/{price}")]
        [Authorize(Roles = "Administrador,Gerente")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> PatchPrice(int order_id, int orderProduct_id, decimal price)
        {

            if (price <= 0)
            {
                return BadRequest();
            }

            var orderDB = await _context.Order.FindAsync(order_id);
            var orderProductDB = _context.Order_Product.Include(op => op.Product).Where(p => p.Id == orderProduct_id).FirstOrDefault();

            if (orderDB == null || orderProductDB == null)
            {
                return NotFound();
            }

            orderProductDB.Unit_Price = price;
            _context.Entry(orderProductDB).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return NoContent();

        }
        /// <summary>
        /// Atualiza a quantidade do item de venda
        /// </summary>
        /// <param name="order_id">Filtra pelo Id do pedido</param>
        /// <param name="orderProduct_id">Filtra pelo Id do order product</param>
        /// <param name="amount">Atualiza a quantidade</param>
        /// <returns>Atualiza a quantidade do item de venda</returns>
        /// <response code="204">Registro atualizado.</response>
        /// <response code="400">Requisição incorreta.</response>
        /// <response code="404">Registro não encontrado.</response>
        /// <response code="500">Ocorreu uma exceção durante a consulta</response>
        [HttpPatch("{order_id}/product/{product_id}/amount/{amount}")]
        [Authorize(Roles = "Administrador,Gerente")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> PatchAmount(int order_id, int orderProduct_id, int amount)
        {
           
                if (amount <= 0)
                {
                    return BadRequest();
                }

                var orderDB = await _context.Order.FindAsync(order_id);
                var orderProductDB = _context.Order_Product.Include(op => op.Product).Where(p => p.Id == orderProduct_id).FirstOrDefault();

                if (orderDB == null || orderProductDB == null)
                {
                    return NotFound();
                }

                orderProductDB.Amount = amount;
                _context.Entry(orderProductDB).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return NoContent();
           
        }

        /// <summary>
        /// Busca registros de venda com o Id do order product
        /// </summary>
        /// <param name="orderProduct_id">Filtra pelo Id do order product</param>
        /// <returns>Busca registros de venda com o Id do order product</returns>
        /// <response code="204">Registro atualizado.</response>
        /// <response code="400">Requisição incorreta.</response>
        /// <response code="404">Registro não encontrado.</response>
        /// <response code="500">Ocorreu uma exceção durante a consulta</response>
        [HttpGet("order/{order_id}")]
        [Authorize(Roles = "Administrador,Gerente,Usuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Order>> GetOrderId(int orderProduct_id)
        {
            try
            {
                var orderProduct = _context.Order_Product.Include(x => x.Order).Include(x => x.Product).FirstOrDefault(x => x.Id == orderProduct_id);

                if (orderProduct_id.ToString() == null) return StatusCode(404);

                return Ok(orderProduct);

            }
            catch
            {
                throw;

            }
        }

        /// <summary>
        /// Cria uma order
        /// </summary>
        /// <param name="city_id">Insere o id da cidade/param>
        /// <returns>Cria uma order product</returns>
        /// <response code="204">Registro atualizado.</response>
        /// <response code="400">Requisição incorreta.</response>
        /// <response code="404">Registro não encontrado.</response>
        /// <response code="500">Ocorreu uma exceção durante a consulta</response>
        [HttpPost("/user/{user_id}/order")]
        [Authorize(Roles = "Administrador,Gerente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Order>> PostOrder(OrderCreateDTO order, int city_id)
        {
            if(order.SellerId == 0) { return BadRequest(); }
            if(order.UserId == 0) { return BadRequest(); }

            var newOrder = new Order
            {
                UserId = order.UserId,
                SellerId = order.SellerId,
                Date_Order = order.Date_Order,
            };

            HttpClient client;

            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7080/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            System.Net.Http.HttpResponseMessage response = client.GetAsync($"/api/freight/{city_id}").Result;

            var shipping_companies = response.Content.ReadFromJsonAsync<IList<FreightResult>>().Result;

            if (shipping_companies == null) return NotFound();

            shipping_companies.OrderBy(x => x.TotalFreight).ToList();
            
            
            var shipping_company = shipping_companies.First();
            


            newOrder.Shipping_Company_Price = shipping_company.TotalFreight;
            newOrder.Shipping_Company = shipping_company.NameCompany;


            _context.Order.Add(newOrder);
            await _context.SaveChangesAsync();

            return Created("criado com sucesso", order.UserId);
        }


        /// <summary>
        /// Cria uma order product
        /// </summary>
        /// <param name="order_id">Insere o id da order/param>
        /// <returns>Cria uma order product</returns>
        /// <response code="204">Registro atualizado.</response>
        /// <response code="400">Requisição incorreta.</response>
        /// <response code="404">Registro não encontrado.</response>
        /// <response code="500">Ocorreu uma exceção durante a consulta</response>
        [HttpPost("order/{order_id}")]
        [Authorize(Roles = "Administrador,Gerente,Usuario")]
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









