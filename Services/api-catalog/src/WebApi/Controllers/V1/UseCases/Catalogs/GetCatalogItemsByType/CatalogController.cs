using Domain;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Domain.CatalogItems;
using Application.UseCases.GetCatalogItemsByType;

namespace WebApi.Controllers.V1.UseCases.GetCatalogItemsByType;

/// <summary>
/// Catalog controller.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class CatalogController : ControllerBase
{
    private readonly IGetCatalogItemsByTypeUseCase _useCase;

    /// <summary>
    /// Initializes an instance of CatalogController.
    /// </summary>
    /// <param name="useCase"></param>
    public CatalogController(IGetCatalogItemsByTypeUseCase useCase) => _useCase = useCase;


    /// <summary>
    /// Get items by type.
    /// </summary>
    /// <param name="typeId"></param>
    /// <param name="pageSize"></param>
    /// <param name="pageIndex"></param>
    /// <returns>IActionResult.</returns>
    [HttpGet("items/type/{typeId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedItems<CatalogItem>))]
    public async Task<IActionResult> Get(
        [FromRoute] Guid typeId,
        [FromQuery] int pageSize = 10,
        [FromQuery] int pageIndex = 0)
    {

        var items = await _useCase.Execute(typeId, pageSize, pageIndex);

        return Ok(items);
    }
}
