using AutoMapper;
using CleanArchApi.Application.DTOs;
using CleanArchApi.Application.Interfaces;
using CleanArchApi.Domain.Entities;
using CleanArchApi.Domain.Interfaces;

namespace CleanArchApi.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepo;
    private readonly IMapper _mapper;
    public ProductService(IProductRepository productRepo, IMapper mapper)
    {
        _productRepo = productRepo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
    {
        return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(
            await _productRepo.GetProductsAsync());
    }

    public async Task<ProductDTO> GetProductByIdAsync(int? id)
    {
        return _mapper.Map<Product, ProductDTO>(
            await _productRepo.GetProductByIdAsync(id));
    }

    public async Task<ProductDTO> GetProductWithCategoryAsync(int? id)
    {
        return _mapper.Map<Product, ProductDTO>(
            await _productRepo.GetProductWithCategoryAsync(id));
    }

    public async Task InsertProductAsync(ProductDTO productDTO)
    {
        var productDb = _mapper.Map<Product>(productDTO);
        await _productRepo.InsertProductAsync(productDb);
    }

    public async Task UpdateProductAsync(ProductDTO productDTO)
    {
        var productDb = _mapper.Map<Product>(productDTO);
        await _productRepo.UpdateProductAsync(productDb);
    }

    public async Task DeleteProductAsync(int? id)
    {
        var productDb = _productRepo.GetProductByIdAsync(id).Result;
        await _productRepo.DeleteProductAsync(productDb);
    }
}
