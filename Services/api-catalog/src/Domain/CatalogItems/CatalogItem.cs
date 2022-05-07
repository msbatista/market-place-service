using Domain.ValueObject;

namespace Domain.CatalogItems;

public class CatalogItem : ICatalogItem
{

    /// <summary>
    /// Catalog item constructor.
    /// </summary>
    /// <param name="catalogItemId">Catalog item identifier.</param>
    /// <param name="name">Catalog item name.</param>
    /// <param name="description">Catalog item description.</param>
    /// <param name="price">Catalog item price.</param>
    /// <param name="availableStock">Amount of items on stock.</param>
    /// <param name="pictureName">Item picture.</param>
    /// <param name="pictureUri">Picture uri.</param>
    /// <param name="restockThreshold">Available stock at which we should reorder.</param>
    /// <param name="onReorder">Indicates if a item is in reorder.</param>
    /// <param name="maxStockThreshold">Maximum number of units that can be in-stock due to logistical/physical constraints in warehouse.</param>
    public CatalogItem(
        CatalogItemId catalogItemId,
        string name,
        string description,
        decimal price,
        int availableStock,
        string pictureName,
        string pictureUri,
        int restockThreshold,
        bool onReorder,
        int maxStockThreshold)
    {
        CatalogItemId = catalogItemId;
        Name = name;
        Description = description;
        Price = price;
        AvailableStock = availableStock;
        PictureName = pictureName;
        PictureUri = pictureUri;
        RestockThreshold = restockThreshold;
        OnReorder = onReorder;
        MaxStockThreshold = maxStockThreshold;
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
    public string Name { get; private set; }

    /// <summary>
    /// Item description.
    /// </summary>
    /// <value>string.</value>
    public string Description { get; private set; }

    /// <summary>
    /// Item price.
    /// </summary>
    /// <value>decimal.</value>
    public decimal Price { get; private set; }

    /// <summary>
    /// Get available stock.
    /// </summary>
    /// <value>int.</value>
    public int AvailableStock { get; private set; }

    /// <summary>
    /// Get picture name.
    /// </summary>
    /// <value>string.</value>
    public string PictureName { get; private set; }

    /// <summary>
    /// Get picture uri.
    /// </summary>
    /// <value>string.</value>
    public string PictureUri { get; private set; }

    /// <summary>
    /// Get restock threshold.
    /// </summary>
    /// <value>int.</value>
    public int RestockThreshold { get; private set; }

    /// <summary>
    /// Get on reorder.
    /// </summary>
    /// <value>bool.</value>
    public bool OnReorder { get; private set; }

    /// <summary>
    /// Get maximum stock threshold.
    /// </summary>
    /// <value>int.</value>
    public int MaxStockThreshold { get; private set; }

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
