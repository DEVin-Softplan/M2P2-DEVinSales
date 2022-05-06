using DevInSales.Context;
using DevInSales.DTOs;
using DevInSales.Models;
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
        [Route("company/{id:int}")]
        public async Task<ActionResult<ShippingCompany>> GetCompanyById(int id)
        {
            var company = await _context.ShippingCompany.FindAsync(id);
            if (company == null)
                return NotFound();

            return Ok(company);
        }

        [HttpGet]
        [Route("state/{stateId:int}/company/{companyId:int}")]
        public async Task<ActionResult<List<StatePrice>>> GetStateCompanyById(int stateId, int companyId)
        {

            if (!CompanyExist(companyId))
                return NotFound();

            var tabelaPreco = _context.StatePrice.Where(sp => sp.ShippingCompanyId == companyId && sp.StateId == stateId).ToList();

            return Ok(tabelaPreco);

        }

        private bool CompanyExist(int companyId)
        {
            return _context.StatePrice.Find(companyId) != null;

        }

        [HttpGet]
        [Route("city/{cityId:int}/company/{companyId:int}")]
        public async Task<ActionResult<List<CityPrice>>> GetCityCompanyById(int cityId, int companyId)
        {

            if (!CompanyExist(companyId))
                return NotFound();

            var tabelaPreco = _context.CityPrice.Where(sp => sp.ShippingCompanyId == companyId && sp.CityId == cityId).ToList();

            return Ok(tabelaPreco);

        }

        [HttpPost]
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
    }
}
