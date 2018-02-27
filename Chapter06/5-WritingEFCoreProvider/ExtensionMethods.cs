public static class MyProviderDbContextOptionsExtensions
{
    public static DbContextOptionsBuilder UseMyProvider(this DbContextOptionsBuilder optionsBuilder, string connectionString)
    {
        (optionsBuilder as IDbContextOptionsBuilderInfrastructure).AddOrUpdateExtension(new MyProviderOptionsExtension {
            ConnectionString = connectionString
        });

        return optionsBuilder;
    }
}

public static class EntityFrameworkServicesBuilderExtensions
{
    public static EntityFrameworkServicesBuilder AddMyProvider(this EntityFrameworkServicesBuilder builder)
    {
        var serviceCollection = builder.GetInfrastructure();

        serviceCollection.TryAddEnumerable(ServiceDescriptor
                         .Singleton<IDatabaseProvider, DatabaseProvider<MyDatabaseProviderServices, MyProviderOptionsExtension>>());

        serviceCollection.TryAdd(new ServiceCollection()
        // singleton services
        .AddSingleton<MyModelSource>()
        .AddSingleton<MyValueGeneratorCache>()
        // scoped services
        .AddScoped<MyDatabaseProviderServices>()
        .AddScoped<MyDatabaseCreator>()
        .AddScoped<MyDatabase>()
        .AddScoped<MyEntityQueryableExpressionVisitorFactory>()
        .AddScoped<MyEntityQueryModelVisitorFactory>()
        .AddScoped<MyQueryContextFactory>()
        .AddScoped<MyTransactionManager>());

        return builder;
    }
}
