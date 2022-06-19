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
using Microsoft.AspNetCore.Authorization;

namespace DevInSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly SqlContext _context;

        public StateController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/State
        [HttpGet]
        [Authorize(Roles = "Administrador,Gerente,Usuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<State>>> GetState(string name)
        {
            List<State> retorno = new List<State>();
            if (name == null)
                return Ok(await _context.State.ToListAsync());
            var temp = await _context.State.FirstOrDefaultAsync(x => x.Name.Contains(name));
            if (temp == null)
                return NoContent();
            retorno.Add(temp);
            return Ok(retorno);
        }
        //GET /state/{state_id}/
        [HttpGet("/state/{state_id}")]
        [Authorize(Roles = "Administrador,Gerente,Usuario")]
        public async Task<ActionResult<IEnumerable<State>>> GetStateId(int state_id)
        {
            try
            {
                var result = await _context.State.FindAsync(state_id);
                if (result == null)
                {
                    return NotFound(new { message = "State_Id não encontrado" });
                }
                return Ok(new { message = "State_Id encontrado com sucesso", resultado = result });
            }
            catch (Exception ex)
            {

                throw new Exception($"mensagem, {ex.Message}", ex.InnerException);
            }
        }

        // GET: api/State/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador,Gerente,Usuario")]
        public async Task<ActionResult<State>> GetState(int id)
        {
            var state = await _context.State.FindAsync(id);

            if (state == null)
            {
                return NotFound();
            }

            return state;
        }

        [HttpGet("{State_Id}/city")]
        [Authorize(Roles = "Administrador,Gerente,Usuario")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<CityStateDTO>>> GetByStateIdCity(int State_Id, string name)
        {
            var state = await _context.State.FindAsync(State_Id);

            if (state == null)
                return NotFound();

            var cityList = await _context.City.Include(x => x.State).Where(c => c.State_Id == State_Id).ToListAsync();
            var cityUnity = await _context.City.Include(x => x.State).Where(c => c.State_Id == State_Id).FirstOrDefaultAsync(x => x.Name.Contains(name));

            var listDTO = new List<CityStateDTO>();
            if (name == null)
            {
                foreach (var c in cityList)
                {
                    listDTO.Add(new CityStateDTO
                    {
                        State_Id = State_Id,
                        City_Id = c.Id,
                        Name_City = c.Name,
                        Initials = c.State.Initials,
                        Name_State = c.State.Name
                    });
                }
            }
            else
            {
                if (cityUnity != null)
                {
                    listDTO.Add(new CityStateDTO
                    {
                        City_Id = cityUnity.Id,
                        Name_City = cityUnity.Name,
                        Initials = cityUnity.State.Initials,
                        Name_State = cityUnity.State.Name,
                        State_Id = cityUnity.State.Id,
                    });
                }
                else
                {
                    return NoContent();
                }
            }

            return Ok(listDTO);
        }


        [HttpGet("{State_Id}/city/{City_Id}")]
        [Authorize(Roles = "Administrador,Gerente,Usuario")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CityStateDTO>> GetByStateIdCityId(int State_Id, int City_Id)
        {
            var state_find = await _context.State.FindAsync(State_Id);
            var city_find = await _context.City.FindAsync(City_Id);

            if (state_find == null || city_find == null)
            {
                return NotFound();
            }
            if (city_find.State_Id != State_Id)
                return BadRequest();
            var statecity_include = new CityStateDTO
            {
                State_Id = State_Id,
                City_Id = City_Id,
                Name_City = city_find.Name,
                Name_State = state_find.Name,
                Initials = state_find.Initials
            };

            return Ok(statecity_include);
        }


        // PUT: api/State/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador,Gerente")]
        public async Task<IActionResult> PutState(int id, State state)
        {
            if (id != state.Id)
            {
                return BadRequest();
            }

            _context.Entry(state).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StateExists(id))
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

        // POST: api/State
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{state_id}/city")]
        [Authorize(Roles = "Administrador,Gerente")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<State>> PostState(City city, int state_id)
        {
            var state_findId = await _context.State.FindAsync(state_id);
            var state_findName = await _context.City.FirstOrDefaultAsync(x => x.Name == city.Name && x.State_Id == state_id);

            //Caso não exista nenhum registro de Estado
            if (state_findId == null)
            {
                return NotFound();
            }

            //Caso exista alguma outra cidade criada nesse estado com o mesmo nome enviado
            if (state_findName != null)
            {
                return BadRequest();
            }

            //Criado com sucesso!
            if (city.Name != "")
            {
                city.State_Id = state_id;

                _context.City.Add(city);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetState", new { id = city.Id, name = city.Name, state_id = city.State_Id }, city);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("{state_id}/city/{city_id}/address")]
        [Authorize(Roles = "Administrador,Gerente")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<State>> PostState(Address address, int state_id, int city_id)
        {
            var state_findId = await _context.State.FindAsync(state_id);
            var city_findId = await _context.City.FindAsync(city_id);

            var city_findCityState = await _context.City.FirstOrDefaultAsync(x => x.State_Id == state_id && x.Id == city_id);

            //Caso o state_id seja referente a um estado inexistente ou caso city_id seja de uma
            //cidade inexistente
            if (state_findId == null || city_findId == null)
            {
                return NotFound();
            }

            //Caso a cidade com o city_id enviado tenha um state_id diferente do state_id
            if (city_findCityState == null)
            {
                return BadRequest();
            }

            //Criado com sucesso!
            if (address.Street != "" && address.Number != 0 &&
                address.CEP != "")
            {
                address.City_Id = city_id;

                _context.Address.Add(address);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetState", new
                {
                    id = address.Id,
                    city_id = address.City_Id,
                    street = address.Street,
                    cep = address.CEP,
                    number = address.Number
                }, address);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/State/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteState(int id)
        {
            var state = await _context.State.FindAsync(id);
            if (state == null)
            {
                return NotFound();
            }

            _context.State.Remove(state);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StateExists(int id)
        {
            return _context.State.Any(e => e.Id == id);
        }
    }
}
