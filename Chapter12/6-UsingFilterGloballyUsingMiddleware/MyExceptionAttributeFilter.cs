using Microsoft.AspNetCore.Mvc.Filters;
using System;

public class MyExceptionAttributeFilter : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        if (context.Exception is InvalidOperationException)
        {
            // Log the exception informations by Asp.Net Core 
            // or custom logger 
            context.Exception = null;
        }
    }
}
