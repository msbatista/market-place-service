using Microsoft.AspNetCore.Mvc;
 
namespace WebApi.Modules.ActionResults;
 
/// <summary>
/// Internal server action result. Default response when exceptions do not meet the filters criteria.
/// </summary>
public class InternalServerErrorObjectResult : ObjectResult
{
    /// <summary>
    /// Configure the response status code to 500.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public InternalServerErrorObjectResult(object value) : base(value)
    {
        StatusCode = StatusCodes.Status500InternalServerError;
    }
}
