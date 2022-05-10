using System.Net.Mime;
using Application.UseCases.GetCatalogItemsWithName;
using Domain;
using Domain.CatalogItems;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1.UseCases.GetCatalogItemsWithName;

/// <summary>
/// Catalog controller.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces(MediaTypeNames.Application.Json )]
public sealed class CatalogController : ControllerBase
{
    private readonly IGetCatalogItemsWithNameUseCase _useCase;

    /// <summary>
    /// Initializes an instance of CatalogController.
    /// </summary>
    /// <param name="useCase"></param>
    public CatalogController(IGetCatalogItemsWithNameUseCase useCase) => _useCase = useCase;

    /// <summary>
    /// Get items by name.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="pageSize"></param>
    /// <param name="pageIndex"></param>
    /// <returns>IActionResult.</returns>
    [HttpGet("items/withname/{name:minlength(3)}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedItems<CatalogItem>))]
    public async Task<IActionResult> Get(
        [FromRoute] string name,
        [FromQuery] int pageSize = 10,
        [FromQuery] int pageIndex = 0)
    {
        var items = await _useCase.Execute(name, pageSize, pageIndex);

        return Ok(items);
    }
}
