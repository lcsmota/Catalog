using CleanArchApi.Domain.Entities;
using MediatR;

namespace CleanArchApi.Application.Products.Queries;

public class GetProductByIdQuery : IRequest<Product>
{
    public int Id { get; set; }

    public GetProductByIdQuery(int id)
    {
        Id = id;
    }
}
