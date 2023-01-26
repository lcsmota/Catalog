using AutoMapper;
using CleanArchApi.Application.DTOs;
using CleanArchApi.Application.Interfaces;
using CleanArchApi.Domain.Entities;
using CleanArchApi.Domain.Interfaces;

namespace CleanArchApi.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepo;
    private readonly IMapper _mapper;
    public CategoryService(ICategoryRepository categoryRepo, IMapper mapper)
    {
        _categoryRepo = categoryRepo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
    {
        return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(
            await _categoryRepo.GetCategoriesAsync());
    }

    public async Task<CategoryDTO> GetCategoryByIdAsync(int? id)
    {
        return _mapper.Map<Category, CategoryDTO>(
            await _categoryRepo.GetCategoryByIdAsync(id));
    }

    public async Task InsertCategoryAsync(CategoryDTO categoryDTO)
    {
        var categoryDb = _mapper.Map<Category>(categoryDTO);
        await _categoryRepo.InsertCategoryAsync(categoryDb);
    }

    public async Task UpdateCategoryAsync(CategoryDTO categoryDTO)
    {
        var categoryDb = _mapper.Map<Category>(categoryDTO);
        await _categoryRepo.UpdateCategoryAsync(categoryDb);
    }

    public async Task DeleteCategoryAsync(int? id)
    {
        var categoryDb = _categoryRepo.GetCategoryByIdAsync(id).Result;
        await _categoryRepo.DeleteCategoryAsync(categoryDb);
    }
}
