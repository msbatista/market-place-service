namespace Application.UseCases.UpdateItems;

/// <summary>
/// Catalog controller.
/// </summary>
public class UpdateCatalogItemModel
{
    /// <summary>
    /// Initializes an instance of CreateCatalogItemModel.
    /// </summary>
    /// <param name="id">Item id.</param>
    /// <param name="name">Product name.</param>
    /// <param name="description">Product description.</param>
    /// <param name="value">Product price.</param>
    /// <param name="currency">Product currency.</param>
    /// <param name="availableStock">Amount of items available in stock.</param>
    /// <param name="pictureName">Product picture.</param>
    /// <param name="pictureUri">Product picture uri.</param>
    /// <param name="restockThreshold">Restock threshold.</param>
    /// <param name="onReorder">Is item on reorder.</param>
    /// <param name="maxStockThreshold">Warehouse threshold limit.</param>
    /// <param name="catalogTypeId">Product type.</param>
    /// <param name="catalogBrandId">Product brand.</param>
    public UpdateCatalogItemModel(
        Guid id,
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
        Guid catalogTypeId,
        Guid catalogBrandId)
    {
        Id = Id;
        Name = name;
        Description = description;
        Value = value;
        Currency = currency;
        AvailableStock = availableStock;
        PictureName = pictureName;
        PictureUri = pictureUri;
        RestockThreshold = restockThreshold;
        OnReorder = onReorder;
        MaxStockThreshold = maxStockThreshold;
        CatalogTypeId = catalogTypeId;
        CatalogBrandId = catalogBrandId;
    }

    /// <summary>
    /// Gets or inits object id.
    /// </summary>
    /// <value>Guid.</value>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets or inits Name.
    /// </summary>
    /// <value>string.</value>
    public string Name { get; init; }

    /// <summary>
    /// Gets or inits Description.
    /// </summary>
    /// <value>string.</value>
    public string Description { get; init; }

    /// <summary>
    /// Gets or inits item Value.
    /// </summary>
    /// <value>decimal.</value>
    public decimal Value { get; init; }


    /// <summary>
    /// Gets or inits Currency.
    /// </summary>
    /// <value>string.</value>
    public string Currency { get; init; }


    /// <summary>
    /// Gets or inits AvailableStock.
    /// </summary>
    /// <value>int.</value>
    public int AvailableStock { get; init; }

    /// <summary>
    /// Gets or inits PictureName.
    /// </summary>
    /// <value>string.</value>
    public string PictureName { get; init; }

    /// <summary>
    /// Gets or inits PictureUri.
    /// </summary>
    /// <value>int.</value>
    public string PictureUri { get; init; }

    /// <summary>
    /// Gets or inits RestockThreshold.
    /// </summary>
    /// <value>int.</value>
    public int RestockThreshold { get; init; }

    /// <summary>
    /// Gets or inits OnReorder.
    /// </summary>
    /// <value>bool.</value>
    public bool OnReorder { get; init; }

    /// <summary>
    /// Gets or inits MaxStockThreshold.
    /// </summary>
    /// <value>init.</value>
    public int MaxStockThreshold { get; init; }

    /// <summary>
    /// Gets or inits CatalogTypeId.
    /// </summary>
    /// <value>Guid.</value>
    public Guid CatalogTypeId { get; init; }

    /// <summary>
    /// Gets or inits CatalogBrandId.
    /// </summary>
    /// <value>Guid.</value>
    public Guid CatalogBrandId { get; init; }
}
