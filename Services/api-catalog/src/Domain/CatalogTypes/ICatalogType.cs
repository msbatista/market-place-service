using Domain.ValueObject;

namespace Domain.CatalogTypes;

/// <summary>
/// ICatalogType.
/// </summary>
public interface ICatalogType
{
    /// <inheritdoc />
    CatalogTypeId CatalogTypeId { get; }
}
