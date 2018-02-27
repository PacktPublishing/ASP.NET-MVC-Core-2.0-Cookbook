using DryIoc;
using ImplementingDIWithDryIoc.Services;

public static class Bootstrap
{
    public static void RegisterServices(IRegistrator registrator)
    {
        registrator.Register<IProductService, ProductService>(Reuse.Singleton);
    }
}
