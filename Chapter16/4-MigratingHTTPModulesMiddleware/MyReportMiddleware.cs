using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class MyReportMiddleware
{
    private readonly RequestDelegate _next;

    public MyReportMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public Task Invoke(HttpContext httpContext)
    {
        return httpContext.Response.WriteAsync("this .report file will be executed and short circuit the pipeline");
        // we doesn't call next because we want to short circuit the 
        // pipeline in order to act as a classic HttpHandler
        //return _next(httpContext);
    }
}

// Extension method used to add the middleware 
// to the HTTP request pipeline.
public static class MyReportMiddlewareExtensions
{
    public static IApplicationBuilder UseMyReportMiddleware
(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MyReportMiddleware>();
    }
}
