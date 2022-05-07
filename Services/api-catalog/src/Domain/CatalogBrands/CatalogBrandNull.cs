using Domain.ValueObject;

namespace Domain.CatalogBrands;

/// <summary>
/// Represents a null instance of CatalogBrand.
/// </summary>
public sealed class CatalogBrandNull : ICatalogBrand
{
    /// <summary>
    /// Initializes an instance of CatalogItemNull.
    /// </summary>
    /// <returns>CatalogBrandNull.</returns>
    public static CatalogBrandNull Instance => new();

    /// <summary>
    /// Initializes CatalogBrandId with Guid.Empty.
    /// </summary>
    /// <returns>CatalogBrandId.</returns>

    public CatalogBrandId CatalogBrandId { get; } = new(Guid.Empty);
}
