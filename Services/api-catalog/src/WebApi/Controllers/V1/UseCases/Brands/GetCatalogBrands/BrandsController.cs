using Domain;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Domain.CatalogBrands;
using Application.UseCases.GetCatalogBrands;

namespace WebApi.Controllers.V1.UseCases.GetCatalogBrands;

/// <summary>
/// Types controller.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class BrandsController : ControllerBase
{
    private readonly IGetCatalogBrandsUseCase _useCase;

    /// <summary>
    /// Initializes an instance of BrandsController.
    /// </summary>
    /// <param name="useCase"></param>
    public BrandsController(IGetCatalogBrandsUseCase useCase) => _useCase = useCase;


    /// <summary>
    /// Get brands.
    /// </summary>
    /// <returns>IActionResult.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedItems<CatalogBrand>))]
    public async Task<IActionResult> Get()
    {
        var types = await _useCase.Execute();

        return Ok(types);
    }
}
