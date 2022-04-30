using DevInSales.Context;
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

                return listaVendas;
            }
            catch
            {
                return StatusCode(404);
            }
        }
    }
}
