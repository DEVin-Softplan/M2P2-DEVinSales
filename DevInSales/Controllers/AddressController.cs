#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevInSales.Context;
using DevInSales.Models;
using Microsoft.AspNetCore.JsonPatch;
using DevInSales.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace DevInSales.Controllers
{
    [Route("api/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly SqlContext _context;

        public AddressController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/Addresse
        [HttpGet]
        [Authorize(Roles = "Administrador,Gerente,Usuario")]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddress()
        {
            return await _context.Address.ToListAsync();

        }

        // GET: api/Addresse/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador,Gerente,Usuario")]



        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            var address = await _context.Address.FindAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        [HttpGet("address")]
        [Authorize(Roles = "Administrador,Gerente,Usuario")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        //public async Task<ActionResult<IEnumerable<AddressDTO>>> GetAddress(string CEP, string Street, CityStateDTO CityStateDTO)
        //{

        //    List<Address> retorno = new List<Address>();
        //    if (Street == null)
        //        return Ok(await _context.Address.ToListAsync());

        //    var temporario = await _context.Address.FirstOrDefaultAsync(x => x.Street.Contains(Street));

        //    if (temporario == null)
        //        return NoContent();
        //    retorno.Add(temporario);
        //    return Ok(retorno);
        //}

        public async Task<ActionResult<AddressDTO>> GetAddress(string CEP, string Street, CityStateDTO CityStateDTO)
        {
            //return _sqlContext.Clientes.Include(x => x.Endereco).Select(x => (ClienteDTO)x).ToList();
            var street_find = await _context.Address.FindAsync(Street);
            var cep_find = await _context.Address.FindAsync(CEP);

            if (street_find == null && cep_find == null)
            {
                return NoContent();
               
                List<AddressDTO> addresses = new List<AddressDTO>();
                addresses.Add(new AddressDTO());


            }
            else
            {
                return new AddressDTO();
            }

        }


        // PUT: api/Addresse/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador,Gerente")]

        public async Task<IActionResult> PutAddress(int id, Address address)
        {
            if (id != address.Id)
            {
                return BadRequest();
            }

            _context.Entry(address).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Addresse
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Administrador,Gerente")]

        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
            _context.Address.Add(address);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddress", new { id = address.Id }, address);
        }

        // DELETE: api/Addresse/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
             
                var address = await _context.Address.FirstOrDefaultAsync(e => e.Id == id); 


                var delivery = await _context.Delivery.
                    Include(x => x.Address)
                    .FirstOrDefaultAsync(e=> e.Id ==id);


                if (address == null)
                {
                    return NotFound();
                }
                if (delivery != null)
                {
                    return BadRequest();
                }
                _context.Address.Remove(address);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        private bool AddressExists(int id)
        {
            return _context.Address.Any(e => e.Id == id);
        }


        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPatch("{id}")]
        [Authorize(Roles = "Administrador,Gerente")]

        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<Address> patchAddress)
        {
            try
            {
                if (patchAddress == null)
                {
                    return BadRequest();
                }
                var addressDB = await _context.Address.FirstOrDefaultAsync(cat => cat.Id == id);
                if (addressDB == null)
                {
                    return NotFound();
                }
                patchAddress.ApplyTo(addressDB, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);
                var isValid = TryValidateModel(addressDB);
                if (!isValid)
                {
                    return BadRequest(ModelState);
                }
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }






    }
}
