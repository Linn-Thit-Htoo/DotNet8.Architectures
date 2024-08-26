namespace DotNet8.Architectures.Clean.Presentation.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(
        this IServiceCollection services,
        WebApplicationBuilder builder
    )
    {
        return services.AddDbContextService(builder).AddRepositoryService();
    }

    #region Add Db Context Service

    private static IServiceCollection AddDbContextService(
        this IServiceCollection services,
        WebApplicationBuilder builder
    )
    {
        builder.Services.AddDbContext<BlogDbContext>(
            opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            },
            ServiceLifetime.Transient,
            ServiceLifetime.Transient
        );

        return services;
    }

    #endregion

    #region Add Repository Service

    private static IServiceCollection AddRepositoryService(this IServiceCollection services)
    {
        return services.AddScoped<IBlogRepository, BlogRepository>();
    }

    #endregion
}
