using Domain.CatalogBrands;
using Domain.CatalogTypes;

namespace Application.UseCases.GetCatalogTypes;

/// <summary>
/// IGetCatalogTypesUseCase.
/// </summary>
public interface IGetCatalogTypesUseCase
{
    /// <summary>
    /// Get types.
    /// </summary>
    /// <returns>List of types.</returns>
    Task<IList<CatalogType>> Execute();
}
