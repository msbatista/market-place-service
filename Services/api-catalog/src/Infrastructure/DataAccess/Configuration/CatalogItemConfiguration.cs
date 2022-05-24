using Domain.CatalogItems;
using Domain.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configuration;

public sealed class CatalogItemConfiguration : IEntityTypeConfiguration<CatalogItem>
{
    public void Configure(EntityTypeBuilder<CatalogItem> builder)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        builder.ToTable("CatalogItem");

        builder.HasKey(c => c.CatalogItemId);

        builder.Property(c => c.CatalogItemId)
            .HasConversion(
                value => value.Id,
                id => new CatalogItemId(id)
            )
            .IsRequired();

        builder.Property(c => c.CatalogBrandId)
            .HasConversion(
                value => value.Id,
                id => new CatalogBrandId(id)
            )
            .IsRequired();

        builder.Property(c => c.CatalogTypeId)
            .HasConversion(
                value => value.Id,
                id => new CatalogTypeId(id)
            )
            .IsRequired();
        
        builder.Property(c => c.Name)
            .HasMaxLength(DbLimits.TINY_TEXT)
            .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction)
            .IsRequired();

        builder.Property(c => c.Description)
            .HasMaxLength(DbLimits.MEDIUM_TEXT)
            .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction)
            .IsRequired();

        builder.Property(c => c.Value)
            .HasColumnType("decimal(18,4)")
            .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction)
            .IsRequired();

        builder.Ignore(c => c.Price);
        
        builder.Property(c => c.Currency)
            .HasMaxLength(DbLimits.TINIER_TEXT)
            .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction)
            .IsRequired();
        
        builder.Property(c => c.AvailableStock)
            .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction)
            .IsRequired();
        
        builder.Property(c => c.PictureName)
            .HasMaxLength(DbLimits.TINY_TEXT)
            .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction)
            .IsRequired();
        
        builder.Property(c => c.PictureUri)
            .HasMaxLength(DbLimits.TINY_TEXT)
            .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction)
            .IsRequired();

        builder.Property(c => c.RestockThreshold)
            .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction)
            .IsRequired();
        
        builder.Property(c => c.OnReorder)
            .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction)
            .IsRequired();

        builder.Property(c => c.MaxStockThreshold)
            .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction)
            .IsRequired();

        builder.HasOne(c => c.CatalogBrand);
        builder.HasOne(c => c.CatalogType);
    }
}
