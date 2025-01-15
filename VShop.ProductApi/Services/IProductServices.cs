using VShop.ProductApi.DTOs;

namespace VShop.ProductApi.Services
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProductById(int id);
        Task AddProduct(ProductDTO productDTO);
        Task RemoveProduct(int id);
        Task UpdateProduct(ProductDTO productDTO);
    }
}
