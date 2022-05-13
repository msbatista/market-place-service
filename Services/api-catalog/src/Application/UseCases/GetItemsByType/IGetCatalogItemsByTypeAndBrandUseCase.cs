using Domain;
using Domain.CatalogItems;

namespace Application.UseCases.GetCatalogItemsByType;

/// <summary>
/// IGetCatalogItemsByTypeUseCase.
/// </summary>
public interface IGetCatalogItemsByTypeUseCase
{
    /// <summary>
    /// Returns a list of items by type id.
    /// </summary>
    /// <param name="typeId">Type id.</param>
    /// <param name="pageSize">Items per page.</param>
    /// <param name="pageIndex">Current page.</param>
    /// <returns></returns>
     Task<PaginatedItems<CatalogItem>> Execute(Guid typeId, int pageSize = 10, int pageIndex = 0);
}
