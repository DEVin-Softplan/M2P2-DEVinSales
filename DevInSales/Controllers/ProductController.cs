using DevInSales.Context;
using DevInSales.DTOs;
using DevInSales.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevInSales.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly SqlContext _sqlContext;

        public ProductController(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        /// <summary>
        /// Cadastra um novo Produto
        /// </summary>
        /// <param name="requisicao">Representa as informações do novo Produto.</param>
        /// <returns>Retorna o novo Produto cadastrado.</returns>
        /// <response code="201">Insercao realizada com sucesso.</response>
        /// <response code="400">Produto com mesmo nome já cadastrado, ou preço sugerido menor ou igual à 0.</response>
        /// <response code="404">Produto não encontrado.</response>
        /// <response code="500">Ocorreu uma exceção durante o cadastro.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Product>> Create([FromBody] ProductPostAndPutDTO requisicao)
        {
            bool isProductExistente = _sqlContext.Product.Any(product => product.Name == requisicao.Name);
            
            if (isProductExistente)
                return BadRequest("O nome do produto já existe.");

            if (requisicao.Suggested_Price <= 0)
                return BadRequest("O preço sugerido não pode ser menor ou igual a 0.");

            var newProduct = ProductPostAndPutDTO.ConverterParaEntidade(requisicao);
            _sqlContext.Product.Add(newProduct);
            await _sqlContext.SaveChangesAsync();

            return CreatedAtAction("Create", new { id = newProduct.Id }, newProduct);
        }
    }
}
