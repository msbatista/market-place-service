using System.Buffers;
using Domain.CatalogItems;

namespace WebApi.ViewModels;

/// <summary>
/// Catalog item response model.
/// </summary>
public sealed class CatalogItemViewModel
{
    /// <summary>
    /// Initializes an instance of CatalogItemViewModel.
    /// </summary>
    /// <param name="item"></param>
    public CatalogItemViewModel(CatalogItem item)
    {
        this.CatalogItemId = item.CatalogItemId.Id;
        this.Name = item.Name;
        this.Description = item.Description;
        this.Value = item.Value;
        this.Currency = item.Currency;
        this.AvailableStock = item.AvailableStock;
        this.PictureName = item.PictureName;
        this.PictureUri = item.PictureUri;
        this.RestockThreshold = item.RestockThreshold;
        this.OnReorder = item.OnReorder;
        this.MaxStockThreshold = item.MaxStockThreshold;
        this.CatalogTypeId = item.CatalogTypeId.Id;
        this.CatalogBrandId = item.CatalogBrandId.Id;
    }

    /// <summary>
    /// Gets or sets item id.
    /// </summary>
    /// <value>Guid.</value>
    public Guid CatalogItemId { get; set; }
    /// <summary>
    /// Gets or sets item name.
    /// </summary>
    /// <value>string.</value>
    public string Name { get; set; }
    /// <summary>
    /// Gets or sets item description.
    /// </summary>
    /// <value>string.</value>
    public string Description { get; set; }
    /// <summary>
    /// Gets or sets item price.
    /// </summary>
    /// <value>decimal.</value>
    public decimal Value { get; set; }
    /// <summary>
    /// Gets or sets price item currency.
    /// </summary>
    /// <value>string.</value>
    public string Currency { get; set; }
    /// <summary>
    /// Gets or sets item available stock.
    /// </summary>
    /// <value>int.</value>
    public int AvailableStock { get; set; }
    /// <summary>
    /// Gets or sets item pic name.
    /// </summary>
    /// <value>string.</value>
    public string PictureName { get; set; }
    /// <summary>
    /// Gets or sets item pic uri.
    /// </summary>
    /// <value>string.</value>
    public string PictureUri { get; set; }
    /// <summary>
    /// Gets or sets item restock threshold.
    /// </summary>
    /// <value>string.</value>
    public int RestockThreshold { get; set; }
    /// <summary>
    /// Gets or sets item on order prop.
    /// </summary>
    /// <value>int.</value>
    public bool OnReorder { get; set; }
    /// <summary>
    /// Gets or sets maximum stock threshold.
    /// </summary>
    /// <value>int.</value>
    public int MaxStockThreshold { get; set; }
    /// <summary>
    /// Gets or sets item type.
    /// </summary>
    /// <value>Guid.</value>
    public Guid CatalogTypeId { get; set; }
    /// <summary>
    /// Gets or sets item type.
    /// </summary>
    /// <value>Guid.</value>
    public Guid CatalogBrandId { get; set; }
}
