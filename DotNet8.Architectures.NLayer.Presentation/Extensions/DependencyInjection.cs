﻿using DotNet8.Architectures.DbService;
using DotNet8.Architectures.NLayer.BusinessLogic.Features.Blog;
using DotNet8.Architectures.NLayer.DataAccess.Features.Blog;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.Architectures.NLayer.Presentation.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services, WebApplicationBuilder builder)
    {
        return services.AddDbContextService(builder)
            .AddDataAccessService()
            .AddBusinessLogicService();
    }

    private static IServiceCollection AddDbContextService(this IServiceCollection services, WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
        }, ServiceLifetime.Transient, ServiceLifetime.Transient);

        return services;
    }

    private static IServiceCollection AddDataAccessService(this IServiceCollection services)
    {
        return services.AddScoped<DA_Blog>();
    }

    private static IServiceCollection AddBusinessLogicService(this IServiceCollection services)
    {
        return services.AddScoped<BL_Blog>();
    }
}
