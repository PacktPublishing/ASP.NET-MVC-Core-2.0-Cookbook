using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class MyMiddleware1
{
    private readonly RequestDelegate _next;

    public MyMiddleware1(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        await httpContext.Response.WriteAsync("Hello from first middleware before Request \n");
        await _next(httpContext);
        await httpContext.Response.WriteAsync("Hello from first middleware after Request \n");
    }
}
