using CleanArchApi.Domain.Entities;
using MediatR;

namespace CleanArchApi.Application.Products.Queries;

public class GetProductByIdWithCategory : IRequest<Product>
{
    public int Id { get; set; }
    public GetProductByIdWithCategory(int id)
    {
        Id = id;
    }
}
