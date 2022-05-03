using DevInSales.Context;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevInSales.Controllers
{
    [Route("api/product")]
    [ApiController]

    public class ProductController : ControllerBase
        {
            private readonly SqlContext _context;

            public ProductController(SqlContext context)
            {
                _context = context;
            }

        

        /// <summary>
        ///atualiza o nome e preço do produto
        /// </summary>
        /// <param name="productModel"></param>
        /// <param name="id"></param>
        /// <returns>atualiza o nome e preço do produto</returns>
        /// <response code="200">Produto Atualizado</response>
        /// <response code="204">Sem nenhum retorno.</response>
        /// <response code="400">Erro ao fazer a Request.</response>
        /// <response code="404">produto inexistente</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPatch("{id}")]
            public async Task<IActionResult> PatchProduct(JsonPatchDocument productModel, int id)
            {

            var product = await _context.Product.FindAsync(id);

            if(product == null)
            {
                return StatusCode(404);
            }
 
            if(product != null)
            {
                productModel.ApplyTo(product);
                if (string.IsNullOrWhiteSpace(product.Name))
                {
                    return StatusCode(404);
                }
                if(product.Suggested_Price <= 0)
                {
                    return StatusCode(404);
                }
                await _context.SaveChangesAsync();
                return StatusCode(204);
            }
            return StatusCode(200);
        }
        }
    } 
