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
        public async Task<ActionResult<UserPostDTO>> Create([FromBody] UserPostDTO requisicao)
        {
            if (!isDataNascimentoValida(requisicao.BirthDate))
            {
                return BadRequest("O usuário deve ser maior de 18 anos.");
            }

            bool isEmailExistente = _context.User.Any(user => user.Email == requisicao.Email);
            if (isEmailExistente)
            {
                return BadRequest("O email informado já existe.");
            }


            var perfil = await _context.Profile.FindAsync(requisicao.ProfileId);
            if (perfil == null)
            {
                return NotFound("O perfil informado não foi encontrado.");
            }

            return Ok(requisicao);
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
