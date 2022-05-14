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
    /// <param name="ids">Optional. List of ids.</param>
    /// <param name="pageSize">Items per page.</param>
    /// <param name="pageIndex">Current page.</param>
    /// <returns>Paginated list of CatalogItem.</returns>
    Task<PaginatedItems<CatalogItem>> GetCatalogItems(CatalogItemId[]? ids, int pageSize = 10, int pageIndex = 0);

    /// <summary>
    /// Get a list of items that starts with the given name.
    /// </summary>
    /// <param name="name">Name to search.</param>
    /// <param name="pageSize">Items per page.</param>
    /// <param name="pageIndex">Current page.</param>
    /// <returns>List of CatalogItem.</returns>
    Task<PaginatedItems<CatalogItem>> GetCatalogItemsWithName(string name, int pageSize = 10, int pageIndex = 0);

    /// <summary>
    /// Returns a list of items by type id and brand id.
    /// </summary>
    /// <param name="typeId">Type id.</param>
    /// <param name="brandId">Brand id.</param>
    /// <param name="pageSize">Items per page.</param>
    /// <param name="pageIndex">Current page.</param>
    /// <returns></returns>
    Task<PaginatedItems<CatalogItem>> GetCatalogItemsByTypeAndBrand(CatalogTypeId typeId, CatalogBrandId brandId, int pageSize = 10, int pageIndex = 0);

    /// <summary>
    /// Returns a list of items by type brand id.
    /// </summary>
    /// <param name="brandId">Brand id.</param>
    /// <param name="pageSize">Items per page.</param>
    /// <param name="pageIndex">Current page.</param>
    /// <returns></returns>
    Task<PaginatedItems<CatalogItem>> GetCatalogItemsByBrand(CatalogBrandId brandId, int pageSize = 10, int pageIndex = 0);


    /// <summary>
    /// Returns a list of items by type id.
    /// </summary>
    /// <param name="typeId">Type id.</param>
    /// <param name="pageSize">Items per page.</param>
    /// <param name="pageIndex">Current page.</param>
    /// <returns></returns>
    Task<PaginatedItems<CatalogItem>> GetCatalogItemsByType(CatalogTypeId typeId, int pageSize = 10, int pageIndex = 0);


    /// <summary>
    /// Creates an item.
    /// </summary>
    /// <param name="catalogItem">Item to be added.</param>
    /// <returns>Task.</returns>
    Task CreateCatalogItem(CatalogItem catalogItem);

    /// <summary>
    /// Updates an item.
    /// </summary>
    /// <param name="oldItem">Old item.</param>
    /// <param name="newItem">New item.</param>
    /// <returns>Task.</returns>
    void UpdateCatalogItem(CatalogItem oldItem, CatalogItem newItem);

    /// <summary>
    /// Deletes an item from inventory.
    /// </summary>
    /// <param name="catalogItem">Item to be removed.</param>
    /// <returns>void.</returns>
    void DeleteCatalogItem(CatalogItem catalogItem);

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
