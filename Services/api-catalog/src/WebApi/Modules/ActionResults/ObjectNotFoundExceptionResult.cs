using Microsoft.AspNetCore.Mvc;
 
namespace WebApi.Modules.ActionResults;
 
/// <summary>
/// Not found action result. Default response when exceptions do not meet the filters criteria.
/// </summary>
public class ObjectNotFoundExceptionResult : ObjectResult
{
    /// <summary>
    /// Configure the response status code to 404.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public ObjectNotFoundExceptionResult(object value) : base(value)
    {
        StatusCode = StatusCodes.Status404NotFound;
    }
}
