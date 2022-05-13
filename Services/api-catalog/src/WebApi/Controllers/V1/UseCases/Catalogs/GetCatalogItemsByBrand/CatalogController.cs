using Domain;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Domain.CatalogItems;
using Application.UseCases.GetCatalogItemsByBrand;

namespace WebApi.Controllers.V1.UseCases.GetCatalogItemsByBrand;

/// <summary>
/// Catalog controller.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class CatalogController : ControllerBase
{
    private readonly IGetCatalogItemsByBrandUseCase _useCase;

    /// <summary>
    /// Initializes an instance of CatalogController.
    /// </summary>
    /// <param name="useCase"></param>
    public CatalogController(IGetCatalogItemsByBrandUseCase useCase) => _useCase = useCase;


    /// <summary>
    /// Get items brand.
    /// </summary>
    /// <param name="brandId"></param>
    /// <param name="pageSize"></param>
    /// <param name="pageIndex"></param>
    /// <returns>IActionResult.</returns>
    [HttpGet("items/brand/{brandId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedItems<CatalogItem>))]
    public async Task<IActionResult> Get(
        [FromRoute] Guid brandId,
        [FromQuery] int pageSize = 10,
        [FromQuery] int pageIndex = 0)
    {

        var items = await _useCase.Execute(brandId, pageSize, pageIndex);

        return Ok(items);
    }
}
