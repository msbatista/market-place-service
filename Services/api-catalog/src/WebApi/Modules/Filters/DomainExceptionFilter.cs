using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApi.ViewModels.ValidationModels;

namespace WebApi.Modules.Filters;

 
/// <summary>
/// Filters any domain exceptions.
/// </summary>
public class DomainExceptionFilter : IExceptionFilter
{
    private readonly ILogger<DomainExceptionFilter> _logger;
 
    /// <summary>
    /// Initializes an instance of DomainExceptionFilter.
    /// </summary>
    /// <param name="logger"></param>
    public DomainExceptionFilter(ILogger<DomainExceptionFilter> logger)
    {
        _logger = logger;
    }
 
    /// <summary>
    /// Maps domain exceptions to status 400.
    /// </summary>
    /// <param name="context"></param>
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is DomainException exception)
        {
            var problemDetails = new ProblemDetailsModel
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Bad Request",
                Detail = exception.Message
            };
 
             _logger.LogCritical(exception, "A domain exception occurred: {message}.",  exception.Message);
 
            context.Result = new BadRequestObjectResult(problemDetails);
            context.ExceptionHandled = true;
        }
    }
}
