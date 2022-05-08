using Application.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApi.Modules.ActionResults;
using WebApi.ViewModels.ValidationModels;

namespace WebApi.Modules.Filters;

/// <summary>
/// Filters ObjectNotFoundException exception.
/// </summary>
public sealed class ObjectNotFoundExceptionFilter : IExceptionFilter
{
    private readonly ILogger<ObjectNotFoundExceptionFilter> _logger;

    /// <summary>
    /// Initializes an instance of ObjectNotFoundExceptionFilter.
    /// </summary>
    /// <param name="logger"></param>
    public ObjectNotFoundExceptionFilter(ILogger<ObjectNotFoundExceptionFilter> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Maps ObjectNotFoundException to status 404.
    /// </summary>
    /// <param name="context"></param>
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ObjectNotFoundException exception)
        {
            var problemDetails = new ProblemDetailsModel
            {
                Status = StatusCodes.Status404NotFound,
                Title = "Object Not Found",
                Detail = exception.Message
            };
 
             _logger.LogError(exception, "A domain exception occurred: {message}.",  exception.Message);
 
            context.Result = new ObjectNotFoundExceptionResult(problemDetails);
            context.ExceptionHandled = true;
        }
    }
}
