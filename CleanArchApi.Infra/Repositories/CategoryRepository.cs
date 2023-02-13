using CleanArchApi.Domain.Entities;
using CleanArchApi.Domain.FiltersDb;
using CleanArchApi.Domain.Interfaces;
using CleanArchApi.Domain.Pagination;
using CleanArchApi.Infra.Context;
using CleanArchApi.Infra.Pagination;
using Microsoft.EntityFrameworkCore;

namespace CleanArchApi.Infra.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await _context.Categories.AsNoTracking().ToListAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(int? id)
    {
        return await _context.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Category> InsertCategoryAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();

        return category;
    }

    public async Task<Category> UpdateCategoryAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();

        return category;
    }

    public async Task DeleteCategoryAsync(Category category)
    {
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }

    public async Task<PagedBaseResponse<Category>> GetPagedAsync(CategoryFilterDb request)
    {
        var categories = _context.Categories.AsQueryable();

        if (!string.IsNullOrEmpty(request.Name))
            categories = categories.Where(e => e.Name.Contains(request.Name));

        return await PagedBaseResponseHelper
            .GetResponseAsync<PagedBaseResponse<Category>, Category>(categories, request);
    }
}
