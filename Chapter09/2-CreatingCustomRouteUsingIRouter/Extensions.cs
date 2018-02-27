using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

public static class Extensions
{
    public static IRouteBuilder AddProductsRoute(this IRouteBuilder routeBuilder, IApplicationBuilder app)
    {
        routeBuilder.Routes.Add(new Route(new ProductsRouter(), "products/{lang:regex(^([a-z]{{2}})-([A-Z]{{2}})$)}/{category:alpha}/{subcategory:alpha}/{id:guid}", app.ApplicationServices.GetService(typeof(IInlineConstraintResolver)) as IInlineConstraintResolver));

        return routeBuilder;
    }
}
