using DevInSales.Freight.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevInSales.Controllers
{
    [Route("freight")]
    [ApiController]
    public class FreightController : ControllerBase
    {
        private readonly IShippingCompanyRepository _shippingCompanyRepository;
        private readonly IStatePriceRepository _statePriceRepository;
        public FreightController(IShippingCompanyRepository shippingCompanyRepository,
                                 IStatePriceRepository statePriceRepository)
        {
            _shippingCompanyRepository = shippingCompanyRepository;
            _statePriceRepository = statePriceRepository;
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
        public IActionResult GetStateCompanyById(int stateId,int companyId)
        {
            
            if (!CompanyExist(companyId))
                return NotFound();

            var tabelaPreco = _statePriceRepository.Buscar(c => c.ShippingCompanyId == companyId && c.StateId == stateId).Select(c=> new { BasePreco = c.BasePreco }) ;

            return Ok(tabelaPreco);

        }

        private bool CompanyExist(int companyId)
        {
            return _shippingCompanyRepository.ObterPorId(companyId)!=null;

        }
    }
}
