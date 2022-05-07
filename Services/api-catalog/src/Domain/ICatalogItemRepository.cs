using Domain.CatalogItems;
using Domain.ValueObject;

namespace Domain;

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
}
