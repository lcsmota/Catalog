using CleanArchApi.Application.Products.Queries;
using CleanArchApi.Domain.Entities;
using CleanArchApi.Domain.Interfaces;
using MediatR;

namespace CleanArchApi.Application.Products.Handlers;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
{
    private readonly IProductRepository _productRepo;
    public GetProductsQueryHandler(IProductRepository productRepo)
    {
        _productRepo = productRepo;
    }
    public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return await _productRepo.GetProductsAsync();
    }
}
