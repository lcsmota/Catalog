namespace CleanArchApi.Application.DTOs;

public class PagedBaseResponseDTO<T>
{
    public List<T> Datas { get; set; }
    public int TotalRegisters { get; set; }

    public PagedBaseResponseDTO(int totalRegisters, List<T> datas)
    {
        Datas = datas;
        TotalRegisters = totalRegisters;
    }
}
