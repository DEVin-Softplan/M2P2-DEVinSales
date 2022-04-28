using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevInSales.Context;

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
