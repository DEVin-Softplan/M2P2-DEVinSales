using DevInSales.Context;
using DevInSales.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevInSales.Controllers
{
    [Route("api/delivery")]
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="delivery_id"></param>
        /// <param name="delivery_date"></param>
        /// <returns></returns>
        /// <response code="200"></response>
        /// <response code="404"></response>
        /// <response code="500"></response>
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> PatchDelivery(int delivery_id, DateTime delivery_date)
        {
            try
            {
                if (delivery_date.ToString() == null || delivery_id.ToString() == null)
                {
                    return StatusCode(400);
                }

                var deliveryDB = await _context.Delivery.FindAsync(delivery_id);

                if (deliveryDB == null)
                {
                    return StatusCode(404);
                }

                deliveryDB.Delivery_Date = delivery_date;
                deliveryDB.Status = Enums.StatusEnum.PedidoEntregue;
                _context.Entry(deliveryDB).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return StatusCode(200);
            }
            catch
            {
                throw;
            }
        }

    }
}
