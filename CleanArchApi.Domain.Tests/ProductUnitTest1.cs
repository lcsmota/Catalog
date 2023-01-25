using System;
using CleanArchApi.Domain.Entities;
using CleanArchApi.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace CleanArchApi.Domain.Tests;

public class ProductUnitTest1
{
    [Fact]
    public void InsertProduct_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Product(
            1,
            "Mouse",
            "Mouse Gamer ZXtreme Ultra",
            567.99m,
            12,
            "https://image/mousegamer.jpg");

        action.Should()
            .NotThrow<DomainExceptionValidation>();
    }
    [Fact]
    public void InsertProduct_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Product(
            -12,
            "Mouse",
            "Mouse Gamer ZXtreme Ultra",
            567.99m,
            12,
            "https://image/mousegamer.jpg");

        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid id. Id must be greater than 0.");
    }
    [Fact]
    public void InsertProduct_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Product(
            2,
            "Moe",
            "Mouse Gamer ZXtreme Ultra",
            567.99m,
            12,
            "https://image/mousegamer.jpg");

        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name, too short, name must have a minimum 4 characters.");
    }
    [Fact]
    public void InsertProduct_LongImageName_DomainExceptionLongImageName()
    {
        Action action = () => new Product(
            22,
            "Mouse",
            "Mouse Gamer ZXtreme Ultra",
            1567.99m,
            12,
            "https://image/mousegamer.jpg/8d2789a1-20fa-4de7-8419-30c203502a6ff8f76a0b-e5cf-445e-bbe5-93167a5123ad73ef68d2789a1-20fa-4de7-8419-30c203502a6ff8f76a0b-e5cf-445e-bbe5-93167a5123ad73ef6a8b-9a33-4292-bdc7-5073c65cda6d3f26f125-830f-4fda-aea2-4eaee680c2e98c6cb673-8e51-4782-848f-a25fac17041d4e88f543-86da-49dd-8925-9300530f7b41a8b-9a33-4292-bdc7-5073c65cda6d3f26f125-830f-4fda-aea2-4eaee680c2e98c6cb673-8e51-4782-848f-a25fac17041d4e88f543-86da-49dd-8925-9300530f7b41");

        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid image name, too long, image name must have a maximum 255 characters.");
    }

    [Fact]
    public void InsertProduct_WithNullImageName_NoDomainException()
    {
        Action action = () => new Product(
            62,
            "Mouse",
            "Mouse Gamer ZXtreme Ultra",
            567.99m,
            12,
            null);

        action.Should()
            .NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    public void InsertProduct_WithNullImageName_NoNullReferenceException()
    {
        Action action = () => new Product(
            162,
            "Mouse",
            "Mouse Gamer ZXtreme Ultra",
            567.99m,
            12,
            null);

        action.Should()
            .NotThrow<NullReferenceException>();

    }

    [Fact]
    public void InsertProduct_InvalidPriceValue_DomainExceptionNegativeValue()
    {
        Action action = () => new Product(
            162,
            "Mouse",
            "Mouse Gamer ZXtreme Ultra",
            -567.99m,
            12,
            "https://image/mousegamer.jpg");

        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid price. Price must be greater than 0.");
    }

    [Theory]
    [InlineData(-212)]
    public void InsertProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
    {
        Action action = () => new Product(
            162,
            "Mouse",
            "Mouse Gamer ZXtreme Ultra",
            567.99m,
            value,
            "https://image/mousegamer.jpg");

        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid stock. Stock must be greater than 0.");
    }
}
