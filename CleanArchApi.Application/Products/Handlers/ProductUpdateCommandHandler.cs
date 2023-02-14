using CleanArchApi.Application.Products.Commands;
using CleanArchApi.Domain.Entities;
using CleanArchApi.Domain.Interfaces;
using MediatR;

namespace CleanArchApi.Application.Products.Handlers;

public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
{
    private readonly IUnitOfWork _unitOfWork;
    public ProductUpdateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
    {

        var product = await _unitOfWork.ProductRepo.GetProductByIdAsync(request.Id);

        if (product is null) throw new ApplicationException("Entity could not be found.");

        product.Update(
            request.Name,
            request.Description,
            request.Price,
            request.Stock,
            request.Image,
            request.CategoryId);

        return await _unitOfWork.ProductRepo.UpdateProductAsync(product);

    }
}
