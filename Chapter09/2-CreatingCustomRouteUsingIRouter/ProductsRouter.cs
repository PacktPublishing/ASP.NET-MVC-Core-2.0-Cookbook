using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;

public class ProductsRouter : IRouter
{
        private readonly Route _innerRoute;
        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        { return null; }

        public Task RouteAsync(RouteContext context)
        {
            // Test QueryStrings
            var qs = context.HttpContext.Request.Query;
            var price = qs["price"];

            if(string.IsNullOrEmpty(price))
            { return Task.FromResult(0); }

            var routeData = new RouteData();
            routeData.Values["controller"] = "Products";
            routeData.Values["action"] = "Details";
            routeData.DataTokens["price"] = price;
            context.RouteData = routeData;

            return _innerRoute.RouteAsync(context);
        }
}
