using Microsoft.AspNetCore.Http;

public class MyHttpHandler : IHttpHandler
{
    public bool IsReusable { get { return false; } }

    public void ProcessRequest(HttpContext context)
    {
        context.Response.WriteAsync("This page pass by MyHttpHandler <br />");
    }
}
