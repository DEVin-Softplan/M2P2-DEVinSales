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
        /// Consulta a lista de Produtos
        /// </summary>
        /// <param name="name">Filtra o produto por nome</param>
        /// <param name="price_min">Delimita um preço mínimo na consulta do produto</param>
        /// <param name="price_max">Delimita um preço máximo na consulta do produto</param>
        [HttpGet(Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProductGetDTO>>> GetProduct(string? name, decimal? price_min, decimal? price_max)
        {
            if (price_max < price_min)
                return BadRequest("O Preço Máximo não pode ser menor que o Preço Mínimo.");

            var productQuery = _sqlContext.Product as IQueryable<Product>;
            if (!string.IsNullOrWhiteSpace(name))
                productQuery = productQuery.Where(p => p.Name.Contains(name));

            if (price_min.HasValue)
                productQuery = productQuery.Where(p => p.Suggested_Price >= price_min.Value);

            if (price_max.HasValue)
                productQuery = productQuery.Where(p => p.Suggested_Price <= price_max.Value);

            List<Product> productResult = productQuery
              .Include(x => x.Category)
              .ToList();

            var retorno = new List<ProductGetDTO>();
            foreach (var product_unit in productResult)
            {
                retorno.Add((ProductGetDTO)product_unit);
            }

            return (retorno?.Any() ?? false) ? Ok(retorno) : NoContent();
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
        public async Task<ActionResult<Product>> CreateProduct([FromBody] ProductPostAndPutDTO requisicao)
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
