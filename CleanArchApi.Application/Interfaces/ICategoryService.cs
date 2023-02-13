using CleanArchApi.Application.DTOs;
using CleanArchApi.Application.Services;
using CleanArchApi.Domain.FiltersDb;

namespace CleanArchApi.Application.Interfaces;

public interface ICategoryService
{
    Task<ResultService<IEnumerable<CategoryDTO>>> GetCategoriesAsync();
    Task<ResultService<CategoryDTO>> GetCategoryByIdAsync(int? id);
    Task<ResultService<CategoryDTO>> InsertCategoryAsync(CategoryDTO categoryDTO);
    Task<ResultService> UpdateCategoryAsync(CategoryDTO categoryDTO);
    Task<ResultService> DeleteCategoryAsync(int? id);

    Task<ResultService<PagedBaseResponseDTO<CategoryDTO>>> GetPagedAsync(CategoryFilterDb categoryFilterDb);
}
