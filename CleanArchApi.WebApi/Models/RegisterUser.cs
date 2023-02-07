using System.ComponentModel.DataAnnotations;

namespace CleanArchApi.WebApi.Models;

public class RegisterUser
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    [Compare(nameof(Password), ErrorMessage = "Password don't match")]
    public string? ConfirmPassword { get; set; }
}
