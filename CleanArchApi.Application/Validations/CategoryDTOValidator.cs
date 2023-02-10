using CleanArchApi.Application.DTOs;
using FluentValidation;

namespace CleanArchApi.Application.Validations;

public class CategoryDTOValidator : AbstractValidator<CategoryDTO>
{
    public CategoryDTOValidator()
    {
        RuleFor(e => e.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(4)
            .MaximumLength(80)
            .WithMessage("Name is required");
    }
}
