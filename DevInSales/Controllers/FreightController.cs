using DevInSales.Freight.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevInSales.Controllers
{
    [Route("freight")]
    [ApiController]
    public class FreightController : ControllerBase
    {
        private readonly IShippingCompanyRepository _shippingCompanyRepository;
        public FreightController(IShippingCompanyRepository shippingCompanyRepository)
        {
            _shippingCompanyRepository = shippingCompanyRepository;
        }

        [HttpGet]
        [Route("Company/{companyId:int}")]
        public IActionResult GetCompanyById(int companyId)
        {
            var company = _shippingCompanyRepository.ObterPorId(companyId);
            if (company == null)
                return NotFound();

            return Ok(company);

        }
    }
}
