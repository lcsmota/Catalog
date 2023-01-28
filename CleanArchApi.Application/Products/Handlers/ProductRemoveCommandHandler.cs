using CleanArchApi.Application.Products.Commands;
using CleanArchApi.Domain.Entities;
using CleanArchApi.Domain.Interfaces;
using MediatR;

namespace CleanArchApi.Application.Products.Handlers;

public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
{
    private readonly IProductRepository _productRepo;
    public ProductRemoveCommandHandler(IProductRepository productRepo)
    {
        _productRepo = productRepo;
    }
    public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepo.GetProductByIdAsync(request.Id);

        if (product is null) throw new ApplicationException("Entity could not be found.");

        return await _productRepo.DeleteProductAsync(product);
    }
}
