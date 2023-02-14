using CleanArchApi.Application.Products.Commands;
using CleanArchApi.Domain.Entities;
using CleanArchApi.Domain.Interfaces;
using MediatR;

namespace CleanArchApi.Application.Products.Handlers;

public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
{
    private readonly IUnitOfWork _unitOfWork;
    public ProductRemoveCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepo.GetProductByIdAsync(request.Id);

        if (product is null) throw new ApplicationException("Entity could not be found.");

        return await _unitOfWork.ProductRepo.DeleteProductAsync(product);
    }
}
