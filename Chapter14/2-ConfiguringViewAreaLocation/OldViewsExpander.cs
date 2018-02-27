using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Razor;

public class OldViewsExpander : IViewLocationExpander
{
    public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
    {
        // rerturn all classic locations
        foreach (string location in viewLocations)
        {
            yield return location;
        }

        // return new locations
        yield return "/ViewsOld/Shared/{0}.cshtml";
        yield return "/ViewsOld/{1}/{0}.cshtml";

        // now the following locations will be tested
        // "/Views/Home"
        // "/Views/Product"
        // "/Views/Shared"
        // "/ViewsOld/Home"
        // "/ViewsOld/Product"
        // "/ViewsOld/Shared"
    }

    public void PopulateValues(ViewLocationExpanderContext context)
    {
    }
}
