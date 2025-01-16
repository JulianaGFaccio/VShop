using VShop.Web.Models;

namespace VShop.Web.Services.Contracts;

public interface IProductService
{
    Task<IEnumerable<ProductViewModel>> GetProductsAsync(); 
    Task<ProductViewModel> FindProductById(int id);
    Task<ProductViewModel> CreateProduct(ProductViewModel productViewModel);    
    Task<ProductViewModel> UpdateProduct(ProductViewModel productViewModel);    
    Task<bool> Delete(int id);
}
