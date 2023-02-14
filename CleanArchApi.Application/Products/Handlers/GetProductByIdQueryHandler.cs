using CleanArchApi.Application.Products.Queries;
using CleanArchApi.Domain.Entities;
using CleanArchApi.Domain.Interfaces;
using MediatR;

namespace CleanArchApi.Application.Products.Handlers;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetProductByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.ProductRepo.GetProductByIdAsync(request.Id);
    }
}
