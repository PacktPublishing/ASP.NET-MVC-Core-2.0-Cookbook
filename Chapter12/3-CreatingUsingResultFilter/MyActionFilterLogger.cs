using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

public class MyActionFilterLogger : IActionFilter
{
    private readonly ILogger _logger;
    public MyActionFilterLogger(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<MyActionFilterLogger>();
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _logger.LogInformation(
        "OnActionExecuted" + DateTime.Now.ToLongDateString());
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _logger.LogInformation(
        "OnActionExecuting" + DateTime.Now.ToLongDateString());
    }
}
