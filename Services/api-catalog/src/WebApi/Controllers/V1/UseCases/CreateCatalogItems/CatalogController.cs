using System.Net.Mime;
using Application.UseCases.CreateCatalogItems;
using Application.UseCases.CreateCatalogItems.Model;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;
using WebApi.ViewModels.ValidationModels;

namespace WebApi.Controllers.V1.UseCases.CreateCatalogItems;

/// <summary>
/// Catalog controller.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces(MediaTypeNames.Application.Json )]
public sealed class CatalogController : ControllerBase
{
    private readonly ICreateCatalogItemUseCase _useCase;
    private readonly ILogger<CatalogController> _logger;

    /// <summary>
    /// Initializes an instance of CatalogController.
    /// </summary>
    /// <param name="useCase"></param>
    /// <param name="logger"></param>
    public CatalogController(ICreateCatalogItemUseCase useCase, ILogger<CatalogController> logger)
    {
        _useCase = useCase;
        _logger = logger;
    }

    /// <summary>
    /// Inserts a item into inventory.
    /// </summary>
    /// <param name="catalogItemModel"></param>
    /// <returns>IActionResult.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CatalogItemViewModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetailsModel))]
    public async Task<IActionResult> CreateItemAsync([FromBody] CatalogItemModel catalogItemModel)
    {
        var item = await _useCase.Execute(catalogItemModel);

        return CreatedAtAction("GetItemById", new { id = item.CatalogItemId.Id }, new CatalogItemViewModel(item));
    }
}
