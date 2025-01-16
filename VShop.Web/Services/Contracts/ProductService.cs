using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Text.Json;
using VShop.Web.Models;

namespace VShop.Web.Services.Contracts;

public class ProductService : IProductService
{
    private readonly IHttpClientFactory _clientFactory;
    private const string apiEndpoint = "/products/";
    private readonly JsonSerializerOptions _options;
    private ProductViewModel _productVM; 
    private IEnumerable<ProductViewModel> _productsVM;    

    public ProductService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true};
    }

    public async Task<IEnumerable<ProductViewModel>> GetProductsAsync()
    {
        var client = _clientFactory.CreateClient("ProductApi");

        using (var response = await client.GetAsync(apiEndpoint))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiReponse = await response.Content.ReadAsStreamAsync();
                _productsVM = await JsonSerializer.DeserializeAsync<IEnumerable<ProductViewModel>>(apiReponse, _options);
            }
            else
            {
                return null;
            }
        }

        return _productsVM;
    }
    public async Task<ProductViewModel> CreateProduct(ProductViewModel productViewModel)
    {
        var client = _clientFactory.CreateClient("ProductApi");

        StringContent content = new StringContent(JsonSerializer.Serialize(_productVM), Encoding.UTF8, "application/json");
        
        using (var response = await client.PostAsync(apiEndpoint, content))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();   

                _productVM = await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _options);
            }
            else
            {
                return null;
            }
        }
        return _productVM;
    }

    public async Task<bool> Delete(int id)
    {
        var client = _clientFactory.CreateClient("ProductApi");

        using (var response = await client.DeleteAsync(apiEndpoint + id))
        {
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
        }
        return false;
    }

    public async Task<ProductViewModel> FindProductById(int id)
    {
        var client = _clientFactory.CreateClient("ProductApi");

        using (var response = await client.GetAsync(apiEndpoint + id))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                _productVM = await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _options);
            }
            else
            {
                return null;
            }
        }
        return _productVM;
    }


    public async Task<ProductViewModel> UpdateProduct(ProductViewModel productViewModel)
    {
        var client = _clientFactory.CreateClient("ProductApi");

        ProductViewModel productUpdate = new ProductViewModel();
        using (var response = await client.PutAsJsonAsync(apiEndpoint, productUpdate))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();

                productUpdate = await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _options);
            }
            else
            {
                return null;
            }
        }
        return productUpdate;
    }

}
