using Microsoft.Extensions.DependencyInjection;
using ModularMonolithPoC.Infrastructure.Interfaces;

namespace ModularMonolithPoC.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, MockUserRepository>();
        services.AddScoped<IProductRepository, MockProductRepository>();
        return services;
    }
}
