using Domain.CatalogBrands;
using Domain.CatalogTypes;
using Domain.ValueObject;

namespace Domain.CatalogItems;

/// <summary>
/// Represents a catalog item.
/// </summary>
public class CatalogItem : ICatalogItem
{
    /// <summary>
    /// Catalog item constructor.
    /// </summary>
    /// <param name="catalogItemId">Catalog item identifier.</param>
    /// <param name="name">Catalog item name.</param>
    /// <param name="description">Catalog item description.</param>
    /// <param name="value">Catalog item price.</param>
    /// <param name="currency">Price currency.</param>
    /// <param name="availableStock">Amount of items on stock.</param>
    /// <param name="pictureName">Item picture.</param>
    /// <param name="pictureUri">Picture uri.</param>
    /// <param name="restockThreshold">Available stock at which we should reorder.</param>
    /// <param name="onReorder">Indicates if a item is in reorder.</param>
    /// <param name="maxStockThreshold">Maximum number of units that can be in-stock due to logistical/physical constraints in warehouse.</param>
    /// <param name="catalogTypeId">Item type.</param>
    /// <param name="catalogBrandId">Item brand.</param>
    public CatalogItem(
        CatalogItemId catalogItemId,
        string name,
        string description,
        decimal value,
        string currency,
        int availableStock,
        string pictureName,
        string pictureUri,
        int restockThreshold,
        bool onReorder,
        int maxStockThreshold,
        CatalogTypeId catalogTypeId,
        CatalogBrandId catalogBrandId)
    {
        CatalogItemId = catalogItemId;
        Name = name;
        Description = description;
        Price = new Price(value, new Currency(currency));
        AvailableStock = availableStock;
        PictureName = pictureName;
        PictureUri = pictureUri;
        RestockThreshold = restockThreshold;
        OnReorder = onReorder;
        MaxStockThreshold = maxStockThreshold;
        CatalogTypeId = catalogTypeId;
        CatalogBrandId = catalogBrandId;
        Value = value;
        Currency = currency;
    }

    /// <summary>
    /// Get CatalogItemId.
    /// </summary>
    /// <value>CatalogItemId.</value>
    public CatalogItemId CatalogItemId { get; }

    /// <summary>
    /// Get item name.
    /// </summary>
    /// <value>string.</value>
    public string Name { get; set; }

    /// <summary>
    /// Item description.
    /// </summary>
    /// <value>string.</value>
    public string Description { get; set; }

    /// <summary>
    /// Item price.
    /// </summary>
    /// <value>Price.</value>
    public Price Price { get; set; }

    /// <summary>
    /// Get item price.
    /// </summary>
    /// <value>decimal.</value>
    public decimal Value { get; set; }

    /// <summary>
    /// Get item currency.
    /// </summary>
    /// <value>string.</value>
    public string Currency { get; set; }

    /// <summary>
    /// Get available stock.
    /// </summary>
    /// <value>int.</value>
    public int AvailableStock { get; set; }

    /// <summary>
    /// Get picture name.
    /// </summary>
    /// <value>string.</value>
    public string PictureName { get; set; }

    /// <summary>
    /// Get picture uri.
    /// </summary>
    /// <value>string.</value>
    public string PictureUri { get; set; }

    /// <summary>
    /// Get restock threshold.
    /// </summary>
    /// <value>int.</value>
    public int RestockThreshold { get; set; }

    /// <summary>
    /// Get on reorder.
    /// </summary>
    /// <value>bool.</value>
    public bool OnReorder { get; set; }

    /// <summary>
    /// Get maximum stock threshold.
    /// </summary>
    /// <value>int.</value>
    public int MaxStockThreshold { get; set; }

    /// <inheritdoc />
    public CatalogBrandId CatalogBrandId { get; }

    /// <inheritdoc />
    public CatalogTypeId CatalogTypeId { get; }

    /// <inheritdoc />
    public CatalogBrand? CatalogBrand { get; set; }

    /// <inheritdoc />
    public CatalogType? CatalogType { get; set; }

    /// <inheritdoc/>
    public int AddStock(int quantityToBeAdded)
    {
        if (quantityToBeAdded <= 0)
        {
            throw new ValueOutOfRangeException($"{nameof(quantityToBeAdded)} must be greater than zero.");
        }

        int original = this.AvailableStock;

        if (this.AvailableStock + quantityToBeAdded > this.MaxStockThreshold)
        {
            this.AvailableStock += this.MaxStockThreshold - this.AvailableStock;
        }
        else
        {
            this.AvailableStock += quantityToBeAdded;
        }

        return this.AvailableStock - original;
    }

    /// <inheritdoc/>
    public int RemoveStock(int quantityToBeRemoved)
    {
        if (this.AvailableStock == 0)
        {
            throw new EmptyStockException($"Inventory is empty! Item {this.Name} is sold out.");
        }

        if (quantityToBeRemoved <= 0)
        {
            throw new ValueOutOfRangeException($"{nameof(quantityToBeRemoved)} must be greater than zero.");
        }

        int removedQuantity = Math.Min(quantityToBeRemoved, this.AvailableStock);

        this.AvailableStock -= removedQuantity;

        return removedQuantity;
    }
}
