using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanArchApi.Application.DTOs;

public class CategoryDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [MinLength(4), MaxLength(80)]
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;
}
