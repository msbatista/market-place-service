using Domain;
using Domain.CatalogItems;

namespace Application.UseCases.GetCatalogItemsWithName;

/// <summary>
/// IGetCatalogItemsWithNameUseCase.
/// </summary>
public interface IGetCatalogItemsWithNameUseCase
{
    /// <summary>
    /// Get items that start with 'name'.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="pageSize"></param>
    /// <param name="pageIndex"></param>
    /// <returns></returns>
    Task<PaginatedItems<CatalogItem>> Execute(string name, int pageSize = 10, int pageIndex = 0);
}
