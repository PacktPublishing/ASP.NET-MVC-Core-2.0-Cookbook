using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

public class MyAsyncResourceFilter : IAsyncResourceFilter
{
    public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
    {
        // code executed before the filter executes
        await next();
        // code executed after the filter executes
    }
}
