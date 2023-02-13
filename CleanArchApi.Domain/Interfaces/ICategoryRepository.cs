using CleanArchApi.Domain.Entities;
using CleanArchApi.Domain.FiltersDb;
using CleanArchApi.Domain.Pagination;

namespace CleanArchApi.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(int? id);
    Task<Category> InsertCategoryAsync(Category category);
    Task<Category> UpdateCategoryAsync(Category category);
    Task DeleteCategoryAsync(Category category);

    Task<PagedBaseResponse<Category>> GetPagedAsync(CategoryFilterDb request);
}
