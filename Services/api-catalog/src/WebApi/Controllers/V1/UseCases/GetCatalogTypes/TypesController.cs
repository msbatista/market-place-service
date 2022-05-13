using Domain;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Application.UseCases.GetCatalogTypes;
using Domain.CatalogTypes;

namespace WebApi.Controllers.V1.UseCases.GetCatalogTypes;

/// <summary>
/// Types controller.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class TypesController : ControllerBase
{
    private readonly IGetCatalogTypesUseCase _useCase;

    /// <summary>
    /// Initializes an instance of CatalogController.
    /// </summary>
    /// <param name="useCase"></param>
    public TypesController(IGetCatalogTypesUseCase useCase) => _useCase = useCase;


    /// <summary>
    /// Get types.
    /// </summary>
    /// <returns>IActionResult.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedItems<CatalogType>))]
    public async Task<IActionResult> Get()
    {
        var types = await _useCase.Execute();

        return Ok(types);
    }
}
