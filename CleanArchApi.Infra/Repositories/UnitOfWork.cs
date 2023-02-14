using CleanArchApi.Domain.Interfaces;
using CleanArchApi.Infra.Context;

namespace CleanArchApi.Infra.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private ICategoryRepository _categoryRepo;
    private IProductRepository _productRepo;
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public ICategoryRepository CategoryRepo
        => _categoryRepo ??= new CategoryRepository(_context);

    public IProductRepository ProductRepo
        => _productRepo ??= new ProductRepository(_context);

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}
