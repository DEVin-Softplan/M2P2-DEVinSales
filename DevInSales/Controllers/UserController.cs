using DevInSales.DTOs;
using DevInSales.Models;
using DevInSales.Context;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

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

        /// <summary>
        /// Consulta lista de usuários.
        /// </summary>
        /// <param name="name">Filtra por nome do usuário.</param>
        /// <param name="birth_date_min">Filtra por data de nascimento mínima.</param>
        /// <param name="birth_date_max">Filtra por data de nascimento máxima.</param>
        /// <returns>Retorna lista de usuários consultados.</returns>
        /// <response code="200">Retorno da lista de usuários consultados.</response>
        /// <response code="400">Requisição inválida.</response>
        /// <response code="404">Usuário não encontrado.</response>
        /// <response code="500">Ocorreu uma exceção durante a consulta.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [Authorize(Roles = "Administrador,Gerente,Usuario")]
        public async Task<ActionResult<IEnumerable<UserResponseDTO>>> Get(
            [FromQuery] string? name, [FromQuery] string? birth_date_min, [FromQuery] string? birth_date_max)
        {
            var consulta = _context.User as IQueryable<User>;
            consulta = consulta.Where(u => u.Profile.Id == 1);

            if (!string.IsNullOrWhiteSpace(name))
            {
                consulta = consulta.Where(u => u.Name.Contains(name));
            }

            if (!string.IsNullOrWhiteSpace(birth_date_min))
            {
                var dataNascimentoMinimia = DateTime.ParseExact(birth_date_min, "dd/MM/yyyy", new CultureInfo("pt-BR"));
                consulta = consulta.Where(u => u.BirthDate >= dataNascimentoMinimia);
            }

            if (!string.IsNullOrWhiteSpace(birth_date_max))
            {
                var dataNascimentoMaxima = DateTime.ParseExact(birth_date_max, "dd/MM/yyyy", new CultureInfo("pt-BR"));
                consulta = consulta.Where(u => u.BirthDate <= dataNascimentoMaxima);
            }

            var usuarios = await consulta.OrderBy(c => c.Name).ToListAsync();
            if (usuarios.Count == 0)
            {
                return NotFound("Nenhum usuário foi encontrado.");
            }

            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<User, UserResponseDTO>());
            var mapper = configuration.CreateMapper();

            return Ok(mapper.Map<List<UserResponseDTO>>(usuarios));
        }

        /// <summary>
        /// Cadastra um novo usuário.
        /// </summary>
        /// <param name="requisicao">Representa as informações do novo usuário.</param>
        /// <returns>Retorna o resultado do User cadastrado.</returns>
        /// <response code="200">Retorno do User cadastrado.</response>
        /// <response code="400">Usuário menor de idade ou email já cadastrado.</response>
        /// <response code="404">Perfil não encontrado.</response>
        /// <response code="500">Ocorreu uma exceção durante o cadastro.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        [Authorize(Roles = "Administrador,Gerente")]
        public async Task<ActionResult<User>> Create([FromBody] UserCreateDTO requisicao)
        {
            try
            {
                var dataNascimento = DateTime.ParseExact(requisicao.BirthDate, "dd/MM/yyyy", new CultureInfo("pt-BR"));
                if (!isMaiorDeIdade(dataNascimento))
                {
                    return BadRequest("O usuário deve ser maior de 18 anos.");
                }
            } catch (Exception ex) {
                return BadRequest("Data inválida.");
            }

            if (!isSenhaValida(requisicao.Password))
            {
                return BadRequest("Senha inválida. Deve-se ter pelo menos um caractere diferente dos demais.");
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

            var novoUsuario = UserCreateDTO.ConverterParaEntidade(requisicao, perfil);
            _context.User.Add(novoUsuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Create", new { id = novoUsuario.Id });
        }

        /// <summary>
        /// Deleta um usuário conforme o Id Informado.
        /// </summary>
        /// <param name="user_id">O Id do usuário para ser deletado.</param>
        /// <returns>Deleta o usuário conforme o Id informado.</returns>
        /// <response code="200">Usuário deletado.</response>
        /// <response code="404">Usuário não encontrado.</response>
        [HttpDelete("{user_id}")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser([FromRoute] int user_id)
        {
            var userIdEncontrado = await _context.User.FindAsync(user_id);
            if (userIdEncontrado == null)
                return NotFound($"O Id de Usuário de número {user_id} não foi encontrado.");
            _context.User.Remove(userIdEncontrado);
            _context.SaveChanges();
            return Ok(user_id);
        }

        private bool isMaiorDeIdade(DateTime dataNascimento)
        {
            DateTime diaAtual = DateTime.Today;
            int idade = diaAtual.Year - dataNascimento.Year;
            if (dataNascimento > diaAtual.AddYears(-idade))
            {
                idade--;
            }
            if (idade >= 18)
            {
                return true;
            }
            return false;
        }

        private bool isSenhaValida(string password)
        {
            var primeiraLetra = password.First();
            foreach(char letra in password)
            {
                if (letra != primeiraLetra)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
