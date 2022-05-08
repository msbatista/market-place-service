using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using WebApi.Modules.ActionResults;
using WebApi.ViewModels.ValidationModels;

namespace WebApi.Modules.Filters;
 
/// <summary>
/// Handle transient exceptions.
/// </summary>
public class InternalExceptionFilter : IExceptionFilter
{
    private readonly ILogger<InternalExceptionFilter> _logger;
 
    /// <summary>
    /// Initializes an instance of InternalExceptionFilter.
    /// </summary>
    /// <param name="logger"></param>
    public InternalExceptionFilter(ILogger<InternalExceptionFilter> logger)
    {
        _logger = logger;
    }
 
    /// <summary>
    /// Handle transient exceptions.
    /// </summary>
    /// <param name="context"></param>
    public void OnException(ExceptionContext context)
    {
        if (
            context.Exception is SqlException ||
            context.Exception is TimeoutException ||
            context.Exception is Win32Exception ||
            context.Exception is SystemException)
        {
            var problemDetails = new ProblemDetailsModel
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Internal error",
                Detail = context.Exception.Message
            };
 
            _logger.LogCritical(context.Exception, "An internal exception has occurred: {message}.",  context.Exception.Message);
 
            context.Result = new InternalServerErrorObjectResult(problemDetails);
            context.ExceptionHandled = true;
        }
    }
}
