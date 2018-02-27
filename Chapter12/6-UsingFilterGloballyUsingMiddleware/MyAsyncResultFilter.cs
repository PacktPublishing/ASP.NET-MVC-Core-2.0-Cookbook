using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

public class MyAsyncResultFilter : IAsyncResultFilter
{
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        ViewResult result = context.Result as ViewResult;
        if (result != null)
        {
            result.ViewData["messageOnResult"] =
            "This message comes from MyAsyncResultFilter" +
            DateTime.Now.ToLongTimeString();
        }

        await next();
        // do something after the filter executes

    }
}
