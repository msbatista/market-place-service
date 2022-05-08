using Domain.CatalogBrands;
using Domain.CatalogItems;
using Domain.CatalogTypes;
using Domain.ValueObject;

namespace Domain;

/// <summary>
/// Entity factory.
/// </summary>
public interface IEntityFactory
{
    /// <summary>
    /// Initializes an object of type CatalogType.
    /// </summary>
    /// <param name="type">Catalog type.</param>
    /// <returns>CatalogType.</returns>
    CatalogType NewCatalogType(string type);

    /// <summary>
    /// Initializes an object of type CatalogBrand.
    /// </summary>
    /// <param name="brand">Catalog brand.</param>
    /// <returns>CatalogBrand.</returns>
    CatalogBrand NewCatalogBrand(string brand);

    /// <summary>
    /// Initializes an object of type CatalogItem.
    /// </summary>
    /// <param name="name">Catalog item name.</param>
    /// <param name="description">Catalog item description.</param>
    /// <param name="price">Catalog item price.</param>
    /// <param name="currency">Price currency.</param>
    /// <param name="availableStock">Amount of items on stock.</param>
    /// <param name="pictureName">Item picture.</param>
    /// <param name="pictureUri">Picture uri.</param>
    /// <param name="restockThreshold">Available stock at which we should reorder.</param>
    /// <param name="onReorder">Indicates if a item is in reorder.</param>
    /// <param name="maxStockThreshold">Maximum number of units that can be in-stock due to logistical/physical constraints in warehouse.</param>
    /// <param name="catalogTypeId">Item type.</param>
    /// <param name="catalogBrandId">Item brand.</param>
    /// <returns>CatalogItem.</returns>
    CatalogItem NewCatalogItem(
        string name,
        string description,
        decimal price,
        string currency,
        int availableStock,
        string pictureName,
        string pictureUri,
        int restockThreshold,
        bool onReorder,
        int maxStockThreshold,
        Guid catalogTypeId,
        Guid catalogBrandId);
}
