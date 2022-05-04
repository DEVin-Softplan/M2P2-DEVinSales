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
using DevInSales.DTOs;

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
        public async Task<ActionResult<IEnumerable<Address>>> GetAddress()
        {
            return await _context.Address.ToListAsync();

        }

        // GET: api/Addresse/5
        [HttpGet("{id}")]



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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<AddressDTO>> GetAddress(string CEP, string Street, int City_Id, int State_Id)
        {
            if (Street == null && CEP == null && City_Id == null && State_Id == null)
            {
                return Ok(_context.Address.ToListAsync());
            }
            var street_find = await _context.Address.Include(x => x.City.State).FirstOrDefaultAsync(x => x.Street.Contains(Street));
            var cep_find = await _context.Address.Include(x => x.City.State).FirstOrDefaultAsync(x => x.CEP == CEP);
            var city_find = await _context.Address.Include(x => x.City.State).FirstOrDefaultAsync(x => x.City_Id == City_Id);
            var state_find = await _context.Address.Include(x => x.City.State).FirstOrDefaultAsync(x => x.Id == State_Id);

            if (street_find != null)
                return Ok(street_find);
            if (cep_find != null)
                return Ok(cep_find);
            if (city_find != null)
                return Ok(city_find);
            if (state_find != null)
                return Ok(state_find);

            return NoContent();

        }




        // PUT: api/Addresse/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
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
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
            _context.Address.Add(address);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddress", new { id = address.Id }, address);
        }

        // DELETE: api/Addresse/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var address = await _context.Address.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            _context.Address.Remove(address);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddressExists(int id)
        {
            return _context.Address.Any(e => e.Id == id);
        }
    }
}
