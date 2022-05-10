using System.Net.Mime;
using Application.UseCases.DeleteCatalogItem;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels.ValidationModels;

namespace WebApi.Controllers.V1.UseCases.DeleteCatalogItem;

/// <summary>
/// Catalog controller.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class CatalogController : ControllerBase
{
    private readonly IDeleteItemUseCase _useCase;

    /// <summary>
    /// Initializes an instance of CatalogController.
    /// </summary>
    /// <param name="useCase"></param>
    public CatalogController(IDeleteItemUseCase useCase) => _useCase = useCase;

    /// <summary>
    /// Delete an item by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>IActionResult.</returns>
    [HttpDelete("items/id/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetailsModel))]
    public async Task<IActionResult> Delete([FromRoute] Guid id) 
    {
        await _useCase.Execute(id);

        return NoContent();
    }
}
