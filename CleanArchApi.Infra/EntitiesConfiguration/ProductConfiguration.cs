using CleanArchApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchApi.Infra.EntitiesConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).HasMaxLength(80).IsRequired();
        builder.Property(e => e.Description).HasMaxLength(255).IsRequired();
        builder.Property(e => e.Image).HasMaxLength(255);

        builder.Property(e => e.Price).HasPrecision(6, 2);

        builder
            .HasOne(e => e.Category)
            .WithMany(e => e.Products)
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
