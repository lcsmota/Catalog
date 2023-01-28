using CleanArchApi.Domain.Entities;
using MediatR;

namespace CleanArchApi.Application.Products.Commands;

public abstract class ProductCommand : IRequest<Product>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string? Image { get; set; }

    public int CategoryId { get; set; }
}
