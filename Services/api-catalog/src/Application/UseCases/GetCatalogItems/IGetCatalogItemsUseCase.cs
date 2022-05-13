using Domain;
using Domain.CatalogItems;

namespace Application.UseCases.GetCatalogItems;

/// <summary>
/// IGetCatalogItemsUseCase.
/// </summary>
public interface IGetCatalogItemsUseCase
{
    /// <summary>
    /// Fetch inventory items.
    /// </summary>
    /// <param name="ids">Optional. A comma separeted list of ids to filter.</param>
    /// <param name="pageSize">Items per page.</param>
    /// <param name="pageIndex">Current page.</param>
    /// <returns>An paginates list of CatalogItem.</returns>
    Task<PaginatedItems<CatalogItem>> Execute(string? ids, int pageSize = 10, int pageIndex = 0);
}
