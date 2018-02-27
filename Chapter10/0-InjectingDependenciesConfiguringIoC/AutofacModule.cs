using Autofac;

public class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.Register(c => new ProductRepository())
        .As<IProductRepository>()
        .InstancePerLifetimeScope();
    }
}
