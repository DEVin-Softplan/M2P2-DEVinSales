using DevInSales.Context;
using DevInSales.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevInSales.Controllers
{
    [ApiController]
    [Route("api/internal/token")]
    public class TokenController : ControllerBase
    {
        private readonly SqlContext _context;
        private readonly TokenService _tokenService;

        public TokenController(SqlContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpGet]
        [Route("generate")]
        public string GenerateToken([FromQuery]string email, [FromQuery] string password)
        {
            var user = _context.User.Where(where => where.Email == email && where.Password == password).Include(include => include.Profile).FirstOrDefault();
            if (user != null)
            {
                return _tokenService.GenerateToken(user);
            }
            else
            {
                return "Usuário inválido!";
            }
        }
            
    }
}
