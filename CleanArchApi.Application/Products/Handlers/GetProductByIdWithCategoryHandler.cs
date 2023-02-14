using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchApi.Application.Products.Queries;
using CleanArchApi.Domain.Entities;
using CleanArchApi.Domain.Interfaces;
using MediatR;

namespace CleanArchApi.Application.Products.Handlers;

public class GetProductByIdWithCategoryHandler : IRequestHandler<GetProductByIdWithCategory, Product>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetProductByIdWithCategoryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Product> Handle(GetProductByIdWithCategory request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.ProductRepo.GetProductWithCategoryAsync(request.Id);
    }
}
