using Domain.ValueObject;

namespace Domain.CatalogItems;

/// <summary>
/// Represents a null instance of CatalogItem.
/// </summary>
public sealed class CatalogItemNull : ICatalogItem
{
    /// <summary>
    /// Initializes an instance of CatalogItemNull.
    /// </summary>
    /// <returns>CatalogItemNull.</returns>
    public static CatalogItemNull Instance => new();

    /// <summary>
    /// Initializes CatalogItemId with Guid.Empty.
    /// </summary>
    /// <returns>CatalogItemId.</returns>
    public CatalogItemId CatalogItemId { get; } = new CatalogItemId(Guid.Empty);

    /// <inheritdoc>
    public int AddStock(int quantityToBeAdded) => int.MinValue;

    /// <inheritdoc />
    public int RemoveStock(int quantityToBeRemoved) => int.MinValue;
}
