namespace CleanArchApi.Domain.Pagination;

public class PagedBaseRequest
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public string OrderByProperty { get; set; }

    public PagedBaseRequest()
    {
        Page = 1;
        PageSize = 12;
        OrderByProperty = "Id";
    }
}

