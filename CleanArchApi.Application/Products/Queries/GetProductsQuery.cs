using CleanArchApi.Domain.Entities;
using MediatR;

namespace CleanArchApi.Application.Products.Queries;

public class GetProductsQuery : IRequest<IEnumerable<Product>>
{

}
