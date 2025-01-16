using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VShop.Web.Models;
using VShop.Web.Services.Contracts;

namespace VShop.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryServices _categoryServices;

        public ProductsController(IProductService productService, ICategoryServices categoryServices)
        {
            _productService = productService;
            _categoryServices = categoryServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> Index()
        {
            var result = await _productService.GetProductsAsync();
            if (result is null)
            {
                return View("Error");
            }
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.CategoryId = new SelectList(await _categoryServices.GetCategoriesAsync(), "Id" ,"Name");  
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductViewModel productVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.CreateProduct(productVM);
                if (result != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                ViewBag.CategoryId = new SelectList(await _categoryServices.GetCategoriesAsync(), "Id", "Name");
            }
            return View(productVM);
        }


    }
}
