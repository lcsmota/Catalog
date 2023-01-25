using CleanArchApi.Domain.Validation;

namespace CleanArchApi.Domain.Entities;

public sealed class Product : Entity
{
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string? Image { get; private set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public Product(
        string name,
        string description,
        decimal price,
        int stock,
        string image)
    {
        ValidateDomain(name, description, price, stock, image);
    }
    public Product(
        int id,
        string name,
        string description,
        decimal price,
        int stock,
        string image)
    {
        DomainExceptionValidation.When(id < 0, "Invalid id. Id must be greater than 0.");
        Id = id;

        ValidateDomain(name, description, price, stock, image);
    }

    public void Update(
        string name,
        string description,
        decimal price,
        int stock,
        string image,
        int categoryId
    )
    {
        ValidateDomain(name, description, price, stock, image);
        CategoryId = categoryId;
    }

    private void ValidateDomain(
        string name,
        string description,
        decimal price,
        int stock,
        string image)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name), "Invalid name. Name is required!");
        DomainExceptionValidation.When(name.Length < 4, "Invalid name, too short, name must have a minimum 4 characters.");

        DomainExceptionValidation.When(string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name), "Invalid description. Description is required!");
        DomainExceptionValidation.When(description.Length < 10, "Invalid description, too short, description must have a minimum 10 characters.");

        DomainExceptionValidation.When(price < 0, "Invalid price. Price must be greater than 0.");

        DomainExceptionValidation.When(stock < 0, "Invalid stock. Stock must be greater than 0.");

        DomainExceptionValidation.When(image?.Length > 255, "Invalid image name, too long, image name must have a maximum 255 characters.");

        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
    }
}
