namespace CleanArchApi.Domain.Pagination;

public class PagedBaseResponse<T>
{
    public List<T> Datas { get; set; }
    public int TotalPages { get; set; }
    public int TotalRegisters { get; set; }
}
