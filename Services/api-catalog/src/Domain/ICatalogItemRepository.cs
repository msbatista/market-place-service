using Domain.CatalogBrands;
using Domain.CatalogItems;
using Domain.CatalogTypes;
using Domain.ValueObject;

namespace Domain;

/// <summary>
/// Catalog repository definitions.
/// </summary>
public interface ICatalogItemRepository
{
    /// <summary>
    /// Get item by id.
    /// </summary>
    /// <param name="id">Catalog item id.</param>
    /// <returns>ICatalogItem.</returns>
    Task<ICatalogItem> GetCatalogItemById(CatalogItemId id);

    /// <summary>
    /// Get items either paginated or by a list of ids.
    /// </summary>
    /// <param name="pageSize">Items per page.</param>
    /// <param name="pageIndex">Current page.</param>
    /// <param name="ids">Optional. List of ids.</param>
    /// <returns>List of CatalogItem.</returns>
    Task<IList<CatalogItem>> GetCatalogItems(int pageSize = 10, int pageIndex = 0, CatalogItemId[]? ids = null);

    /// <summary>
    /// Get a list of items that starts with the given name.
    /// </summary>
    /// <param name="name">Name to search.</param>
    /// <param name="pageSize">Items per page.</param>
    /// <param name="pageIndex">Current page.</param>
    /// <returns>List of CatalogItem.</returns>
    Task<IList<CatalogItem>> GetCatalogItemsWithName(string name, int pageSize = 10, int pageIndex = 0);

    /// <summary>
    /// Returns a list of items by brand.
    /// </summary>
    /// <param name="brandId">Brand id.</param>
    /// <param name="pageSize">Items per page.</param>
    /// <param name="pageIndex">Current page.</param>
    /// <returns>List of CatalogItem.</returns>
    Task<IList<CatalogItem>> GetCatalogItemsByBrand(CatalogBrandId brandId, int pageSize = 10, int pageIndex = 0);

    /// <summary>
    /// Returns a list of items by category.
    /// </summary>
    /// <param name="typeId">Type id.</param>
    /// <param name="pageSize">Items per page.</param>
    /// <param name="pageIndex">Current page.</param>
    /// <returns></returns>
    Task<IList<CatalogItem>> GetCatalogItemsByType(CatalogTypeId typeId, int pageSize = 10, int pageIndex = 0);

    /// <summary>
    /// Returns a list of items by type id and brand id.
    /// </summary>
    /// <param name="typeId">Type id.</param>
    /// <param name="brandId">Brand id.</param>
    /// <param name="pageSize">Items per page.</param>
    /// <param name="pageIndex">Current page.</param>
    /// <returns></returns>
    Task<IList<CatalogItem>> GetCatalogItemsByTypeAndBrand(CatalogTypeId typeId, CatalogBrandId brandId, int pageSize = 10, int pageIndex = 0);

    /// <summary>
    /// Creates an item.
    /// </summary>
    /// <param name="catalogItem">Item to be added.</param>
    /// <returns>Task.</returns>
    Task CreateCatalogItem(CatalogItem catalogItem);

    /// <summary>
    /// Updates an item.
    /// </summary>
    /// <param name="old">Old item.</param>
    /// <param name="newItem">New item.</param>
    /// <returns>Task.</returns>
    Task UpdateCatalogItem(CatalogItem old, CatalogItem newItem);

    /// <summary>
    /// Deletes an item from inventory.
    /// </summary>
    /// <param name="itemId">Item id.</param>
    /// <returns>Task.</returns>
    Task DeleteCatalogItem(CatalogItemId itemId);

    /// <summary>
    /// Get the available catalog brands.
    /// </summary>
    /// <returns>List of CatalogBrand.</returns>
    Task<IList<CatalogBrand>> GetCatalogBrands();

    /// <summary>
    /// Get the available catalog types.
    /// </summary>
    /// <returns>List of CatalogType.</returns>
    Task<IList<CatalogType>> GetCatalogTypes();
}
