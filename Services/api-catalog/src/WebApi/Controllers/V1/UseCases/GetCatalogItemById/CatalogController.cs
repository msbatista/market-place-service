using System.Net.Mime;
using Application.UseCases.GetCatalogItemById;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;
using WebApi.ViewModels.ValidationModels;

namespace WebApi.Controllers.V1.UseCases.GetCatalogItemById;

/// <summary>
/// Catalog controller.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces(MediaTypeNames.Application.Json )]
public sealed class CatalogController : ControllerBase
{
    private readonly IGetCatalogItemByIdUseCase _useCase;
    private readonly ILogger<CatalogController> _logger;

    /// <summary>
    /// Initializes an instance of CatalogController.
    /// </summary>
    /// <param name="useCase"></param>
    /// <param name="logger"></param>
    public CatalogController(
        IGetCatalogItemByIdUseCase useCase, 
        ILogger<CatalogController> logger)
    {
        _useCase = useCase;
        _logger = logger;
    }

    /// <summary>
    /// Get an item by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>IActionResult.</returns>
    [HttpGet("id/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CatalogItemViewModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetailsModel))]
    public async Task<IActionResult> GetItemById([FromRoute] Guid id) 
    {
        _logger.LogInformation("Getting item by id.");

        var item = await _useCase.Execute(id);

        return Ok(new CatalogItemViewModel(item));
    }
}
