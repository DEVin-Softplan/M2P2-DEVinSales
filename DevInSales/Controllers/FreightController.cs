using DevInSales.Context;
using DevInSales.DTOs;
using DevInSales.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevInSales.Controllers
{
    [Route("api/freight")]
    [ApiController]
    public class FreightController : ControllerBase
    {
        private readonly SqlContext _context;

        public FreightController(SqlContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Administrador,Gerente,Usuario")]
        [Route("{cityId:int}")]
        public ActionResult<IList<FreightResult>> GetFreight(int cityId)
        {
            var cityPricesQueryable = _context.CityPrice.AsQueryable();
            var cityQueryable = _context.City.AsQueryable();
            var companyQueryable = _context.ShippingCompany.AsQueryable();
            var statePriceQueryable = _context.StatePrice.AsQueryable();

            var result = (from cityprice in cityPricesQueryable.Where(c => c.CityId == cityId)
                          from city in cityQueryable.Where(c => c.Id == cityprice.CityId)
                          from statePrice in statePriceQueryable.Where(sp => sp.StateId == city.State_Id)
                          from company in companyQueryable.Where(sc => sc.Id == cityprice.ShippingCompanyId && sc.Id == statePrice.ShippingCompanyId)
                          select new FreightResult { NameCompany = company.Name, TotalFreight = statePrice.BasePrice + cityprice.BasePrice })
                          .OrderBy(r => r.TotalFreight).ToList();

            if (!result.Any())
                return NotFound();

            return result;
        }

        [HttpGet]
        [Authorize(Roles = "Administrador,Gerente,Usuario")]
        [Route("company/name")]
        public async Task<ActionResult<IEnumerable<ShippingCompany>>> GetCompanyByName(string? name)
        {
            if (name == null)
                return Ok(await _context.ShippingCompany.ToListAsync());

            var consulta = _context.ShippingCompany as IQueryable<ShippingCompany>;
            consulta = consulta.Where(x => x.Name.Contains(name));
            var result = await consulta.OrderBy(c => c.Name).ToListAsync();
            if (!result.Any())
                return NotFound();
            return Ok(result);
        }


        [HttpGet]
        [Authorize(Roles = "Administrador,Gerente,Usuario")]
        [Route("company/{id:int}")]
        public async Task<ActionResult<ShippingCompany>> GetCompanyById(int id)
        {
            var company = await _context.ShippingCompany.FindAsync(id);
            if (company == null)
                return NotFound();

            return Ok(company);
        }

        [HttpGet]
        [Authorize(Roles = "Administrador,Gerente,Usuario")]
        [Route("state/{stateId:int}/company/{companyId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<StatePrice>>> GetStateCompanyById(int stateId, int companyId)
        {
            try
            {
                var tabelaPreco = _context.StatePrice.Where(sp => sp.ShippingCompanyId == companyId && sp.StateId == stateId).ToList();

                if (tabelaPreco.Count == 0)
                    return NotFound();

                return Ok(tabelaPreco);

            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Administrador,Gerente,Usuario")]
        [Route("city/{cityId:int}/company/{companyId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<CityPrice>>> GetCityCompanyById(int cityId, int companyId)
        {
            try
            {
                var tabelaPreco = _context.CityPrice.Where(sp => sp.ShippingCompanyId == companyId && sp.CityId == cityId).ToList();
                if (tabelaPreco.Count == 0)
                    return NotFound();

                return Ok(tabelaPreco);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador,Gerente")]
        [Route("state/company")]
        public async Task<ActionResult<List<StatePriceDTO>>> PostStateCompany(IEnumerable<StatePriceDTO> statePrices)
        {
            if (!ExistStateAndCompany(statePrices))
                return NotFound();

            var statePricesEnity = GetStatePrices(statePrices);
            _context.StatePrice.AddRange(statePricesEnity);

            if (await _context.SaveChangesAsync() > 0)
                return Created("", statePrices);

            return BadRequest();

        }
        private bool ExistStateAndCompany(IEnumerable<StatePriceDTO> statePrices)
        {
            var listCompany = statePrices.Select(sp => sp.ShippingCompanyId).Distinct();
            var listStates = statePrices.Select(sp => sp.StateId).Distinct();
            var companiesCount = _context.ShippingCompany.Where(sc => listCompany.Contains(sc.Id)).Count();
            var statesCount = _context.State.Where(s => listStates.Contains(s.Id)).Count();

            if (companiesCount != listCompany.Count() || statesCount != listStates.Count())
                return false;

            return true;
        }

        private IEnumerable<StatePrice> GetStatePrices(IEnumerable<StatePriceDTO> statePrices)
        {
            return statePrices.Select(cp => new StatePrice
            {
                StateId = cp.StateId,
                ShippingCompanyId = cp.ShippingCompanyId,
                BasePrice = cp.BasePrice,
            });
        }

        [HttpPost]
        [Route("city/company")]
        [Authorize(Roles = "Administrador,Gerente,Usuario")]

        public async Task<ActionResult<List<CityPriceDTO>>> PostCityCompany(IEnumerable<CityPriceDTO> cityPrices)
        {
            if (!ExistCityAndCompany(cityPrices))
                return NotFound();

            var cityPricesEnity = GetCityPrices(cityPrices);
            _context.CityPrice.AddRange(cityPricesEnity);

            if (await _context.SaveChangesAsync() > 0)
                return Created("", cityPrices);

            return BadRequest();

        }

        private bool ExistCityAndCompany(IEnumerable<CityPriceDTO> cityPrices)
        {
            var listCompany = cityPrices.Select(sp => sp.ShippingCompanyId).Distinct();
            var listCities = cityPrices.Select(sp => sp.CityId).Distinct();
            var companiesCount = _context.ShippingCompany.Where(sc => listCompany.Contains(sc.Id)).Count();
            var citiesCount = _context.City.Where(s => listCities.Contains(s.Id)).Count();

            if (companiesCount != listCompany.Count() || citiesCount != listCities.Count())
                return false;

            return true;
        }

        private IEnumerable<CityPrice> GetCityPrices(IEnumerable<CityPriceDTO> cityPrices)
        {
            return cityPrices.Select(cp => new CityPrice
            {
                CityId = cp.CityId,
                ShippingCompanyId = cp.ShippingCompanyId,
                BasePrice = cp.BasePrice,
            });
        }

        [HttpDelete]
        [Route("city/{cityPriceId}")]
        [Authorize(Roles = "Administrador")]

        public async Task<IActionResult> DeleteCityPrice(int cityPriceId)
        {
            var cityPrice = await _context.CityPrice.FindAsync(cityPriceId);
            if (cityPrice == null)
                return NotFound();

            _context.CityPrice.Remove(cityPrice);

            if ((await _context.SaveChangesAsync()) > 0)
                return NoContent();

            return BadRequest();
        }

        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        [Route("state/{statePriceId}")]
        public async Task<IActionResult> DeleteStatePrice(int statePriceId)
        {
            var statePrice = await _context.StatePrice.FindAsync(statePriceId);
            if (statePrice == null)
                return NotFound();

            _context.StatePrice.Remove(statePrice);

            if ((await _context.SaveChangesAsync()) > 0)
                return NoContent();

            return BadRequest();
        }
    }
}
