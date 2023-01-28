using CleanArchApi.Application.Products.Commands;
using CleanArchApi.Domain.Entities;
using CleanArchApi.Domain.Interfaces;
using MediatR;

namespace CleanArchApi.Application.Products.Handlers;

public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
{
    private readonly IProductRepository _productRepo;
    public ProductUpdateCommandHandler(IProductRepository productRepo)
    {
        _productRepo = productRepo;
    }

    public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
    {

        var product = await _productRepo.GetProductByIdAsync(request.Id);

        if (product is null) throw new ApplicationException("Entity could not be found.");

        product.Update(
            request.Name,
            request.Description,
            request.Price,
            request.Stock,
            request.Image,
            request.CategoryId);

        return await _productRepo.UpdateProductAsync(product);

    }
}
