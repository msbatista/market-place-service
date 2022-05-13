using System.Net.Mime;
using Application.UseCases.CreateCatalogItems;
using Application.UseCases.Model;
using Application.UseCases.UpdateItem;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels.ValidationModels;

namespace WebApi.Controllers.V1.UseCases.UpdateItem;

/// <summary>
/// Catalog controller.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces(MediaTypeNames.Application.Json )]
public sealed class CatalogController : ControllerBase
{
    private readonly IUpdateItemUseCase _useCase;
    private readonly ILogger<CatalogController> _logger;

    /// <summary>
    /// Initializes an instance of CatalogController.
    /// </summary>
    /// <param name="useCase"></param>
    /// <param name="logger"></param>
    public CatalogController(IUpdateItemUseCase useCase, ILogger<CatalogController> logger)
    {
        _useCase = useCase;
        _logger = logger;
    }

    /// <summary>
    /// Updates a item into inventory.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="catalogItemModel"></param>
    /// <returns>IActionResult.</returns>
    [HttpPut("items/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetailsModel))]
    public async Task<IActionResult> CreateItemAsync([FromRoute] Guid id, [FromBody] CatalogItemModel catalogItemModel)
    {
        await _useCase.Execute(id, catalogItemModel);

        return NoContent();
    }
}
