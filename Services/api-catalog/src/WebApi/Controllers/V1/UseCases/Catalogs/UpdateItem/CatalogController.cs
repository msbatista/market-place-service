using System.Net.Mime;
using Application.UseCases.UpdateItems;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
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
    /// <param name="catalogItemModel"></param>
    /// <returns>IActionResult.</returns>
    [HttpPut("items")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetailsModel))]
    public async Task<IActionResult> CreateItemAsync([FromBody] CatalogItemModel catalogItemModel)
    {
        var updateCatalogItemModel = new UpdateCatalogItemModel(
            catalogItemModel.Id,
            catalogItemModel.Name,
            catalogItemModel.Description,
            catalogItemModel.Value,
            catalogItemModel.Currency,
            catalogItemModel.AvailableStock,
            catalogItemModel.PictureName,
            catalogItemModel.PictureUri,
            catalogItemModel.RestockThreshold,
            catalogItemModel.OnReorder,
            catalogItemModel.MaxStockThreshold,
            catalogItemModel.CatalogTypeId,
            catalogItemModel.CatalogBrandId
        );

        await _useCase.Execute(updateCatalogItemModel);

        return NoContent();
    }
}
