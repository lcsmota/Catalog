using CleanArchApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchApi.Infra.EntitiesConfiguration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).HasMaxLength(80).IsRequired();

        builder.HasData(InsertCategory());
    }

    private IList<Category> InsertCategory()
    {
        return new List<Category>
            {
                new Category(1, "School Supplies"),
                new Category(2, "Electronic"),
                new Category(3, "Accessories")
            };
    }
}
