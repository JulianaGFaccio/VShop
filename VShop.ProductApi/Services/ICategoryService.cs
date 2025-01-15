using VShop.ProductApi.DTOs;

namespace VShop.ProductApi.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetCategories();
    Task<IEnumerable<CategoryDTO>> GetCategoriesProducts();
    Task<CategoryDTO> GetCategoryById(int id);
    Task AddCategory(CategoryDTO categoryDTO);
    Task RemoveCatgory(int id);
    Task UpdateCategory(CategoryDTO categoryDTO);  
}
