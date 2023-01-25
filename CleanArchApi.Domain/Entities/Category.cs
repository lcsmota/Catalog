using CleanArchApi.Domain.Validation;

namespace CleanArchApi.Domain.Entities;

public sealed class Category : Entity
{
    public string Name { get; private set; } = string.Empty;
    public ICollection<Product> Products { get; set; } = new List<Product>();

    public Category(int id, string name)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id. Id must be greater than 0.");
        Id = id;

        ValidateDomainName(name);
    }

    public Category(string name)
    {
        ValidateDomainName(name);
    }

    public void ChangeName(string name)
    {
        ValidateDomainName(name);
    }
    private void ValidateDomainName(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name), "Invalid name. Name is required!");
        DomainExceptionValidation.When(name.Length < 4, "Invalid name, too short, name must have a minimum 4 characters.");

        Name = name;
    }
}
