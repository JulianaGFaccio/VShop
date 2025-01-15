
using AutoMapper;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Repositories;

namespace VShop.ProductApi.Services;

public class ProductService : IProductServices
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task AddProduct(ProductDTO productDTO)
    {
        var productEntity = _mapper.Map<Product>(productDTO);
        await _repository.Create(productEntity);
        productDTO.Id = productEntity.Id;
    }

    public async Task<ProductDTO> GetProductById(int id)
    {
        var productEntity = await _repository.GetProductById(id);
        return _mapper.Map<ProductDTO>(productEntity);
    }

    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var productEntity = await _repository.GetAll();
        return _mapper.Map<IEnumerable<ProductDTO>>(productEntity);
    }

    public async Task RemoveProduct(int id)
    {
        var productEntity = _repository.GetProductById(id).Result;
        await _repository.Delete(productEntity.Id);
    }

    public async Task UpdateProduct(ProductDTO productDTO)
    {
        var productEntity = _mapper.Map<Product>(productDTO);
        await _repository.Update(productEntity);
        productDTO.Id = productEntity.Id;
    }
}
