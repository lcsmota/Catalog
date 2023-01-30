using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchApi.Application.DTOs;

public class ProductDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [MinLength(4), MaxLength(80)]
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required")]
    [MinLength(10), MaxLength(255)]
    [DisplayName("Description")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Price is required")]
    [Column(TypeName = "decimal(6,2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [DataType(DataType.Currency)]
    [DisplayName("Price")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Stock is required")]
    [Range(1, 999)]
    [DisplayName("Stock")]
    public int Stock { get; set; }

    [MaxLength(255)]
    [DisplayName("Image")]
    public string? Image { get; set; }


    [DisplayName("Categories")]
    public int CategoryId { get; set; }
}
