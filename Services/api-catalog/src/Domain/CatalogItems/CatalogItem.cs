using System.Text.Json.Serialization;
using BuildingBlocks.Modules.Extensions;
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
        byte[]? picture,
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
        Picture = picture;
    }

    /// <summary>
    /// Gets CatalogItemId.
    /// </summary>
    /// <value>CatalogItemId.</value>
    public CatalogItemId CatalogItemId { get; set; }

    /// <summary>
    /// Gets item name.
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
    /// Gets item price.
    /// </summary>
    /// <value>decimal.</value>
    public decimal Value { get; set; }

    /// <summary>
    /// Gets item currency.
    /// </summary>
    /// <value>string.</value>
    public string Currency { get; set; }

    /// <summary>
    /// Gets available stock.
    /// </summary>
    /// <value>int.</value>
    public int AvailableStock { get; set; }

    /// <summary>
    /// Gets picture name.
    /// </summary>
    /// <value>string.</value>
    public string PictureName { get; set; }

    /// <summary>
    /// Gets picture uri.
    /// </summary>
    /// <value>string.</value>
    public string PictureUri { get; set; }

    /// <summary>
    /// Gets restock threshold.
    /// </summary>
    /// <value>int.</value>
    public int RestockThreshold { get; set; }

    /// <summary>
    /// Gets whether or not item is on reorder.
    /// </summary>
    /// <value>bool.</value>
    public bool OnReorder { get; set; }

    /// <summary>
    /// Gets maximum stock threshold.
    /// </summary>
    /// <value>int.</value>
    public int MaxStockThreshold { get; set; }

    /// <inheritdoc />
    public CatalogBrandId CatalogBrandId { get; set; }

    /// <inheritdoc />
    public CatalogTypeId CatalogTypeId { get; set; }

    /// <inheritdoc />
    public CatalogBrand? CatalogBrand { get; set; }

    /// <inheritdoc />
    public CatalogType? CatalogType { get; set; }

    public string PictureBase64 => Picture?.AsString() ?? "";

    /// <summary>
    /// Picture.
    /// </summary>
    /// <value>byte[]</value>
    [JsonIgnore]
    public byte[]? Picture { get; set; }

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
