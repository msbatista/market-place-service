using Domain.ValueObject;

namespace Domain.CatalogBrands;

/// <summary>
/// Represents a brand.
/// </summary>
public sealed class CatalogBrand : ICatalogBrand
{

    /// <summary>
    /// Initializes a new instance of the CatalogBrand class with the specified parameters.
    /// </summary>
    /// <param name="catalogBrandId">Catalog brand identifier.</param>
    /// <param name="brand">Brand name.</param>
    public CatalogBrand(CatalogBrandId catalogBrandId, string brand)
    {
        CatalogBrandId = catalogBrandId;
        Brand = brand;
    }

    /// <summary>
    /// Get catalog brand id.
    /// </summary>
    /// <value>CatalogBrandId.</value>
    public CatalogBrandId CatalogBrandId { get; }

    /// <summary>
    /// Get brand name.
    /// </summary>
    /// <value>string.</value>
    public string Brand { get; private set; }
}
