namespace CleanArchApi.Domain.Interfaces;

public interface IUnitOfWork
{
    ICategoryRepository CategoryRepo { get; }
    IProductRepository ProductRepo { get; }
    Task CommitAsync();
}
