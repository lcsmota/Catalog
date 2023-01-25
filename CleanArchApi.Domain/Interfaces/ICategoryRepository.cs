using CleanArchApi.Domain.Entities;

namespace CleanArchApi.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(int? id);
    Task<Category> InsertCategoryAsync(Category category);
    Task<Category> UpdateCategoryAsync(Category category);
    Task DeleteCategoryAsync(Category category);
}
