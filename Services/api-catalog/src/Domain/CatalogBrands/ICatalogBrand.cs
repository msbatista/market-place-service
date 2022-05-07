using Domain.ValueObject;

namespace Domain.CatalogBrands;

public interface ICatalogBrand
{
    /// <inheritdoc/>
    CatalogBrandId CatalogBrandId { get; }
}
