using DevInSales.Context;
using DevInSales.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevInSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        
        private readonly SqlContext _context;

        public DeliveryController(SqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address_id"></param>
        /// <param name="order_id"></param>
        /// <returns></returns>
        /// <response code="200"></response>
        /// <response code="204"></response>
        /// <response code="500"></response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ICollection<Delivery>>> GetDelivery(int address_id, int order_id)
        {
            var deliverys = _context.Delivery.Include(x => x.Order).Include(x => x.Address).ToList();
                


            if (address_id == 0 && order_id == 0)
            {
                return Ok(deliverys);
            }
            if (address_id == 0 && order_id != 0)
            {
                deliverys = _context.Delivery.Include(x => x.Order).Include(x => x.Address).ToList().FindAll(x => x.Order.Id == order_id);
            }
            if (address_id != 0 && order_id == 0)
            {
                deliverys = _context.Delivery.Include(x => x.Order).Include(x => x.Address).ToList().FindAll(x => x.Address.Id == address_id);
            }
            if (address_id != 0 && order_id != 0)
            {
                deliverys = _context.Delivery.Include(x => x.Order).Include(x => x.Address).ToList().FindAll(x => x.Order.Id == order_id && x.Address.Id == address_id);
            }

            if (deliverys.Count() == 0)
            {
                return NoContent();
            }
            return Ok(deliverys); 
        }

    }
}
