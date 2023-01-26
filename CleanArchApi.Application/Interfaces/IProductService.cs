using CleanArchApi.Application.DTOs;

namespace CleanArchApi.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetProductsAsync();
    Task<ProductDTO> GetProductByIdAsync(int? id);
    Task<ProductDTO> GetProductWithCategoryAsync(int? id);
    Task InsertProductAsync(ProductDTO productDTO);
    Task UpdateProductAsync(ProductDTO productDTO);
    Task DeleteProductAsync(int? id);
}
