using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

public class MyResourceCacheFilter : IResourceFilter
{
    private int _cacheDuration = 0;
    private bool _cacheEnabled = true;

    private readonly IConfigurationRoot _configuration;
    private readonly IMemoryCache _cache;
    private readonly ILogger _logger;

    public MyResourceCacheFilter(IConfigurationRoot configuration,
    IMemoryCache cache, ILoggerFactory loggerFactory)
    {
        _configuration = configuration;
        _cache = cache;
        _logger = loggerFactory.CreateLogger("MyResourceFilter");
        InitFilter();
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        if (_cacheEnabled)
        {
            string _cachekey = string.Join(":", new string[]
            {
context.RouteData.Values["controller"].ToString(),                            context.RouteData.Values["action"].ToString()
            });

            string cachedContent = string.Empty;
            if (_cache.TryGetValue(_cachekey, out cachedContent))
            {
                if (!String.IsNullOrEmpty(cachedContent))
                {
                    context.Result = new ContentResult()
                    {
                        Content = cachedContent
                    };
                }
            }
        }
    }

    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        try
        {
            if (_cacheEnabled)
            {
                if (_cache != null)
                {
                    string _cachekey = string.Join(":", new string[]
                    {
context.RouteData.Values["controller"].ToString(),                            context.RouteData.Values["action"].ToString()
                    });

                    var result = context.Result as ContentResult;
                    if (result != null)
                    {
                        string cachedContent = string.Empty;
                        _cache.Set(_cachekey, result.Content,
                        DateTime.Now.AddSeconds(_cacheDuration));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Error caching in MyResourceFilter", ex);
        }
    }

    private void InitFilter()
    {
        if (!Boolean.TryParse(
        _configuration.GetSection("CacheEnabled").Value,
        out _cacheEnabled))
        {
            _cacheEnabled = false;
        }

        if (!Int32.TryParse(
        _configuration.GetSection("CacheDuration").Value,
        out _cacheDuration))
        {
            _cacheDuration = 21600; // 6 hours cache by default
        }
    }
}
