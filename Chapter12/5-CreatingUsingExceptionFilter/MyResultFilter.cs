using Microsoft.AspNetCore.Mvc.Filters;

public class MyResultFilter : IResultFilter
{
    public void OnResultExecuted(ResultExecutedContext context)
    {
        // code executed before the filter executes
    }

    public void OnResultExecuting(ResultExecutingContext context)
    {
        // code executed after the filter executes
    }
}
