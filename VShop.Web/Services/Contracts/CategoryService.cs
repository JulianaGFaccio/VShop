using System.Text.Json;
using VShop.Web.Models;

namespace VShop.Web.Services.Contracts;

public class CategoryService : ICategoryServices
{
    private readonly IHttpClientFactory _clienteFactory;
    private readonly JsonSerializerOptions _options;
    private const string apiEndpoint = "/categories/";
    public CategoryService(IHttpClientFactory clienteFactory)
    {
        _clienteFactory = clienteFactory;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true};
    }

    public async Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync()
    {
        var client = _clienteFactory.CreateClient("ProductApi");
        IEnumerable<CategoryViewModel> categories;


        using (var response = await client.GetAsync(apiEndpoint))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiReponse = await response.Content.ReadAsStreamAsync();
                categories = await JsonSerializer.DeserializeAsync<IEnumerable<CategoryViewModel>>(apiReponse, _options);
            }
            else
            {
                return null;
            }
        }

        return categories; ;
    }
}
