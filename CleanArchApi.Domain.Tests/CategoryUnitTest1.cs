using System;
using CleanArchApi.Domain.Entities;
using CleanArchApi.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace CleanArchApi.Domain.Tests;

public class CategoryUnitTest1
{

    [Fact(DisplayName = "Insert category with valid state")]
    public void InsertCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "Tools");
        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Insert category with negative id value")]
    public void InsertCategory_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Category(-2, "Cars");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid Id. Id must be greater than 0.");
    }

    [Fact(DisplayName = "Insert category with short name value")]
    public void InsertCategory_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Category(1, "er");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name, too short, name must have a minimum 4 characters.");
    }

    [Fact(DisplayName = "Insert category with empty or spaces value")]
    public void InsertCategory_MissinNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Category(1, "");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required!");
    }

    [Fact(DisplayName = "Insert category with null value")]
    public void InsertCategory_WithNullNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new Category(1, null);
        action.Should()
            .Throw<DomainExceptionValidation>();
    }
}