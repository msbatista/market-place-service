using Domain.CatalogTypes;
using Domain.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configuration;

public sealed class CatalogTypeConfiguration : IEntityTypeConfiguration<CatalogType>
{
    public void Configure(EntityTypeBuilder<CatalogType> builder)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        builder.ToTable("CatalogType");

        builder.HasKey(c => c.CatalogTypeId);

        builder.Property(c => c.CatalogTypeId)
            .HasConversion(
                value => value.Id,
                id => new CatalogTypeId(id)
            )
            .IsRequired();

        builder.Property(c => c.Type)
            .HasMaxLength(DbLimits.TINY_TEXT)
            .UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction)
            .IsRequired();
    }
}
