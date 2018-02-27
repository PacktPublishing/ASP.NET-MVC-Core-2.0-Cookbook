using Microsoft.AspNetCore.Builder;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseMiddleware1(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MyMiddleware1>();
    }
}
