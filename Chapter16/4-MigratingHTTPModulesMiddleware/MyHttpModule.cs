using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;

public class MyHttpModule : IHttpModule
{
    public void Dispose() { }

    public void Init(HttpApplication context)
    {
        context.BeginRequest += (source, args) =>
        {
            context.Response.Write("MyHttpModule BeginRequest");
        };

        context.EndRequest += (source, args) =>
        {
            context.Response.Write("MyHttpModule EndRequest");
        };
    }
}
