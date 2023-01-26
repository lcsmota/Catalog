using CleanArchApi.Application.DTOs;

namespace CleanArchApi.Application.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
    Task<CategoryDTO> GetCategoryByIdAsync(int? id);
    Task InsertCategoryAsync(CategoryDTO categoryDTO);
    Task UpdateCategoryAsync(CategoryDTO categoryDTO);
    Task DeleteCategoryAsync(int? id);
}
