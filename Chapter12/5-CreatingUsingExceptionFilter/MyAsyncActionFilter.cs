using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

public class myAsyncActionFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // do something before the action executes
        await next();
        // do something after the action executes
    }
}
