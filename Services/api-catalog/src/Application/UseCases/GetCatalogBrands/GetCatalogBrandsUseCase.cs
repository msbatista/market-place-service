using Domain;
using Domain.CatalogBrands;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.GetCatalogBrands;

/// <summary>
/// Catalog controller.
/// </summary>
public class GetCatalogBrandsUseCase : IGetCatalogBrandsUseCase
{
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly ILogger<GetCatalogBrandsUseCase> _logger;

    /// <summary>
    /// Initializes an instance of GetCatalogBrandsUseCase.
    /// </summary>
    /// <param name="catalogItemRepository"></param>
    /// <param name="logger"></param>
    public GetCatalogBrandsUseCase(
        ICatalogItemRepository catalogItemRepository,
        ILogger<GetCatalogBrandsUseCase> logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _logger = logger;
    }

    public async Task<IList<CatalogBrand>> Execute()
    {
        _logger.LogInformation("Get brands.");

        return await _catalogItemRepository.GetCatalogBrands();
    }
}
