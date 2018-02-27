using System;
using DryIoc;

public static class IocDiExtensions
{
    public static IServiceProvider ConfigureDI(this IServiceProvider services, Action<Registrator> configureServices)
    {
        var container = new Container().WithDependencyInjectionAdapter(services);

        configureServices(container);

        return container.Resolve<IServiceProvider>();
    }
}
