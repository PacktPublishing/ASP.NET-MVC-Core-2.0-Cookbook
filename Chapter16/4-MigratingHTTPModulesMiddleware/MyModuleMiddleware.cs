using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class MyModuleMiddleware
{
    private readonly RequestDelegate _next;

    public MyModuleMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        await httpContext.Response.WriteAsync
("MyHttpModule BeginRequest");
        await _next(httpContext);
        await httpContext.Response.WriteAsync
("MyHttpModule EndRequest");
    }
}

// Extension method used to add the middleware 
// to the HTTP request pipeline.
public static class MyModuleMiddlewareExtensions
{
    public static IApplicationBuilder UseMyModuleMiddleware
(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MyModuleMiddleware>();
    }
}
