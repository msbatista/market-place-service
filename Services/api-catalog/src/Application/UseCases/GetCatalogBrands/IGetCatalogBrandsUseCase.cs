using Domain.CatalogBrands;

namespace Application.UseCases.GetCatalogBrands;

/// <summary>
/// IGetCatalogBrandsUseCase.
/// </summary>
public interface IGetCatalogBrandsUseCase
{
    /// <summary>
    /// Get brands.
    /// </summary>
    /// <returns>List of brands.</returns>
    Task<IList<CatalogBrand>> Execute();
}
