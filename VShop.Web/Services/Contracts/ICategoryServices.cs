using VShop.Web.Models;

namespace VShop.Web.Services.Contracts;

public interface ICategoryServices
{
    Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync();
    

}
