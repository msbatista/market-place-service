using System.Net.Mime;
using Application.UseCases.CreateCatalogItems;
using Domain.CatalogItems;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
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
    [HttpPost("items")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CatalogItem))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetailsModel))]
    public async Task<IActionResult> CreateItemAsync([FromBody] CatalogItemModel catalogItemModel)
    {
        var createCatalogItemRequest = new CreateCatalogItemModel(
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
        
        var item = await _useCase.Execute(createCatalogItemRequest);

        return CreatedAtAction(
            nameof(GetCatalogItemById.CatalogController.Get), 
            new { id = item.CatalogItemId.Id }, 
            item
        );
    }
}
