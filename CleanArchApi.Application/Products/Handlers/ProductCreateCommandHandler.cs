using CleanArchApi.Application.Products.Commands;
using CleanArchApi.Domain.Entities;
using CleanArchApi.Domain.Interfaces;
using MediatR;

namespace CleanArchApi.Application.Products.Handlers;

public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
{
    private readonly IProductRepository _productRepo;
    public ProductCreateCommandHandler(IProductRepository productRepo)
    {
        _productRepo = productRepo;
    }

    public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(
            request.Name,
            request.Description,
            request.Price,
            request.Stock,
            request.Image);

        if (product is null) throw new ApplicationException("Error creating entity.");

        product.CategoryId = request.CategoryId;

        return await _productRepo.InsertProductAsync(product);
    }
}
