using CleanArchApi.Application.Products.Queries;
using CleanArchApi.Domain.Entities;
using CleanArchApi.Domain.Interfaces;
using MediatR;

namespace CleanArchApi.Application.Products.Handlers;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetProductsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.ProductRepo.GetProductsAsync();
    }
}
