using DevInSales.Context;
using DevInSales.Models;
using Microsoft.AspNetCore.Authorization;
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
        /// Buscar registros de delivery com id do endereço e id da order
        /// </summary>
        /// <param name="address_id">Filtra pelo id do endereço</param>
        /// <param name="order_id">Filtra pelo id da order</param>
        /// <returns>Buscar registros de delivery com id do endereço e id da order</returns>
        /// <response code="200"></response>
        /// <response code="204"></response>
        /// <response code="500"></response>
        [HttpGet]
        [Authorize(Roles = "Administrador,Gerente,Usuario")]
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
        /// Atualiza data de entrega e status do delivery
        /// </summary>
        /// <param name="delivery_id">Filtra pelo id da delivery</param>
        /// <param name="delivery_date">Insere a data de entrega</param>
        /// <returns>Atualiza data de entrega e status do delivery</returns>
        /// <response code="200"></response>
        /// <response code="404"></response>
        /// <response code="500"></response>
        [HttpPatch]
        [Authorize(Roles = "Administrador,Gerente")]
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

        /// <summary>
        /// Cria uma delivery
        /// </summary>
        /// <param name="order_id">Insere a order</param>
        /// <param name="address_id">Insere o endereco</param>
        /// <returns>Cria uma delivery</returns>
        /// <response code="200"></response>
        /// <response code="404"></response>
        /// <response code="400"></response>
        /// <response code="500"></response>
        [HttpPost("order/{order_id}/delivery")]
        [Authorize(Roles = "Administrador,Gerente")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> PostDelivery(int order_id, int address_id, DateTime delivery_forecast)
        {
            try
            {
                var orderDB = await _context.Order.FindAsync(order_id);
                var addressDB = await _context.Address.FindAsync(address_id);

                if (orderDB == null || addressDB == null)
                {
                    return StatusCode(400);
                }

                if (address_id.ToString() == null)
                {
                    return StatusCode(400);
                }

                if (delivery_forecast < DateTime.Now)
                {
                    return StatusCode(400);
                }

                var delivery = new Delivery { Address = addressDB, Delivery_Date = null, Delivery_Forecast = delivery_forecast, Order = orderDB, Status = Enums.StatusEnum.PedidoEmTransporte };
                _context.Delivery.Add(delivery);
                await _context.SaveChangesAsync();

                return StatusCode(201);

            }
            catch
            {
                throw;
            }
        }
    }
}
