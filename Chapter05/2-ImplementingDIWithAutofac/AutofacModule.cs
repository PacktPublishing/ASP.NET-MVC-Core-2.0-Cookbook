using Autofac;
using ImplementingDIWithAutofac.Services;

public class AutofacModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.Register(c => new ProductService())
           .As<IProductService>()
           .InstancePerLifetimeScope();
  }
}
