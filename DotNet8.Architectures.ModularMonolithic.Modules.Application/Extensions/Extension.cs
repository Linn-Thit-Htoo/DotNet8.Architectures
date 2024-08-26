namespace DotNet8.Architectures.ModularMonolithic.Modules.Application.Extensions;

public static class Extension
{
    #region Add MediatR Service

    public static IServiceCollection AddMediatRService(this IServiceCollection services)
    {
        return services.AddMediatR(cf =>
            cf.RegisterServicesFromAssembly(typeof(Extension).Assembly)
        );
    }

    #endregion
}
