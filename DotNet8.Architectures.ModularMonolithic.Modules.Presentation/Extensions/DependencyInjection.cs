﻿using DotNet8.Architectures.DbService;
using DotNet8.Architectures.ModularMonolithic.Modules.Domain.Features.Blog;
using DotNet8.Architectures.ModularMonolithic.Modules.Infrastructure.Features.Blog;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.Architectures.ModularMonolithic.Modules.Presentation.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, WebApplicationBuilder builder)
        {
            return services.AddDbContextService(builder)
                .AddRepositoryService();
        }

        private static IServiceCollection AddDbContextService(this IServiceCollection services, WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }, ServiceLifetime.Transient, ServiceLifetime.Transient);

            return services;
        }

        private static IServiceCollection AddRepositoryService(this IServiceCollection services)
        {
            return services.AddScoped<IBlogRepository, BlogRepository>();
        }
    }
}