using Domain.ValueObject;

namespace Domain.CatalogTypes;

/// <summary>
/// Represents an item type.
/// </summary>
public class CatalogType : ICatalogType
{
    /// <summary>
    /// Initializes a new instance of the CatalogType class with the specified parameters.
    /// </summary>
    /// <param name="catalogTypeId">Catalog type identifier.</param>
    /// <param name="type">Item type.</param>
    public CatalogType(CatalogTypeId catalogTypeId, string type)
    {
        CatalogTypeId = catalogTypeId;
        Type = type;
    }

    /// <summary>
    /// Get CatalogTypeId.
    /// </summary>
    /// <value>CatalogTypeId.</value>
    public CatalogTypeId CatalogTypeId { get; }

    /// <summary>
    /// Get item type.
    /// </summary>
    /// <value>string.</value>
    public string Type {get; set; }
}
