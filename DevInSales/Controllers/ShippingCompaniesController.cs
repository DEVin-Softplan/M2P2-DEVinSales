using DevInSales.Context;
using Microsoft.AspNetCore.Mvc;

namespace DevInSales.Controllers
{
    [Route("api/shippingCompanies")]
    [ApiController]
    public class ShippingCompaniesController : ControllerBase
    {
        private readonly SqlContext _context;

        public ShippingCompaniesController(SqlContext context)
        {
            _context = context;
        }

    }
}
