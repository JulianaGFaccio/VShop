using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Services;

namespace VShop.ProductApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryServices;

        public CategoriesController(ICategoryService categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            var categorieDto = await _categoryServices.GetCategories();

            if (categorieDto is null)
            {
                return NotFound("Nao encontrado!");
            }
            return Ok(categorieDto);    
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesProducts()
        {
            var categorieDto = await _categoryServices.GetCategoriesProducts();
            if (categorieDto is null)
            {
                return NotFound("Nao encontrado!");
            }
            return Ok(categorieDto);
        }

        [HttpGet("{id:int}", Name = "CategoryId")]
        public async Task<ActionResult<CategoryDTO>> GetId(int id)
        {
            var catDto = await _categoryServices.GetCategoryById(id);
            if (catDto is null)
            {
                return NotFound("Nao encontrado!");
            }
            return Ok(catDto);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> Post([FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO is null)
            {
                return BadRequest("Valor da categoria esta nulo");
            }

            await _categoryServices.AddCategory(categoryDTO);

            return new CreatedAtRouteResult("CategoryId", new { id = categoryDTO.Id }, categoryDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Update(int id, [FromBody] CategoryDTO categoryDTO)
        {
            if (id != categoryDTO.Id)
            {
                return BadRequest("ID invalido!");
            }
            if (categoryDTO is null)
            {
                return BadRequest("Categoria nula");
            }

          await _categoryServices.UpdateCategory(categoryDTO);  
          return Ok(categoryDTO); 
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var catDto = await _categoryServices.GetCategoryById(id);
            if (catDto is null)
            {
                return BadRequest("id da categoria esta null");
            }

            await _categoryServices.RemoveCatgory(id);
            return Ok(catDto);
        }

    }
}
