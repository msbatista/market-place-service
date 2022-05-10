using Domain;
using Domain.CatalogItems;
using Domain.ValueObject;

namespace Application.UseCases.GetCatalogItemsByTypeAndBrand;

/// <summary>
/// IGetCatalogItemsByTypeAndBrandUseCase.
/// </summary>
public interface IGetCatalogItemsByTypeAndBrandUseCase
{
    /// <summary>
    /// Returns a list of items by type id and brand id. If neither of parameters is passed, it query over all database. 
    /// </summary>
    /// <param name="typeId">Type id.</param>
    /// <param name="brandId">Brand id.</param>
    /// <param name="pageSize">Items per page.</param>
    /// <param name="pageIndex">Current page.</param>
    /// <returns></returns>
     Task<PaginatedItems<CatalogItem>> Execute(Guid typeId, Guid brandId, int pageSize = 10, int pageIndex = 0);
}
