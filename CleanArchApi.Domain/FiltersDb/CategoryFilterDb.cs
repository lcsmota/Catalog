using CleanArchApi.Domain.Pagination;

namespace CleanArchApi.Domain.FiltersDb;

public class CategoryFilterDb : PagedBaseRequest
{
    public string? Name { get; set; }
}
