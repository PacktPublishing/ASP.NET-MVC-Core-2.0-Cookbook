using Microsoft.AspNetCore.Mvc.Filters;

public class MyResourceFilter : IResourceFilter
{
    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        // code executed before the filter executes
    }

    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        // code executed after the filter executes
    }
}
