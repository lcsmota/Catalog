using CleanArchApi.Domain.Entities;

namespace CleanArchApi.Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product> GetProductByIdAsync(int? id);
    Task<Product> GetProductWithCategoryAsync(int? id);
    Task<Product> InsertProductAsync(Product product);
    Task<Product> UpdateProductAsync(Product product);
    Task<Product> DeleteProductAsync(Product product);
}
