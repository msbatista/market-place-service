using Domain;
using System.Net.Mime;
using Application.UseCases.GetCatalogItemsByTypeAndBrand;
using Microsoft.AspNetCore.Mvc;
using Domain.CatalogItems;

namespace WebApi.Controllers.V1.UseCases.GetCatalogItemsByTypeAndBrand;

/// <summary>
/// Catalog controller.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class CatalogController : ControllerBase
{
    private readonly IGetCatalogItemsByTypeAndBrandUseCase _useCase;

    /// <summary>
    /// Initializes an instance of CatalogController.
    /// </summary>
    /// <param name="useCase"></param>
    public CatalogController(IGetCatalogItemsByTypeAndBrandUseCase useCase) => _useCase = useCase;


    /// <summary>
    /// Get items by type and brand.
    /// </summary>
    /// <param name="typeId"></param>
    /// <param name="brandId"></param>
    /// <param name="pageSize"></param>
    /// <param name="pageIndex"></param>
    /// <returns>IActionResult.</returns>
    [HttpGet("items/type/{typeId}/brand/{brandId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedItems<CatalogItem>))]
    public async Task<IActionResult> Get(
        [FromRoute] Guid typeId,
        [FromRoute] Guid brandId,
        [FromQuery] int pageSize = 10,
        [FromQuery] int pageIndex = 0)
    {

        var items = await _useCase.Execute(typeId, brandId, pageSize, pageIndex);

        return Ok(items);
    }
}
