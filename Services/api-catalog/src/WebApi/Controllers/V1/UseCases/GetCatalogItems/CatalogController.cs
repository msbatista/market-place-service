using Domain;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Domain.CatalogItems;
using Application.UseCases.GetCatalogItems;

namespace WebApi.Controllers.V1.UseCases.GetCatalogItems;

/// <summary>
/// Catalog controller.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class CatalogController : ControllerBase
{
    private readonly IGetCatalogItemsUseCase _useCase;

    /// <summary>
    /// Initializes an instance of CatalogController.
    /// </summary>
    /// <param name="useCase"></param>
    public CatalogController(IGetCatalogItemsUseCase useCase) => _useCase = useCase;


    /// <summary>
    /// Get items by type and brand.
    /// </summary>
    /// <param name="ids"></param>
    /// <param name="pageSize"></param>
    /// <param name="pageIndex"></param>
    /// <returns>IActionResult.</returns>
    [HttpGet("items")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedItems<CatalogItem>))]
    public async Task<IActionResult> Get(
        [FromRoute] string ids,
        [FromQuery] int pageSize = 10,
        [FromQuery] int pageIndex = 0)
    {

        var items = await _useCase.Execute(ids, pageSize, pageIndex);

        return Ok(items);
    }
}
