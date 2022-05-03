using DevInSales.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        
        
        
    }
}
