using DevInSales.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DevInSales.Controllers
{
    [Route("freight")]
    [ApiController]
    public class FreightController : ControllerBase
    {
        private readonly IShippingCompanyRepository _shippingCompanyRepository;
        private readonly IStatePriceRepository _statePriceRepository;
        private readonly IStateRepository _stateRepository;

        public FreightController(IShippingCompanyRepository shippingCompanyRepository,
                                 IStatePriceRepository statePriceRepository,
                                 IStateRepository stateRepository)
        {
            _shippingCompanyRepository = shippingCompanyRepository;
            _statePriceRepository = statePriceRepository;
            _stateRepository = stateRepository;
        }

        [HttpGet]
        [Route("company/{companyId:int}")]
        public IActionResult GetCompanyById(int companyId)
        {
            var company = _shippingCompanyRepository.ObterPorId(companyId);
            if (company == null)
                return NotFound();

            return Ok(company);

        }

        [HttpGet]
        [Route("state/{stateId:int}/company/{companyId:int}")]
        public IActionResult GetStateCompanyById(int stateId, int companyId)
        {

            if (!CompanyExist(companyId))
                return NotFound();

            var tabelaPreco = _statePriceRepository.Buscar(c => c.ShippingCompanyId == companyId && c.StateId == stateId).Select(c => new { BasePreco = c.BasePrice });

            return Ok(tabelaPreco);

        }

        private bool CompanyExist(int companyId)
        {
            return _shippingCompanyRepository.ObterPorId(companyId) != null;

        }

        [HttpPost]
        [Route("state/company")]

        public IActionResult PostStateCompany(IEnumerable<DTOs.StatePrice> statesPrices)
        {
            if (!ExistStateAndCompany(statesPrices))
                return NotFound();

            var statesPricesEntity = MappingEntity(statesPrices);

            _statePriceRepository.RegistrarLista(statesPricesEntity);

            if (_statePriceRepository.Commit() > 0)
                return Created("",statesPricesEntity);

            return BadRequest();

        }

        private IList<StatePrice> MappingEntity(IEnumerable<DTOs.StatePrice> statesPricesDto)
        {
            var statesPrices = statesPricesDto.Select(s => new StatePrice
            {
                ShippingCompanyId = s.ShippingCompanyId,
                StateId = s.StateId,
                BasePrice = s.BasePrice
            });

            return statesPrices.ToList();
        }

        private bool ExistStateAndCompany(IEnumerable<DTOs.StatePrice> statesPrices)
        {
            var listCompany = statesPrices.Select(sp => sp.ShippingCompanyId).Distinct();
            var listState = statesPrices.Select(sp => sp.StateId).Distinct();
            var companiesCount = _shippingCompanyRepository.Buscar(sc => listCompany.Contains(sc.Id)).Count();
            var statesCount = _stateRepository.Buscar(s => listState.Contains(s.Id)).Count();

            if (companiesCount != listCompany.Count() || statesCount != listState.Count())
                return false;

            return true;

        }
    }
}
