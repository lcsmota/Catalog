using AutoMapper;
using CleanArchApi.Application.DTOs;
using CleanArchApi.Application.Interfaces;
using CleanArchApi.Application.Products.Commands;
using CleanArchApi.Application.Products.Queries;
using CleanArchApi.Domain.Entities;
using CleanArchApi.Domain.Interfaces;
using MediatR;

namespace CleanArchApi.Application.Services;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    public ProductService(IProductRepository productRepo, IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
    {
        var productQuery = new GetProductsQuery();

        if (productQuery is null)
            throw new Exception("Entity could not be loaded.");

        var productsCommand = await _mediator.Send(productQuery);

        return _mapper.Map<IEnumerable<ProductDTO>>(productsCommand);
    }

    public async Task<ProductDTO> GetProductByIdAsync(int? id)
    {
        var productQuery = new GetProductByIdQuery(id.Value);

        if (productQuery is null)
            throw new Exception("Entity could not be loaded.");

        var productCommand = await _mediator.Send(productQuery);

        return _mapper.Map<ProductDTO>(productCommand);
    }

    public async Task<ProductDTO> GetProductWithCategoryAsync(int? id)
    {
        var productQuery = new GetProductByIdWithCategory(id.Value);

        if (productQuery is null)
            throw new Exception("Entity could not be loaded.");

        var productCommand = await _mediator.Send(productQuery);

        return _mapper.Map<ProductDTO>(productCommand);
    }

    public async Task InsertProductAsync(ProductDTO productDTO)
    {
        var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
        await _mediator.Send(productCreateCommand);
    }

    public async Task UpdateProductAsync(ProductDTO productDTO)
    {
        var productUpdateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
        await _mediator.Send(productUpdateCommand);
    }

    public async Task DeleteProductAsync(int? id)
    {
        var productDeleteCommand = new ProductRemoveCommand(id.Value);

        if (productDeleteCommand is null)
            throw new Exception("Entity could not be loaded.");

        await _mediator.Send(productDeleteCommand);
    }
}
