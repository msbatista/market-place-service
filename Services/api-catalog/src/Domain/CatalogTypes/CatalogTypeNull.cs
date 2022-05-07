using Domain.ValueObject;

namespace Domain.CatalogTypes;

/// <summary>
/// Represents a null instance of CatalogBrand.
/// </summary>
public class CatalogTypeNull : ICatalogType
{

    /// <summary>
    /// Initializes an instance of CatalogItemNull.
    /// </summary>
    /// <returns>CatalogTypeNull.</returns>
    public static CatalogTypeNull Instance => new();

    /// <summary>
    /// Initializes CatalogTypeId with Guid.Empty.
    /// </summary>
    /// <returns>CatalogTypeId.</returns>

    public CatalogTypeId CatalogTypeId { get; } = new(Guid.Empty);
}
