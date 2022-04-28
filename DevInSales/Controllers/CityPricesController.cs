using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevInSales.Context;

namespace DevInSales.Controllers
{
    [Route("api/cityPrices")]
    [ApiController]
    public class CityPricesController : ControllerBase
    {
        private readonly SqlContext _context;

        public CityPricesController (SqlContext context)
        {
            _context = context;
        }

    }
}
