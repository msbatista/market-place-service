using Domain;
using Domain.CatalogTypes;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.GetCatalogTypes;

/// <summary>
/// GetCatalogTypesUseCase.
/// </summary>
public class GetCatalogTypesUseCase : IGetCatalogTypesUseCase
{
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly ILogger<GetCatalogTypesUseCase> _logger;

    /// <summary>
    /// Initializes an instance of GetCatalogTypesUseCase.
    /// </summary>
    /// <param name="catalogItemRepository"></param>
    /// <param name="logger"></param>
    public GetCatalogTypesUseCase(
        ICatalogItemRepository catalogItemRepository,
        ILogger<GetCatalogTypesUseCase> logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _logger = logger;
    }

    public async Task<IList<CatalogType>> Execute()
    {
        _logger.LogInformation("Get types.");

        return await _catalogItemRepository.GetCatalogTypes();
    }
}
