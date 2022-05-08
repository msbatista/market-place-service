using Domain.CatalogBrands;
using Domain.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configuration;

public sealed class CatalogBrandConfiguration : IEntityTypeConfiguration<CatalogBrand>
{
    public void Configure(EntityTypeBuilder<CatalogBrand> builder)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        builder.ToTable("CatalogBrand");

        builder.HasKey(c => c.CatalogBrandId);

        builder.Property(c => c.CatalogBrandId)
            .HasConversion(
                value => value.Id,
                id => new CatalogBrandId(id)
            )
            .IsRequired();
        
        builder.Property(c => c.Brand)
            .HasMaxLength(DbLimits.TINY_TEXT)
            .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction)
            .IsRequired();
    }
}
