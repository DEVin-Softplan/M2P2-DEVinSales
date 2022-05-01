using DevInSales.DTOs;
using DevInSales.Context;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace DevInSales.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SqlContext _context;

        public UserController(SqlContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<UserPostDTO>> Create([FromBody] UserPostDTO userDTO)
        {
            if (!isDataNascimentoValida(userDTO.BirthDate))
            {
                return BadRequest("O usuário deve ser maior de 18 anos.");
            }

            var perfil = await _context.Profile.FindAsync(userDTO.ProfileId);
            if (perfil == null)
            {
                return NotFound("O perfil informado não foi encontrado.");
            }

            return Ok(userDTO);
        }

        private bool isDataNascimentoValida(string data)
        {
            DateTime dataNascimento = DateTime.ParseExact(data, "dd/MM/yyyy", new CultureInfo("pt-BR"));
            DateTime diaAtual = DateTime.Today;
            int idade = diaAtual.Year - dataNascimento.Year;
            if (idade > 18)
            {
                return true;
            }
            return false;
        }
    }
}
