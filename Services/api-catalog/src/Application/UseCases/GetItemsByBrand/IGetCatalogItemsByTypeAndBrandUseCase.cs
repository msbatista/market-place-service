using Domain;
using Domain.CatalogItems;

namespace Application.UseCases.GetCatalogItemsByBrand;

/// <summary>
/// IGetCatalogItemsByBrandUseCase.
/// </summary>
public interface IGetCatalogItemsByBrandUseCase
{
    /// <summary>
    /// Returns a list of items by brand id.
    /// </summary>
    /// <param name="brandId">Brand id.</param>
    /// <param name="pageSize">Items per page.</param>
    /// <param name="pageIndex">Current page.</param>
    /// <returns></returns>
    Task<PaginatedItems<CatalogItem>> Execute(Guid brandId, int pageSize = 10, int pageIndex = 0);
}
