using DevInSales.Context;
using DevInSales.DTOs;
using DevInSales.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevInSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly SqlContext _context;

        public UserLoginController(SqlContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] UserLoginDTO login)
        {
            var user = _context.User.FirstOrDefault(x => x.Name == login.Name && x.Password == login.Password);
            if (user == null)
                return BadRequest(new { message = "usuário ou senha invalidos" });

            var token = TokenServices.GenerateTolken(user);


            return Ok(token);
        }
    }
}
