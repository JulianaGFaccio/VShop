using AutoMapper;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Repositories;

namespace VShop.ProductApi.Services;

public class CategoryServices : ICategoryService
{
    private readonly ICategoryRepository _repo;
    private readonly IMapper _mapper;

    public CategoryServices(ICategoryRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task AddCategory(CategoryDTO categoryDTO)
    {
       var categoryEntity = _mapper.Map<Category>(categoryDTO);
        await _repo.Create(categoryEntity); 
        categoryDTO.Id = categoryEntity.Id;    
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        var categoryEntity = await _repo.GetAll();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoryEntity);   
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
    {
        var categoryEntity = await _repo.GetCategoriesProducts();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoryEntity);
    }

    public async Task<CategoryDTO> GetCategoryById(int id)
    {
        var categoryEntity = await _repo.GetById(id);
        return _mapper.Map<CategoryDTO>(categoryEntity);
    }

    public async Task RemoveCatgory(int id)
    {
        var categoryEntity = _repo.GetById(id).Result;
        await _repo.Delete(categoryEntity.Id);
    }

    public async Task UpdateCategory(CategoryDTO categoryDTO)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDTO);
        await _repo.Update(categoryEntity);
        categoryDTO.Id = categoryEntity.Id; 
    }
}
