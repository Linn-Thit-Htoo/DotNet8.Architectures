using Microsoft.Extensions.DependencyInjection;

namespace DotNet8.Architectures.Clean.Application.Extensions;

public static class Extension
{
    public static IServiceCollection AddMediatRService(this IServiceCollection services)
    {
        return services.AddMediatR(cf =>
            cf.RegisterServicesFromAssembly(typeof(Extension).Assembly)
        );
    }
}
