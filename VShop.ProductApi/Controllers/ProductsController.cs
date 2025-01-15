using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Services;

namespace VShop.ProductApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _productService;

        public ProductsController(IProductServices productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
        {
            var prodDto = await _productService.GetProducts();

            if (prodDto is null)
            {
                return NotFound("Produtos nao encontrados");
            }

            return Ok(prodDto);
        }

        [HttpGet("{id:int}" , Name ="GetProduto")]
        public async Task<ActionResult<ProductDTO>> GetById(int id)
        {
            var prod = await _productService.GetProductById(id);

            if (prod is null)
            {
                return NotFound("Produto não encontrado");      
            }
            return Ok(prod);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Post([FromBody] ProductDTO productDTO)
        {
            if (productDTO is null)
            {
                return BadRequest("Produto e nulo");
            }

            await _productService.AddProduct(productDTO);
            return new CreatedAtRouteResult("GetProduto", new { id = productDTO.Id }, productDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProductDTO>> Update(int id, [FromBody] ProductDTO productDTO)
        {
            if (id != productDTO.Id)
            {
                return BadRequest("Id e null");
            }
            if (productDTO is null)
            {
                return BadRequest("produto e nulo");
            }

            await _productService.UpdateProduct(productDTO);    
            return Ok(productDTO);  
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductDTO>> RemoverProduct(int id)
        {
            var prod = await _productService.GetProductById(id);
            if (prod is null)
            {
                return BadRequest("Produto esta nulo");
            }

            await _productService.RemoveProduct(id);
            return Ok(prod);
        }

    }
}
