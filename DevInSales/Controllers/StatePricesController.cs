using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevInSales.Context;

namespace DevInSales.Controllers
{
    [Route("api/statePrices")]
    [ApiController]
    public class StatePricesController : ControllerBase
    {
        private readonly SqlContext _context;

        public StatePricesController(SqlContext context)
        {
            _context = context;
        }

    }
}
